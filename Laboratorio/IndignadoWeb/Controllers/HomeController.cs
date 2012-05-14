﻿using System;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using System.IO;
using IndignadoWeb.Common;
using IndignadoWeb.MeetingsServiceReference;
using IndignadoWeb.Models;
using IndignadoWeb.MovAdminServiceReference;
using IndignadoWeb.NewsResourcesServiceReference;
using IndignadoWeb.SessionServiceReference;
using IndignadoWeb.SysAdminServiceReference;
using IndignadoWeb.TestServiceReference;
using System.ServiceModel.Security;

namespace IndignadoWeb.Controllers
{
    public class HomeControllerConstants
    {
        public const string viewAccessDenied = "AccessDenied";
        public const string viewLogOn = "LogOn";
        public const string viewMeetingCreate = "MeetingCreate";
        public const string viewMeetingsList = "MeetingsList";
        public const string viewMeetingsMap = "MeetingsMap";
        public const string viewMovementConfig = "MovementConfig";
        public const string viewNewsList = "NewsList";
        public const string viewResourceShare = "ResourceShare";
        public const string viewResourcesList = "ResourcesList";

        public const string urlMeetingsService = "http://localhost:8730/IndignadoServer/MeetingsService/";
        public const string urlMovAdminService = "http://localhost:8730/IndignadoServer/MovAdminService/";
        public const string urlNewsResourcesService = "http://localhost:8730/IndignadoServer/NewsResourcesService/";
        public const string urlSessionService = "http://localhost:8730/IndignadoServer/SessionService/";
        public const string urlTestService = "http://localhost:8730/IndignadoServer/TestService/";
    }


    [MultiTenanActionFilter]
    public class HomeController : Controller
    {
        private T GetService<T>(String url)
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
            ITestService serv = GetService<ITestService>(HomeControllerConstants.urlTestService);
                
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

        public ActionResult AccessDenied()
        {
            return View();
        }

        // shows a meeting.
        public ActionResult MeetingDetails()
        {
            // open service
            IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

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
            IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

            // get all meetings
            DTMeetingsCol meetings = serv.getMeetingsList();

            // close service
            (serv as ICommunicationObject).Close();

            // send the meetings to the model.
            return View(meetings);
        }

        // like resource.
        [HttpPost]
        public ActionResult MeetingsList(string buttonDoAttend, string buttonDontAttend, string buttonUnconfirmAttendance, int id)
        {
            try
            {
                if (buttonDoAttend != null)
                {
                    // open service
                    IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

                    // do attend
                    DTMeeting dtMeeting = new DTMeeting();
                    dtMeeting.id = id;
                    serv.doAttendMeeting(dtMeeting);

                    return RedirectToAction(HomeControllerConstants.viewMeetingsList);
                }

                else if (buttonDontAttend != null)
                {
                    // open service
                    IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

                    // don't attend
                    DTMeeting dtMeeting = new DTMeeting();
                    dtMeeting.id = id;
                    serv.dontAttendMeeting(dtMeeting);

                    return RedirectToAction(HomeControllerConstants.viewMeetingsList);
                }

                else if (buttonUnconfirmAttendance != null)
                {
                    // open service
                    IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

                    // unconfirm attendance
                    DTMeeting dtMeeting = new DTMeeting();
                    dtMeeting.id = id;
                    serv.unconfirmAttendMeeting(dtMeeting);

                    return RedirectToAction(HomeControllerConstants.viewMeetingsList);
                }

                return View();
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // shows all movements in a map.
        public ActionResult MeetingsMap()
        {
            IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

            // get all meetings
            DTMeetingsCol meetings = serv.getMeetingsList();

            // close service
            (serv as ICommunicationObject).Close();

            // send the meetings to the model.
            return View(meetings);
        }
        public ActionResult ShowImage(String pathImg)
        {
            var file = Server.MapPath(pathImg);
            return File(file, "image/jpg", Path.GetFileName(file));
        }
        
        // create meeting.
        public ActionResult MeetingCreate()
        {
            /*
            try
            {
                // check if the user is a registered user.
                ISessionService serv = GetService<ISessionService>(HomeControllerConstants.urlSessionService);
                serv.ValidateRegUser();
            */
                // show form
                return View();
            /*
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
            */
        }

        // create meeting.
        [HttpPost]
        public ActionResult MeetingCreate (CreateMeetingModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    if (ModelState.IsValidField("name") && ModelState.IsValidField("description") && ModelState.IsValidField("locationLati")
                        && ModelState.IsValidField("locationLong") && ModelState.IsValidField("minQuorum"))
                    {
                        IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

                        // create new meeting
                        DTMeeting dtMeeting = new DTMeeting();
                        dtMeeting.id = -1;
                        dtMeeting.idMovement = -1;
                        dtMeeting.name = model.name;
                        dtMeeting.description = model.description;
                        dtMeeting.locationLati = model.locationLati;
                        dtMeeting.locationLong = model.locationLong;
                        dtMeeting.minQuorum = model.minQuorum;
                        

                        string fileName = Guid.NewGuid().ToString();
                        string serverPath = Server.MapPath("~");
                        string imagesPath = serverPath + "Content\\Images\\";
                        string thumbPath = imagesPath + "Thumb\\";
                        string fullPath = imagesPath + "Full\\";
                
                        CreateMeetingModel.ResizeAndSave(thumbPath, fileName, model.ImageUploaded.InputStream, 80, true);
                        CreateMeetingModel.ResizeAndSave(fullPath, fileName, model.ImageUploaded.InputStream, 600, true);

                        dtMeeting.imagePath = fileName + ".jpg";
                        serv.createMeeting(dtMeeting);
                        // get all meetings
                        DTMeetingsCol meetings = serv.getMeetingsList();

                        // close service
                        (serv as ICommunicationObject).Close();

                        // send the meetings to the model.
                        return View(HomeControllerConstants.viewMeetingsList, meetings);
                    }

                // If we got this far, something failed, redisplay form
                    return View(model);
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // configure movement.
        public ActionResult MovementConfig()
        {
            /*
            try
            {
                // check if the user is a movement admin.
                ISessionService serv1 = GetService<ISessionService>(HomeControllerConstants.urlSessionService);
                serv1.ValidateMovAdmin();
            */
                // show configuration
                IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                // get movement
                IndignadoWeb.MovAdminServiceReference.DTMovement movement = serv.getMovement();

                // close service
                (serv as ICommunicationObject).Close();

                // send the meeting to the model.
                SingleMovementModel model = new SingleMovementModel();
                model.name = movement.name;
                model.description = movement.description;
                model.locationLati = movement.locationLati;
                model.locationLong = movement.locationLong;

                return View(model);
            /*
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
            */
        }

        // configure movement.
        [HttpPost]
        public ActionResult MovementConfig(SingleMovementModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

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

                    // send the movements to the model.
                    return View("MovementConfigSuccess");
                }

                // If we got this far, something failed, redisplay form
                return View(model);
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // shows all news in a list.
        public ActionResult NewsList()
        {
            // open service
            INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

            // get all news
            DTRssItemsCol rssItemsCol = serv.getNewsList();

            return View(rssItemsCol);
        }

        // shows all resources in a list.
        public ActionResult ResourcesList()
        {
            // open service
            INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

            // get all news
            ListResourcesModel listResourcesModel = new ListResourcesModel();
            listResourcesModel.items = serv.getResourcesList();

            return View(listResourcesModel);
        }

        // like / dislike resource.
        [HttpPost]
        public ActionResult ResourcesList(string buttonLike, string buttonUnlike, int id)
        {
            try
            {
                if (buttonLike != null)
                {
                    // open service
                    INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                    // like resource
                    DTResource dtResource = new DTResource();
                    dtResource.id = id;
                    serv.likeResource(dtResource);

                    return RedirectToAction(HomeControllerConstants.viewResourcesList);
                }
            
                else if (buttonUnlike != null)
                {
                    // open service
                    INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                    // like resource
                    DTResource dtResource = new DTResource();
                    dtResource.id = id;
                    serv.unlikeResource(dtResource);

                    return RedirectToAction(HomeControllerConstants.viewResourcesList);
                }

                return View ();
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // create resource.
        public ActionResult ResourceShare(ShareResourceModel model)
        {
            /*
            try
            {
                // check if the user is a registered user.
                ISessionService serv = GetService<ISessionService>(HomeControllerConstants.urlSessionService);
                serv.ValidateRegUser();
            */

                // show form
                return View(model);
            /*
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
            */
        }

        // create resource.
        [HttpPost]
        public ActionResult ResourceShare(string buttonShare, string buttonGetData, ShareResourceModel model)
        {
            try {
                // button share
                if (buttonShare != null)
                {
                    if (ModelState.IsValid)
                    {
                        // open service
                        INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                        // create new meeting
                        DTResource dtResource = new DTResource();
                        dtResource.id = -1;
                        dtResource.idUser = -1;
                        dtResource.title = model.title;
                        dtResource.description = model.description;
                        dtResource.urlLink = model.urlLink;
                        dtResource.urlThumb = model.urlThumb;
                        dtResource.urlImage = model.urlImage;
                        dtResource.urlVideo = model.urlVideo;
                        serv.createResource(dtResource);

                        // open resources list view.
                        return RedirectToAction(HomeControllerConstants.viewResourcesList);
                    }

                    // If we got this far, something failed, redisplay form
                    return View(model);
                }

                // button get data from link
                else if (buttonGetData != null)
                {
                    // open service
                    INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);
                
                    // get data
                    DTResource dtResource = serv.getResourceData(model.urlLink);
                    model.title = dtResource.title;
                    model.description = dtResource.description;
                    model.urlThumb = dtResource.urlThumb;

                    // update data in view.
                    return RedirectToAction(HomeControllerConstants.viewResourceShare, model);
                }
            
                return View(model);
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }
        
        // configures the rss sources.
        public ActionResult RssSourcesConfig()
        {
            IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

            RssSourcesModel model = new RssSourcesModel();
            model.newItem = new DTRssSource();
            DTRssSourcesCol col = serv.listRssSources();
            model.items = col;

            return View(model);
        }

        // configures the rss sources.
        [HttpPost]
        public ActionResult RssSourcesConfig(string buttonAdd, string buttonRemove, RssSourcesModel model)
        {
            try
            {
                IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);
            
                // button Add
                if (buttonAdd != null)
                {
                    if (model.newItem != null)
                    {
                        serv.addRssSource(model.newItem);
                    }
                }

                // button Remove
                else if (buttonRemove != null)
                {
                    if (model.newItem != null)
                    {
                        serv.removeRssSource(model.newItem);
                    }
                }

                // show rss sources
                model.items = serv.listRssSources();

                return View(model);
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }
         
    }
}
