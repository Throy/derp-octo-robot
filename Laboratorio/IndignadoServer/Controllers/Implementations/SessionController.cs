using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Security.Cryptography;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security.Tokens;
using IndignadoServer.LinqDataContext;
using System.Data.Linq.Mapping;

namespace IndignadoServer.Controllers
{
    class SessionController
    {
        private static SessionController _instance;
        private Dictionary<String, UserOnlineInfo> _usersOnline;

        public SessionController()
        {
            _usersOnline = new Dictionary<String, UserOnlineInfo>();
        }

        public static SessionController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SessionController();
                return _instance;
            }
        }

        public String Login(int idMovimiento, String userName, String password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

            // calculo el hash del password
            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            byte[] passwordHash = sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            // busco el usuario en la base de datos
            var db = new IndignadoDBDataContext();
            var user = db.Usuarios.SingleOrDefault(u => u.idMovimiento == idMovimiento &&
                                          u.apodo == userName &&
                                          u.contraseña == passwordHash);
            /*
            var query = from u in db.Usuarios
                        where u.idMovimiento == idMovimiento && 
                              u.apodo == userName &&
                              u.contraseña == passwordHash
                        select u;
            */
            if (user == null)
            {
                // si no lo encontro
                throw new FaultException("Unknown Username or Incorrect Password");
            }

            // Create an array to store the key bytes keysize=1024
            byte[] key = new byte[1024 / 8];
            // Create some random bytes
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            random.GetNonZeroBytes(key);

            SecurityToken token = new BinarySecretSecurityToken(key);


            _usersOnline[token.Id] = new UserOnlineInfo(user.id, user.apodo, user.privilegio, idMovimiento, token.Id);

            return token.Id;
        }

        public bool ValidateToken(int idMovmiento, String token)
        {
            if (_usersOnline[token] == null)
                return false;
            
            return _usersOnline[token].IdMovimiento == idMovmiento;
        }

        public UserOnlineInfo GetUserInfo(String token)
        {
            return _usersOnline[token];
        }
    }
}
