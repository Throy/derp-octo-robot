using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;

namespace IndignadoWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ChannelFactory<ServiceReference1.ITestService> scf;
            scf = new ChannelFactory<ServiceReference1.ITestService>(
                        new BasicHttpBinding(),
                        "http://localhost:8732/IndignadoServer/TestService/");


            ServiceReference1.ITestService s;
            s = scf.CreateChannel();

            ViewBag.Message = s.Ping("Pancho");

            (s as ICommunicationObject).Close();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
