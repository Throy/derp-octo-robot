using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignadoServer.Services;

namespace IndignadoServer.Controllers
{
    interface ISessionController
    {
        DTLoginInfo Login(int idMovmiento, String userName, String password);

        DTLoginInfo LoginFB(int idMovimiento, String accesToken);

        DTUserCreateStatus RegisterUser(DTRegisterModel user);

        DTUserCreateStatus RegisterFBUser(DTRegisterFBModel user);

        bool ValidateToken(int idMovmiento, String token);

        UserOnlineInfo GetUserInfo(String token);

        DTTenantInfo GetTenantInfo(String movimiento);
    }
}
