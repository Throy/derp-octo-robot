using System;
using System.Collections.ObjectModel;
using System.IO;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using IndignadoWeb.Common;
using IndignadoWeb.MeetingsServiceReference;
using IndignadoWeb.Models;
using IndignadoWeb.MovAdminServiceReference;
using IndignadoWeb.NewsResourcesServiceReference;
using IndignadoWeb.SessionServiceReference;
using IndignadoWeb.SysAdminServiceReference;
using IndignadoWeb.TestServiceReference;
using IndignadoWeb.UsersServiceReference;

namespace IndignadoWeb.Controllers
{
    public class HomeControllerConstants
    {
        public const string viewAccessDenied = "AccessDenied";
        public const string viewLogOn = "LogOn";
        public const string viewMeetingCreate = "MeetingCreate";
        public const string viewMeetingsList = "MeetingsList";
        public const string viewMeetingsListOnAttend = "MeetingsListOnAttend";
        public const string viewMeetingsListOnInterest = "MeetingsListOnInterest";
        public const string viewMeetingsMap = "MeetingsMap";
        public const string viewMovementConfig = "MovementConfig";
        public const string viewNewsList = "NewsList";
        public const string viewResourceShare = "ResourceShare";
        public const string viewResourcesList = "ResourcesList";
        public const string viewThemeCategoriesConfig = "ThemeCategoriesConfig";
        public const string viewThemeCategoriesList = "ThemeCategoriesList";
        public const string viewUserConfig = "UserConfig";
        public const string viewUserDetails = "UserDetails";
        public const string viewUsersManage = "UsersManage";
        public const string viewResourcesManage = "ResourcesManage";

        public const string urlMeetingsService = "http://localhost:8730/IndignadoServer/MeetingsService/";
        public const string urlMovAdminService = "http://localhost:8730/IndignadoServer/MovAdminService/";
        public const string urlNewsResourcesService = "http://localhost:8730/IndignadoServer/NewsResourcesService/";
        public const string urlSessionService = "http://localhost:8730/IndignadoServer/SessionService/";
        public const string urlSysAdminService = "http://localhost:8730/IndignadoServer/SysAdminService/";
        public const string urlUsersService = "http://localhost:8730/IndignadoServer/UsersService/";
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

            // show movement info
            IMovAdminService serv2 = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

            // get movement
            IndignadoWeb.MovAdminServiceReference.DTMovement movement = serv2.getMovement();

            // close service
            (serv2 as ICommunicationObject).Close();

            // send the meeting to the model.
            SingleMovementModel model = new SingleMovementModel();
            model.name = movement.name;
            model.description = movement.description;
            model.locationLati = movement.locationLati;
            model.locationLong = movement.locationLong;

            return View(model);
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
            // get movement
            IMovAdminService serv2 = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);
            IndignadoWeb.MovAdminServiceReference.DTMovement movement = serv2.getMovement();
            (serv2 as ICommunicationObject).Close();

            // open service
            IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

            // initialize model
            MeetingsMapModel model = new MeetingsMapModel();
            model.meetings = serv.getMeetingsList();
            model.locationLati = movement.locationLati;
            model.locationLong = movement.locationLong;

            // close service
            (serv as ICommunicationObject).Close();

            // send the meetings to the model.
            return View(model);
        }
        
        // shows all meetings - change attendance.
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

                    // close service
                    (serv as ICommunicationObject).Close();

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

                    // close service
                    (serv as ICommunicationObject).Close();

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

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewMeetingsList);
                }

                return View();
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // shows all meetings that the user will attend or didn't confirm.
        public ActionResult MeetingsListOnAttend()
        {
            try
            {
                // get user
                IUsersService serv2 = GetService<IUsersService>(HomeControllerConstants.urlUsersService);
                DTUser_Users user = serv2.getUser();
                (serv2 as ICommunicationObject).Close();

                // open service
                IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

                // initialize model
                MeetingsMapModel model = new MeetingsMapModel();
                model.meetings = serv.getMeetingsListOnAttend();
                model.locationLati = user.locationLati;
                model.locationLong = user.locationLong;

                // close service
                (serv as ICommunicationObject).Close();

                // send the meetings to the model.
                return View(model);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // shows all meetings that the user will attend or didn't confirm - change attendance.
        [HttpPost]
        public ActionResult MeetingsListOnAttend(string buttonDoAttend, string buttonDontAttend, string buttonUnconfirmAttendance, int id)
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

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewMeetingsListOnAttend);
                }

                else if (buttonDontAttend != null)
                {
                    // open service
                    IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

                    // don't attend
                    DTMeeting dtMeeting = new DTMeeting();
                    dtMeeting.id = id;
                    serv.dontAttendMeeting(dtMeeting);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewMeetingsListOnAttend);
                }

                else if (buttonUnconfirmAttendance != null)
                {
                    // open service
                    IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

                    // unconfirm attendance
                    DTMeeting dtMeeting = new DTMeeting();
                    dtMeeting.id = id;
                    serv.unconfirmAttendMeeting(dtMeeting);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewMeetingsListOnAttend);
                }

                return View();
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // shows all meetings that the user is interested in.
        public ActionResult MeetingsListOnInterest()
        {
            try
            {
                // get user
                IUsersService serv2 = GetService<IUsersService>(HomeControllerConstants.urlUsersService);
                DTUser_Users user = serv2.getUser();
                (serv2 as ICommunicationObject).Close();

                // open service
                IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

                // initialize model
                MeetingsMapModel model = new MeetingsMapModel();
                model.meetings = serv.getMeetingsListOnInterest();
                model.locationLati = user.locationLati;
                model.locationLong = user.locationLong;

                // close service
                (serv as ICommunicationObject).Close();

                // send the meetings to the model.
                return View(model);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // shows all meetings that the user is interested in - change attendance.
        [HttpPost]
        public ActionResult MeetingsListOnInterest(string buttonDoAttend, string buttonDontAttend, string buttonUnconfirmAttendance, int id)
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

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewMeetingsListOnInterest);
                }

                else if (buttonDontAttend != null)
                {
                    // open service
                    IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

                    // don't attend
                    DTMeeting dtMeeting = new DTMeeting();
                    dtMeeting.id = id;
                    serv.dontAttendMeeting(dtMeeting);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewMeetingsListOnInterest);
                }

                else if (buttonUnconfirmAttendance != null)
                {
                    // open service
                    IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

                    // unconfirm attendance
                    DTMeeting dtMeeting = new DTMeeting();
                    dtMeeting.id = id;
                    serv.unconfirmAttendMeeting(dtMeeting);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewMeetingsListOnInterest);
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
            // get movement
            IMovAdminService serv2 = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);
            IndignadoWeb.MovAdminServiceReference.DTMovement movement = serv2.getMovement();
            (serv2 as ICommunicationObject).Close();

            // open service
            IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

            // initialize model
            MeetingsMapModel model = new MeetingsMapModel();
            model.meetings = serv.getMeetingsListOnInterest();
            model.locationLati = movement.locationLati;
            model.locationLong = movement.locationLong;

            // close service
            (serv as ICommunicationObject).Close();

            // send the meetings to the model.
            return View(model);
        }

        public ActionResult ShowImage(String pathImg)
        {
            var file = Server.MapPath(pathImg);
            return File(file, "image/jpg", Path.GetFileName(file));
        }
        
        // create meeting.
        public ActionResult MeetingCreate()
        {
            try
            {
                // get movement
                IMovAdminService serv2 = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);
                IndignadoWeb.MovAdminServiceReference.DTMovement movement = serv2.getMovement();
            
                // initialize model
                CreateMeetingModel model = new CreateMeetingModel();
                model.dateBegin = DateTime.UtcNow.Date;
                model.dateEnd = DateTime.UtcNow.Date;
                model.hoursBegin = 0;
                model.hoursEnd = 0;
                model.minutesBegin = 0;
                model.minutesEnd = 0;
                model.locationLati = movement.locationLati;
                model.locationLong = movement.locationLong;

                // get theme categories
                model.themeCategoriesId = new Collection<int> ();

                IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);
                DTThemeCategoriesColMeetings themeCats = serv.getThemeCategoriesList();

                model.themeCategories = new Collection<SelectListItem>();
                foreach (DTThemeCategoryMeetings dtThemeCat in themeCats.items) {
                    model.themeCategories.Add(new SelectListItem {Value = dtThemeCat.id.ToString(), Text = dtThemeCat.title});
                }

                // show form
                return View(model);
            
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
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
                        && ModelState.IsValidField("locationLong") && ModelState.IsValidField("minQuorum")
                        && (model.hoursBegin >= 0) && (model.hoursBegin < 60)
                        && (model.hoursEnd >= 0) && (model.hoursEnd < 60)
                        && (model.minutesBegin >= 0) && (model.minutesBegin < 60)
                        && (model.minutesEnd >= 0) && (model.minutesEnd < 60)
                        && ((model.dateBegin < model.dateEnd) || ((model.dateBegin == model.dateEnd) && ((model.hoursBegin < model.hoursEnd) || (model.hoursBegin == model.hoursEnd) && (model.minutesBegin <= model.minutesEnd)))))
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
                        dtMeeting.dateBegin = new DateTime(model.dateBegin.Year, model.dateBegin.Month, model.dateBegin.Day, model.hoursBegin, model.minutesBegin, 0);
                        dtMeeting.dateEnd = new DateTime(model.dateEnd.Year, model.dateEnd.Month, model.dateEnd.Day, model.hoursEnd, model.minutesEnd, 0);
                            //model.date.ToString() + "-" + model.Hora.ToString() + ":" + model.Minutos.ToString(););
                        dtMeeting.minQuorum = model.minQuorum;

                        dtMeeting.themeCategories = new DTThemeCategoryMeetings[model.themeCategoriesId.Count];
                        for (int idx = 0; idx < model.themeCategoriesId.Count; idx += 1) {
                            int idThemeCat = model.themeCategoriesId [idx];
                            DTThemeCategoryMeetings dtThemeCat = new DTThemeCategoryMeetings();
                            dtThemeCat.id = idThemeCat;
                            dtMeeting.themeCategories[idx] = dtThemeCat;
                        }

                        if (model.ImageUploaded != null)
                        {
                            string fileName = Guid.NewGuid().ToString();
                            string serverPath = Server.MapPath("~");
                            string imagesPath = serverPath + "Content\\Images\\";
                            string thumbPath = imagesPath + "Thumb\\";
                            string fullPath = imagesPath + "Full\\";
                
                            CreateMeetingModel.ResizeAndSave(thumbPath, fileName, model.ImageUploaded.InputStream, 80, true);
                            CreateMeetingModel.ResizeAndSave(thumbPath, fileName + "_100", model.ImageUploaded.InputStream, 150, true);
                            CreateMeetingModel.ResizeAndSave(fullPath, fileName, model.ImageUploaded.InputStream, 300, true);

                            dtMeeting.imagePath = fileName + ".jpg";
                        }

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

                    // open service
                    ISysAdminService serv2 = GetService<ISysAdminService>(HomeControllerConstants.urlSysAdminService);

                    // close service
                    (serv2 as ICommunicationObject).Close();

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

            // close service
            (serv as ICommunicationObject).Close();

            return View(rssItemsCol);
        }

        // shows all resources in a list.
        public ActionResult ResourcesList()
        {
            try
            {
                // open service
                INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                // get all news
                ListResourcesModel listResourcesModel = new ListResourcesModel();
                listResourcesModel.items = serv.getResourcesList();

                // close service
                (serv as ICommunicationObject).Close();

                return View(listResourcesModel);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // like / dislike resource.
        [HttpPost]
        public ActionResult ResourcesList(string buttonLike, string buttonUnlike, string buttonMarkInappr, string buttonUnmarkInappr, int id)
        {
            try
            {
                if (buttonLike != null)
                {
                    // open service
                    INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                    // like resource
                    DTResource_NewsResources dtResource = new DTResource_NewsResources();
                    dtResource.id = id;
                    serv.likeResource(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewResourcesList);
                }
            
                else if (buttonUnlike != null)
                {
                    // open service
                    INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                    // like resource
                    DTResource_NewsResources dtResource = new DTResource_NewsResources();
                    dtResource.id = id;
                    serv.unlikeResource(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewResourcesList);
                }

                else if (buttonMarkInappr != null)
                {
                    // open service
                    INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                    // mark resource as inappropriate
                    DTResource_NewsResources dtResource = new DTResource_NewsResources();
                    dtResource.id = id;
                    serv.markResourceInappropriate(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewResourcesList);
                }

                else if (buttonUnmarkInappr != null)
                {
                    // open service
                    INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                    // unmark resource as inappropriate
                    DTResource_NewsResources dtResource = new DTResource_NewsResources();
                    dtResource.id = id;
                    serv.unmarkResourceInappropriate(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

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
                        DTResource_NewsResources dtResource = new DTResource_NewsResources();
                        dtResource.id = -1;
                        dtResource.idUser = -1;
                        dtResource.title = model.title;
                        dtResource.description = model.description;
                        dtResource.urlLink = model.urlLink;
                        dtResource.urlThumb = model.urlThumb;
                        dtResource.urlImage = model.urlImage;
                        dtResource.urlVideo = model.urlVideo;
                        serv.createResource(dtResource);

                        // close service
                        (serv as ICommunicationObject).Close();

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
                    DTResource_NewsResources dtResource = serv.getResourceData(model.urlLink);
                    model.title = dtResource.title;
                    model.description = dtResource.description;
                    model.urlThumb = dtResource.urlThumb;

                    // close service
                    (serv as ICommunicationObject).Close();

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
            // open service
            IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

            // initialize model
            RssSourcesModel model = new RssSourcesModel();
            model.newItem = new DTRssSource();
            model.items = serv.listRssSources();

            // close service
            (serv as ICommunicationObject).Close();

            return View(model);
        }

        // configures the rss sources.
        [HttpPost]
        public ActionResult RssSourcesConfig(string buttonAdd, string buttonRemove, RssSourcesModel model)
        {
            try
            {
                // open service
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

                // close service
                (serv as ICommunicationObject).Close();

                return View(model);
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }
        

        // configures the theme categories.
        public ActionResult ThemeCategoriesConfig()
        {
            IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

            // initialize model
            ThemeCategoriesConfigModel model = new ThemeCategoriesConfigModel();
            model.newItem = new DTThemeCategoryMovAdmin();
            model.items = serv.listThemeCategories();

            // close service
            (serv as ICommunicationObject).Close();

            // send the meetings to the model.
            return View(model);
        }

        // configures the theme categories.
        [HttpPost]
        public ActionResult ThemeCategoriesConfig(string buttonAdd, string buttonRemove, string buttonImInterested, string buttonNotInterested, ThemeCategoriesConfigModel model, int id)
        {
            try
            {
                // open service
                IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                // button Add
                if (buttonAdd != null)
                {
                    // add theme category
                    if (model.newItem != null)
                    {
                        serv.addThemeCategory(model.newItem);
                    }

                    // show theme categories
                    model.items = serv.listThemeCategories();
                }

                // button Remove
                else if (buttonRemove != null)
                {
                    // remove theme category
                    DTThemeCategoryMovAdmin dtThemeCategory = new DTThemeCategoryMovAdmin();
                    dtThemeCategory.id = id;
                    serv.removeThemeCategory(dtThemeCategory);

                    // show theme categories
                    model.items = serv.listThemeCategories();
                }

                // close service
                (serv as ICommunicationObject).Close();

                return View(model);
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }


        // shows all theme categories in a list.
        public ActionResult ThemeCategoriesList()
        {
            IUsersService serv = GetService<IUsersService>(HomeControllerConstants.urlUsersService);

            // initialize model
            ThemeCategoriesListModel model = new ThemeCategoriesListModel();
            model.newItem = new DTThemeCategoryUsers();
            model.items = serv.getThemeCategoriesList();

            // close service
            (serv as ICommunicationObject).Close();

            // send the meetings to the model.
            return View(model);
        }

        // shows all theme categories in a list
        [HttpPost]
        public ActionResult ThemeCategoriesList(string buttonAdd, string buttonRemove, string buttonImInterested, string buttonNotInterested, ThemeCategoriesConfigModel model, int id)
        {
            try
            {
                // open service
                IUsersService serv = GetService<IUsersService>(HomeControllerConstants.urlUsersService);

                // button ImInterested
                if (buttonImInterested != null)
                {
                    // get interested
                    DTThemeCategoryUsers dtThemeCategory = new DTThemeCategoryUsers();
                    dtThemeCategory.id = id;
                    serv.getInterestedThemeCategory(dtThemeCategory);
                }

                // button NotInterested
                else if (buttonNotInterested != null)
                {
                    // get interested
                    DTThemeCategoryUsers dtThemeCategory = new DTThemeCategoryUsers();
                    dtThemeCategory.id = id;
                    serv.getUninterestedThemeCategory(dtThemeCategory);
                }

                // close service
                (serv as ICommunicationObject).Close();

                return RedirectToAction(HomeControllerConstants.viewThemeCategoriesList);
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // manages the users.
        public ActionResult UsersManage(UsersModel model, int? listType)
        {
            try
            {
                IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                // get allowed users
                if (listType == 1)
                {
                    model.listType = 1;
                    model.users = serv.getUsersListAllowed();
                }

                // get banned users
                else if (listType == 2)
                {
                    model.listType = 2;
                    model.users = serv.getUsersListBanned();
                }

                // get everyone
                else
                {
                    model.listType = 0;
                    model.users = serv.getUsersListFull();
                }

                // close service
                (serv as ICommunicationObject).Close();

                // send the users to the model.
                return View(model);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // manages the users - ban / reallow user.
        [HttpPost]
        public ActionResult UsersManage(string buttonShowEveryone, string buttonShowAllowed, string buttonShowBanned, string buttonBan, string buttonReallow, int id)
        {
            try
            {
                // show everyone.
                if (buttonShowEveryone != null)
                {
                    return RedirectToAction(HomeControllerConstants.viewUsersManage, new { listType = 0 });
                }

                // show allowed users.
                else if (buttonShowAllowed != null)
                {
                    return RedirectToAction(HomeControllerConstants.viewUsersManage, new { listType = 1 });
                }

                // show banned users.
                else if (buttonShowBanned != null)
                {
                    return RedirectToAction(HomeControllerConstants.viewUsersManage, new { listType = 2 });
                }

                // ban user
                else if (buttonBan != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                    // ban user
                    DTUser_MovAdmin dtUser = new DTUser_MovAdmin();
                    dtUser.id = id;
                    serv.banUser(dtUser);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewUsersManage);
                }

                // reallow user
                else if (buttonReallow != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                    // ban user
                    DTUser_MovAdmin dtUser = new DTUser_MovAdmin();
                    dtUser.id = id;
                    serv.reallowUser(dtUser);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewUsersManage);
                }

                return View();
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // configure user.
        public ActionResult UserConfig()
        {
            // show configuration
            IUsersService serv = GetService<IUsersService>(HomeControllerConstants.urlUsersService);

            // get movement
            DTUser_Users movement = serv.getUser();

            // close service
            (serv as ICommunicationObject).Close();

            // send the meeting to the model.
            UserConfigModel model = new UserConfigModel();
            model.fullName = movement.fullName;
            model.mail = movement.mail;
            model.locationLati = movement.locationLati;
            model.locationLong = movement.locationLong;

            return View(model);
        }

        // configure user.
        [HttpPost]
        public ActionResult UserConfig(UserConfigModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // open service
                    IUsersService serv = GetService<IUsersService>(HomeControllerConstants.urlUsersService);

                    // update user config
                    DTUser_Users dtUser = new DTUser_Users();
                    dtUser.fullName = model.fullName;
                    dtUser.mail = model.mail;
                    dtUser.locationLati = model.locationLati;
                    dtUser.locationLong = model.locationLong;
                    serv.setUser(dtUser);

                    // close service
                    (serv as ICommunicationObject).Close();

                    // send the movements to the model.
                    return View(model);
                }

                // If we got this far, something failed, redisplay form
                return RedirectToAction(HomeControllerConstants.viewUserConfig);
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // manages the resources.
        public ActionResult ResourcesManage(ManageResourcesModel model, int? listType)
        {
            try
            {
                IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                // get enabled resources
                if (listType == 1)
                {
                    model.listType = 1;
                    model.resources = serv.getResourcesListEnabled();
                }

                // get disabled resources
                else if (listType == 2)
                {
                    model.listType = 2;
                    model.resources = serv.getResourcesListDisabled();
                }

                // get all resources
                else
                {
                    model.listType = 0;
                    model.resources = serv.getResourcesListAll();
                }

                // close service
                (serv as ICommunicationObject).Close();

                // send the users to the model.
                return View(model);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // manages the users - ban / reallow user.
        [HttpPost]
        public ActionResult ResourcesManage(string buttonShowAll, string buttonShowEnabled, string buttonShowDisabled, string buttonDisable, string buttonEnable, int id)
        {
            try
            {
                // show everyone.
                if (buttonShowAll != null)
                {
                    return RedirectToAction(HomeControllerConstants.viewResourcesManage, new { listType = 0 });
                }

                // show enabled resources.
                else if (buttonShowEnabled != null)
                {
                    return RedirectToAction(HomeControllerConstants.viewResourcesManage, new { listType = 1 });
                }

                // show disabled resources.
                else if (buttonShowDisabled != null)
                {
                    return RedirectToAction(HomeControllerConstants.viewResourcesManage, new { listType = 2 });
                }

                // disable resource
                else if (buttonDisable != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                    // ban user
                    DTResource_MovAdmin dtResource = new DTResource_MovAdmin();
                    dtResource.id = id;
                    serv.disableResource(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewResourcesManage);
                }

                // enable resource
                else if (buttonEnable != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                    // ban user
                    DTResource_MovAdmin dtResource = new DTResource_MovAdmin();
                    dtResource.id = id;
                    serv.enableResource(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewResourcesManage);
                }

                return View();
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // shows the user details.
        public ActionResult UserDetails(UserDetailsModel model, int? id)
        {
            try
            {
                IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                if ((model.userId == 0) && (id.HasValue))
                {
                    model.userId = id.Value;
                }

                // get user details.
                DTUser_MovAdmin dtUser = new DTUser_MovAdmin();
                dtUser.id = model.userId;
                model.userDetails = serv.getUserDetails(dtUser);

                // close service
                (serv as ICommunicationObject).Close();

                // send the users to the model.
                return View(model);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // shows the user details - ban / reallow user, disable / enable resource.
        [HttpPost]
        public ActionResult UserDetails(string buttonBan, string buttonReallow, string buttonDisable, string buttonEnable, UserDetailsModel model, int id)
        {
            try
            {
                // ban user
                if (buttonBan != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                    // ban user
                    DTUser_MovAdmin dtUser = new DTUser_MovAdmin();
                    dtUser.id = id;
                    serv.banUser(dtUser);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewUserDetails, new { id = id });
                }

                // reallow user
                else if (buttonReallow != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                    // ban user
                    DTUser_MovAdmin dtUser = new DTUser_MovAdmin();
                    dtUser.id = id;
                    serv.reallowUser(dtUser);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewUserDetails, new { id = id });
                }

                // disable resource
                else if (buttonDisable != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                    // ban user
                    DTResource_MovAdmin dtResource = new DTResource_MovAdmin();
                    dtResource.id = id;
                    serv.disableResource(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewUserDetails, new { id = model.userId });
                }

                // enable resource
                else if (buttonEnable != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(HomeControllerConstants.urlMovAdminService);

                    // enable resource
                    DTResource_MovAdmin dtResource = new DTResource_MovAdmin();
                    dtResource.id = id;
                    serv.enableResource(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewUserDetails, new { id = model.userId });
                }

                return View(model);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }
    }
}
