using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Security.Principal;
using System.Security.Permissions;

namespace IndignadoServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TestService : ITestService
    {
        public string PingPublic(string name)
        {
            Console.WriteLine("SERVER - Processing Ping('{0}')", name);

            return "Hello Guest, " + name;
        }

        public string PingUsers(string name)
        {
            IPrincipal principal = Thread.CurrentPrincipal;

            Console.WriteLine("SERVER - Processing Ping('{0}')", name);

            // En este metodo en ves de usar PrincipalPermission ... como en PingMovAdmin
            // puedo tambien chekear de esta otra forma, y hacer cosas si el usuario no tiene
            // permisos en ves de solo tirar exception
            if (principal.IsInRole(Roles.RegUser))
                return "Hello User del movimiento: "+ principal.Identity.AuthenticationType +" , " + name;
            else
                return "Tas pasado";
        }


        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public string PingMovAdmin(string name)
        {
            Console.WriteLine("SERVER - Processing Ping('{0}')", name);

            return "Hello MovAdmin, " + name;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Roles.SysAdmin)]
        public string PingSysAdmin(string name)
        {
            Console.WriteLine("SERVER - Processing Ping('{0}')", name);

            return "Hello SysAdmin, " + name;
        }
    }
}
