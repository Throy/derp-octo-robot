using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security.Tokens;
using System.Security.Cryptography;
using System.Security.Permissions;
using IndignadoServer.Controllers;
using IndignadoServer.Services;

namespace IndignadoServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SessionService" in both code and config file together.
    public class SessionService : ISessionService
    {
        public DTLoginInfo Login(int idMovmiento, String userName, String password)
        {
            return ControllersHub.Instance.getISessionController().Login(idMovmiento, userName, password);
        }

        public DTLoginInfo LoginFB(int idMovimiento, String accesToken)
        {
            return ControllersHub.Instance.getISessionController().LoginFB(idMovimiento, accesToken);
        }

        public DTUserCreateStatus RegisterUser(DTRegisterModel user)
        {
            return ControllersHub.Instance.getISessionController().RegisterUser(user);
        }

        public DTUserCreateStatus RegisterFBUser(DTRegisterFBModel user)
        {
            return ControllersHub.Instance.getISessionController().RegisterFBUser(user);
        }

        public bool ValidateToken(int idMovmiento, String token)
        {
            return ControllersHub.Instance.getISessionController().ValidateToken(idMovmiento, token);
        }

        public DTTenantInfo GetTenantInfo(String movimiento)
        {
            return ControllersHub.Instance.getISessionController().GetTenantInfo(movimiento);
        }


        // checks that the client is a registered user.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public bool ValidateRegUser()
        {
            return true;
        }

        // checks that the client is a movement admin.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public bool ValidateMovAdmin()
        {
            return true;
        }

        // checks that the client is a system admin.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.SysAdmin)]
        public bool ValidateSysAdmin()
        {
            return true;
        }
    }
}
