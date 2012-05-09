using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Principal;
using IndignadoServer.Controllers;

namespace IndignadoServer
{

    public class IndignadoController
    {
        public int IdMovement
        {
            get
            {
                return int.Parse(Thread.CurrentPrincipal.Identity.AuthenticationType);
            }
        }

        public IPrincipal User 
        {
            get
            {
                return Thread.CurrentPrincipal;
            }
        }

        public String UserToken
        {
            get
            {
                return Thread.CurrentPrincipal.Identity.Name;
            }
        }

        public UserOnlineInfo UserInfo
        {
            get
            {
                if (UserToken != "NoId")
                    return ControllersHub.Instance.getISessionController().GetUserInfo(UserToken);
                
                return null;
            }
        }
    }
}
