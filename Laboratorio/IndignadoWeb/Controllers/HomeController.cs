using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using IndignadoWeb.MeetingsServiceReference;

namespace IndignadoWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

            ChannelFactory<TestServiceReference.ITestService> scf;
            scf = new ChannelFactory<TestServiceReference.ITestService>(
                        binding,
                        "http://localhost:8730/IndignadoServer/TestService/");


            scf.Credentials.UserName.UserName = "0"; // idMovimiento
            scf.Credentials.UserName.Password = (HttpContext.Session["token"] == null) ? "Guest" : HttpContext.Session["token"].ToString();

            TestServiceReference.ITestService serv;
            serv = scf.CreateChannel();

            if (HttpContext.Session["token"] != null)
            {   
                ViewBag.Message = serv.PingUsers("Pancho");
            }
            else
            {
                ViewBag.Message = serv.PingPublic("DonNadie");
            }
            
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
            // open service
            ChannelFactory<MeetingsServiceReference.IMeetingsService> scf;
            scf = new ChannelFactory<MeetingsServiceReference.IMeetingsService>(
                        new BasicHttpBinding(),
                        "http://localhost:8730/IndignadoServer/MeetingsService/");


            MeetingsServiceReference.IMeetingsService serv;
            serv = scf.CreateChannel();

            // get meeting
            DTMeeting meeting = serv.getMeeting();

            // close service
            (serv as ICommunicationObject).Close();

            // send the meeting to the model.
            return View (meeting);
        }

        // shows all meetings.
        public ActionResult MeetingsList()
        {
            // open service
            ChannelFactory<MeetingsServiceReference.IMeetingsService> scf;
            scf = new ChannelFactory<MeetingsServiceReference.IMeetingsService>(
                        new BasicHttpBinding(),
                        "http://localhost:8730/IndignadoServer/MeetingsService/");


            MeetingsServiceReference.IMeetingsService serv;
            serv = scf.CreateChannel();

            // get all meetings
            DTMeetingsCol meetings = serv.getMeetingsList();

            // close service
            (serv as ICommunicationObject).Close();

            // send the meetings to the model.
            return View (meetings);
        }
    }
}
