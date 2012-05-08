using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using IndignadoWeb.Common;

namespace IndignadoWeb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add("SubDomainRoute", new DomainRoute(
                       "{movimiento}.4c7.net",     // Domain with parameters 
                       "{controller}/{action}/{id}",    // URL with parameters 
                       new { movimiento = "default", controller = "Home", action = "Index", id = "" }  // Parameter defaults 
                    ));

            routes.Add("SubDomain2Route", new DomainRoute(
                       "{movimiento}.indignado.4c7.net",     // Domain with parameters 
                       "{controller}/{action}/{id}",    // URL with parameters 
                       new { movimiento = "default", controller = "Home", action = "Index", id = "" }  // Parameter defaults 
                    ));
            
            /*
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );*/

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

        }
    }
}