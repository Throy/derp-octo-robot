using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Principal;

namespace IndignadoServer
{

    public class IndignadoController
    {
        public string IdMovimiento
        {
            get
            {
                return Thread.CurrentPrincipal.Identity.AuthenticationType;
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
    }
}
