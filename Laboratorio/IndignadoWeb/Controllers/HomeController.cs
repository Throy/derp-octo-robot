using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using IndignadoWeb.MeetingsServiceReference;
using IndignadoWeb.Models;

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
            // open service
            ChannelFactory<MeetingsServiceReference.IMeetingsService> scf;
            scf = new ChannelFactory<MeetingsServiceReference.IMeetingsService>(
                        new BasicHttpBinding(),
                        "http://localhost:8730/IndignadoServer/MeetingsService/");


            MeetingsServiceReference.IMeetingsService serv;
            serv = scf.CreateChannel();

            // get meeting
            DTMeeting meeting = serv.getMeeting(0);

            // close service
            (serv as ICommunicationObject).Close();

            // send the meeting to the model.
            return View(meeting);
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
            return View(meetings);
        }

        // create meeting.
        public ActionResult MeetingCreate()
        {
            return View();
        }

        // create meeting.
        [HttpPost]
        public ActionResult MeetingCreate (CreateMeetingModel model)
        {
            if (ModelState.IsValid)
            {
                // open service
                ChannelFactory<MeetingsServiceReference.IMeetingsService> scf;
                scf = new ChannelFactory<MeetingsServiceReference.IMeetingsService>(
                            new BasicHttpBinding(),
                            "http://localhost:8730/IndignadoServer/MeetingsService/");


                MeetingsServiceReference.IMeetingsService serv;
                serv = scf.CreateChannel();

                // create new meeting
                //serv.addEmptyMeeting();

                DTMeeting dtMeeting = new DTMeeting();
                dtMeeting.id = -1;
                dtMeeting.name = model.name;
                dtMeeting.description = model.description;
                dtMeeting.minQuorum = model.minQuorum;
                serv.createMeeting(dtMeeting);

                // get all meetings
                DTMeetingsCol meetings = serv.getMeetingsList();

                // close service
                (serv as ICommunicationObject).Close();

                // send the meetings to the model.
                return View ("MeetingsList", meetings);
            }

            // If we got this far, something failed, redisplay form
            return View (model);
        }
    }
}
