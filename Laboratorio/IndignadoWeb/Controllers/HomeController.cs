using System;
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
using IndignadoWeb.UsersServiceReference;
using System.Collections.Generic;

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
        public const string viewThemeCategoriesConfig = "ThemeCategoriesConfig";
        public const string viewThemeCategoriesList = "ThemeCategoriesList";

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
            try
            {
                // check if the user is a registered user.
                //IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);
            
                // initialize model
                CreateMeetingModel model = new CreateMeetingModel();
                //model.themeCategoriesMeeting = new DTThemeCategoriesColMeetings();
                //model.themeCategoriesMov = serv.getThemeCategoriesList();

                //SelectList codelist1 = new SelectList(;
                //SelectList codelist2 = new SelectList (serv.getThemeCategoriesList().items);

                /*

                model.themeCategoriesId = new List<string> ();

                DTThemeCategoriesColMeetings themeCats = serv.getThemeCategoriesList();

                model.themeCategories = new List<SelectListItem> ();
                foreach (DTThemeCategoryMeetings dtThemeCat in themeCats.items) {
                    model.themeCategories.Add(new SelectListItem {Value = dtThemeCat.id.ToString(), Text = dtThemeCat.title});
                }
                 * */

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

                        if (model.ImageUploaded != null)
                        {
                            string fileName = Guid.NewGuid().ToString();
                            string serverPath = Server.MapPath("~");
                            string imagesPath = serverPath + "Content\\Images\\";
                            string thumbPath = imagesPath + "Thumb\\";
                            string fullPath = imagesPath + "Full\\";
                
                            CreateMeetingModel.ResizeAndSave(thumbPath, fileName, model.ImageUploaded.InputStream, 80, true);
                            CreateMeetingModel.ResizeAndSave(fullPath, fileName, model.ImageUploaded.InputStream, 600, true);

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
        public ActionResult ResourcesList(string buttonLike, string buttonUnlike, /*string buttonMarkInappr, string buttonUnmarkInappr, */int id)
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

                    // close service
                    (serv as ICommunicationObject).Close();

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

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewResourcesList);
                }

                /*
                else if (buttonMarkInappr != null)
                {
                    // open service
                    INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                    // mark resource as inappropriate
                    DTResource dtResource = new DTResource();
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
                    DTResource dtResource = new DTResource();
                    dtResource.id = id;
                    serv.unmarkResourceInappropriate(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewResourcesList);
                }
                */

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
                    DTResource dtResource = serv.getResourceData(model.urlLink);
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
    }
}
