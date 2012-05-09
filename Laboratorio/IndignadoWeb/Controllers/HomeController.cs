using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using IndignadoWeb.MeetingsServiceReference;
using IndignadoWeb.MovAdminServiceReference;
using IndignadoWeb.SysAdminServiceReference;
using IndignadoWeb.Models;
using IndignadoWeb.TestServiceReference;
using IndignadoWeb.Common;
using IndignadoWeb.NewsResourcesServiceReference;
using IndignadoWeb.SessionServiceReference;

namespace IndignadoWeb.Controllers
{
    [MultiTenanActionFilter]
    public class HomeController : Controller
    {
        public T GetService<T>(String url)
        {
            var binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

            ChannelFactory<T> scf;
            scf = new ChannelFactory<T>(
                        binding,
                        url);

            DTTenantInfo tenantInfo = HttpContext.Session["tenantInfo"] as DTTenantInfo;

            scf.Credentials.UserName.UserName = tenantInfo.id.ToString(); // idMovimiento
            scf.Credentials.UserName.Password = (HttpContext.Session["token"] == null) ? "Guest" : HttpContext.Session["token"].ToString();

            return scf.CreateChannel();
        }

        public ActionResult Index(DTTenantInfo tenantInfo)
        {
            ITestService serv = GetService<ITestService>("http://localhost:8730/IndignadoServer/TestService/");
                
            if (HttpContext.Session["token"] != null)
            {   
                ViewBag.Message = serv.PingUsers("Pancho");
            }
            else
            {
                ViewBag.Message = serv.PingUsers("DonNadie");
            }
            
            (serv as ICommunicationObject).Close();

            return View("Index");
        }

        public ActionResult About()
        {
            return View();
        }

        // shows a meeting.
        public ActionResult MeetingDetails()
        {
            // open service
            IMeetingsService serv = GetService<IMeetingsService>("http://localhost:8730/IndignadoServer/MeetingsService/");

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
            IMeetingsService serv = GetService<IMeetingsService>("http://localhost:8730/IndignadoServer/MeetingsService/");

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
            IMeetingsService serv = GetService<IMeetingsService>("http://localhost:8730/IndignadoServer/MeetingsService/");

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
                IMeetingsService serv = GetService<IMeetingsService>("http://localhost:8730/IndignadoServer/MeetingsService/");

                // create new meeting
                DTMeeting dtMeeting = new DTMeeting();
                dtMeeting.id = -1;
                dtMeeting.idMovement = 0;
                dtMeeting.name = model.name;
                dtMeeting.description = model.description;
                dtMeeting.locationLati = model.locationLati;
                dtMeeting.locationLong = model.locationLong;
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
            ISysAdminService serv = GetService<ISysAdminService>("http://localhost:8730/IndignadoServer/SysAdminService/");

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
                ISysAdminService serv = GetService<ISysAdminService>("http://localhost:8730/IndignadoServer/SysAdminService/");

                // create new movement
                //serv.addEmptyMovement();

                IndignadoWeb.SysAdminServiceReference.DTMovement dtMovement = new IndignadoWeb.SysAdminServiceReference.DTMovement();
                dtMovement.id = -1;
                dtMovement.name = model.name;
                dtMovement.description = model.description;
                dtMovement.locationLati = model.locationLati;
                dtMovement.locationLong = model.locationLong;
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
            IMovAdminService serv = GetService<IMovAdminService>("http://localhost:8730/IndignadoServer/MovAdminService/");

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

            return View(model);
        }

        // configure  movement.
        [HttpPost]
        public ActionResult MovementConfig(SingleMovementModel model)
        {
            if (ModelState.IsValid)
            {
                IMovAdminService serv = GetService<IMovAdminService>("http://localhost:8730/IndignadoServer/MovAdminService/");

                // create new movement
                //serv.addEmptyMovement();

                IndignadoWeb.MovAdminServiceReference.DTMovement dtMovement = new IndignadoWeb.MovAdminServiceReference.DTMovement();
                dtMovement.id = -1;
                dtMovement.name = model.name;
                dtMovement.description = model.description;
                dtMovement.locationLati = model.locationLati;
                dtMovement.locationLong = model.locationLong;
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

        // shows all news in a list.
        public ActionResult NewsList()
        {
            // open service
            INewsResourcesService serv = GetService<INewsResourcesService>("http://localhost:8730/IndignadoServer/NewsResourcesService/");

            // get all news
            DTRssItemsCol rssItemsCol = serv.getNewsList();

            return View(rssItemsCol);
        }
    }
}
