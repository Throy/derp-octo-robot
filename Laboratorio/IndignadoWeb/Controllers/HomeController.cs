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
            ChannelFactory<TestServiceReference.ITestService> scf;
            scf = new ChannelFactory<TestServiceReference.ITestService>(
                        new BasicHttpBinding(),
                        "http://localhost:8730/IndignadoServer/TestService/");


            TestServiceReference.ITestService serv;
            serv = scf.CreateChannel();

            ViewBag.Message = serv.Ping("Pancho");

            (serv as ICommunicationObject).Close();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        // shows a meeting.
        public ActionResult MeetingDetails()
        {
            ChannelFactory<MeetingsServiceReference.IMeetingsService> scf;
            scf = new ChannelFactory<MeetingsServiceReference.IMeetingsService>(
                        new BasicHttpBinding(),
                        "http://localhost:8730/IndignadoServer/MeetingsService/");


            MeetingsServiceReference.IMeetingsService serv;
            serv = scf.CreateChannel();

            ViewBag.Message = serv.getMeeting();

            (serv as ICommunicationObject).Close();

            return View();
        }
    }
}
