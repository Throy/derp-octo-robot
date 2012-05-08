using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using IndignadoWeb.MeetingsServiceReference;
using IndignadoWeb.MovAdminServiceReference;
using IndignadoWeb.NewsResourcesServiceReference;
using IndignadoWeb.SysAdminServiceReference;
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

        // shows all movements in a map.
        public ActionResult MeetingsMap()
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



        // shows all movements in a list.
        public ActionResult MovementsList()
        {
            // open service
            ChannelFactory<SysAdminServiceReference.ISysAdminService> scf;
            scf = new ChannelFactory<SysAdminServiceReference.ISysAdminService>(
                        new BasicHttpBinding(),
                        "http://localhost:8730/IndignadoServer/SysAdminService/");


            SysAdminServiceReference.ISysAdminService serv;
            serv = scf.CreateChannel();

            // get all movements
            DTMovementsCol movements = serv.getMovementsList();

            // close service
            (serv as ICommunicationObject).Close();

            // send the movements to the model.
            return View(movements);
        }

        // create movement.
        public ActionResult MovementCreate()
        {
            return View();
        }

        // create movement.
        [HttpPost]
        public ActionResult MovementCreate (SingleMovementModel model)
        {
            if (ModelState.IsValid)
            {
                // open service
                ChannelFactory<SysAdminServiceReference.ISysAdminService> scf;
                scf = new ChannelFactory<SysAdminServiceReference.ISysAdminService>(
                            new BasicHttpBinding(),
                            "http://localhost:8730/IndignadoServer/SysAdminService/");


                SysAdminServiceReference.ISysAdminService serv;
                serv = scf.CreateChannel();

                // create new movement
                //serv.addEmptyMovement();

                IndignadoWeb.SysAdminServiceReference.DTMovement dtMovement = new IndignadoWeb.SysAdminServiceReference.DTMovement();
                dtMovement.id = -1;
                dtMovement.name = model.name;
                dtMovement.description = model.description;
                dtMovement.locationLati = model.locationLati;
                dtMovement.locationLong = model.locationLong;
                dtMovement.adminNick = model.adminNick;
                dtMovement.adminPassword = model.adminPassword;
                dtMovement.adminMail = model.adminMail;
                serv.createMovement(dtMovement);

                // get all movements
                DTMovementsCol movements = serv.getMovementsList();

                // close service
                (serv as ICommunicationObject).Close();

                // send the movements to the model.
                return View("MovementsList", movements);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // configure movement.
        public ActionResult MovementConfig()
        {
            // open service
            ChannelFactory<MovAdminServiceReference.IMovAdminService> scf;
            scf = new ChannelFactory<MovAdminServiceReference.IMovAdminService>(
                        new BasicHttpBinding(),
                        "http://localhost:8730/IndignadoServer/MovAdminService/");


            MovAdminServiceReference.IMovAdminService serv;
            serv = scf.CreateChannel();

            // get movement
            IndignadoWeb.MovAdminServiceReference.DTMovement movement = serv.getMovement(0);

            // close service
            (serv as ICommunicationObject).Close();

            // send the meeting to the model.
            SingleMovementModel model = new SingleMovementModel();
            model.name = movement.name;
            model.description = movement.description;
            model.locationLati = movement.locationLati;
            model.locationLong = movement.locationLong;
            model.adminNick = movement.adminMail;
            model.adminPassword = movement.adminPassword;
            model.adminMail = movement.adminMail;
            return View(model);
        }

        // configure movement.
        [HttpPost]
        public ActionResult MovementConfig(SingleMovementModel model)
        {
            if (ModelState.IsValid)
            {
                // open service
                ChannelFactory<MovAdminServiceReference.IMovAdminService> scf;
                scf = new ChannelFactory<MovAdminServiceReference.IMovAdminService>(
                            new BasicHttpBinding(),
                            "http://localhost:8730/IndignadoServer/MovAdminService/");


                MovAdminServiceReference.IMovAdminService serv;
                serv = scf.CreateChannel();

                // create new movement
                //serv.addEmptyMovement();

                IndignadoWeb.MovAdminServiceReference.DTMovement dtMovement = new IndignadoWeb.MovAdminServiceReference.DTMovement();
                dtMovement.id = -1;
                dtMovement.name = model.name;
                dtMovement.description = model.description;
                dtMovement.locationLati = model.locationLati;
                dtMovement.locationLong = model.locationLong;
                dtMovement.adminNick = model.adminNick;
                dtMovement.adminPassword = model.adminPassword;
                dtMovement.adminMail = model.adminMail;
                serv.setMovement(dtMovement);

                // close service
                (serv as ICommunicationObject).Close();

                // open service
                ChannelFactory<SysAdminServiceReference.ISysAdminService> scf2;
                scf2 = new ChannelFactory<SysAdminServiceReference.ISysAdminService>(
                            new BasicHttpBinding(),
                            "http://localhost:8730/IndignadoServer/SysAdminService/");


                SysAdminServiceReference.ISysAdminService serv2;
                serv2 = scf2.CreateChannel();

                // get all movements
                DTMovementsCol movements = serv2.getMovementsList();

                // send the movements to the model.
                return View("MovementsList", movements);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // shows all resources in a list.
        public ActionResult ResourcesList()
        {
            // open service
            ChannelFactory<NewsResourcesServiceReference.INewsResourcesService> scf2;
            scf2 = new ChannelFactory<NewsResourcesServiceReference.INewsResourcesService>(
                        new BasicHttpBinding(),
                        "http://localhost:8730/IndignadoServer/NewsResourcesService/");


            NewsResourcesServiceReference.INewsResourcesService serv2;
            serv2 = scf2.CreateChannel();

            // get all movements
            DTRssItemsCol rssItemsCol = serv2.getResourcesList();

            return View(rssItemsCol);
        }
    }
}
