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
using IndignadoServer.Services;

namespace IndignadoServer.Controllers
{
    class SessionController : ISessionController
    {
        private Dictionary<String, UserOnlineInfo> _usersOnline;

        public SessionController()
        {
            _usersOnline = new Dictionary<String, UserOnlineInfo>();
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
            var user = db.Usuarios.SingleOrDefault(u => (u.idMovimiento == idMovimiento &&
                                          u.apodo == userName &&
                                          u.contraseña == passwordHash ) ||
                                          (u.apodo == userName && 
                                           u.contraseña == passwordHash &&
                                           (u.privilegio & IndignadoServer.Roles.SysAdminMask) == IndignadoServer.Roles.SysAdminMask));

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
            if (!_usersOnline.ContainsKey(token))
                return false;
            
            return _usersOnline[token].IdMovimiento == idMovmiento;
        }

        public UserOnlineInfo GetUserInfo(String token)
        {
            return _usersOnline[token];
        }

        public DTTenantInfo GetTenantInfo(String movimiento)
        {
            DTTenantInfo info = new DTTenantInfo();

            var db = new IndignadoDBDataContext();
            var movInfo = db.Movimientos.SingleOrDefault(m => m.nombre == movimiento);

            if (movInfo == null)
            {
                // si no lo encontro
                throw new FaultException("No existe un movimiento con ese nombre!");
            }

            info.name = movInfo.nombre;
            info.habilitado = movInfo.habilitado;
            info.id = movInfo.id;
            info.logo = movInfo.logo;
            info.layoutFile = movInfo.Layout.layoutFile;

            return info;
        }
    }
}
