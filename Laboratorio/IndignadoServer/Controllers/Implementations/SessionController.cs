using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Security.Cryptography;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security.Tokens;
using IndignadoServer.LinqDataContext;
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

        public DTLoginInfo Login(int idMovimiento, String userName, String password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

            // calculo el hash del password
            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            byte[] passwordHash = sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            byte[] noPass = new byte[1];
            noPass[0] = 0;

            // busco el usuario en la base de datos
            var db = new IndignadoDBDataContext();
            var user = db.Usuarios.SingleOrDefault(u => (u.idMovimiento == idMovimiento &&
                                          u.apodo == userName &&
                                          u.contraseña == passwordHash &&
                                          u.contraseña != noPass) ||
                                          (u.apodo == userName &&
                                           u.contraseña == passwordHash &&
                                           u.contraseña != noPass &&
                                           (u.privilegio & IndignadoServer.Roles.SysAdminMask) == IndignadoServer.Roles.SysAdminMask));

            if (user == null)
            {
                // si no lo encontro
                throw new FaultException<LoginFault>(new LoginFault("Unknown Username or Incorrect Password", DTLoginFaultType.UNKOWN_OR_INVALID));
            }

            String token = GenerateToken();

            _usersOnline[token] = new UserOnlineInfo(user.id, user.apodo, user.privilegio, idMovimiento, token);

            return new DTLoginInfo(user.apodo, token);
        }

        public DTLoginInfo LoginFB(int idMovimiento, String accesToken)
        {
            if (null == accesToken)
            {
                throw new ArgumentNullException();
            }

            FacebookUser fbUser = Facebook.GetInfo(accesToken);

            // busco el usuario en la base de datos
            var db = new IndignadoDBDataContext();

            var fbUserDB = db.UsuarioFacebooks.SingleOrDefault(u => (u.idMovimiento == idMovimiento &&
                                          u.idFacebook == fbUser.id));

            if (fbUserDB == null)
            {
                throw new FaultException<LoginFault>(new LoginFault("El usuario logueado por facebook no se encuentra registrado", DTLoginFaultType.FB_NOT_REGISTERED));
            }

            var userDB = db.Usuarios.SingleOrDefault(u => (u.id == fbUserDB.idUsuario));

            String token = GenerateToken();

            _usersOnline[token] = new UserOnlineInfo(userDB.id, userDB.apodo, userDB.privilegio, idMovimiento, token);

            return new DTLoginInfo(userDB.apodo, token);
        }

        public DTUserCreateStatus RegisterUser(DTRegisterModel user)
        {
            DTUserCreateStatus status;
            status = DTUserCreateStatus.Success;

            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            Usuario userDb = DTToClass.DTToUsuario(user);

            userDb.banned = false;
            userDb.privilegio = 0;
            userDb.fechaRegistro = DateTime.Now;

            try
            {
                indignadoContext.Usuarios.InsertOnSubmit(userDb);
                indignadoContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                status = DTUserCreateStatus.GenericError;
            }

            return status;
        }

        public DTUserCreateStatus RegisterFBUser(DTRegisterFBModel user)
        {
            DTUserCreateStatus status;
            status = DTUserCreateStatus.Success;

            FacebookUser fbUser = Facebook.GetInfo(user.token);

            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            Usuario userDb = new Usuario();

            userDb.nombre = fbUser.name;
            userDb.apodo = fbUser.first_name;
            userDb.mail = fbUser.email;
            userDb.idMovimiento = user.idMovimiento;
            userDb.latitud = user.latitud;
            userDb.longitud = user.longitud;

            byte[] noPass = new byte[1];
            noPass[0] = 0;
            userDb.contraseña = noPass;

            userDb.banned = false;
            userDb.privilegio = 0;
            userDb.fechaRegistro = DateTime.Now;

            try
            {
                indignadoContext.Usuarios.InsertOnSubmit(userDb);
                indignadoContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                status = DTUserCreateStatus.GenericError;
            }

            if (status == DTUserCreateStatus.Success)
            {
                UsuarioFacebook fbUserDb = new UsuarioFacebook();
                fbUserDb.idUsuario = userDb.id;
                fbUserDb.idFacebook = (int) fbUser.id;
                fbUserDb.idMovimiento = user.idMovimiento;

                indignadoContext.UsuarioFacebooks.InsertOnSubmit(fbUserDb);
                indignadoContext.SubmitChanges();
            }

            return status;
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

        private String GenerateToken()
        {
            // este token no es muy bueno, revisar y mejorarlo
            // Create an array to store the key bytes keysize=1024
            byte[] key = new byte[1024 / 8];
            // Create some random bytes
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            random.GetNonZeroBytes(key);

            SecurityToken token = new BinarySecretSecurityToken(key);

            return token.Id;
        }
    }
}
