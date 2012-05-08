using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignadoServer.Services;

namespace IndignadoServer.Controllers
{
    interface ISessionController
    {
        String Login(int idMovmiento, String userName, String password);

        bool ValidateToken(int idMovmiento, String token);

        UserOnlineInfo GetUserInfo(String token);

        DTTenantInfo GetTenantInfo(String movimiento);
    }
}
