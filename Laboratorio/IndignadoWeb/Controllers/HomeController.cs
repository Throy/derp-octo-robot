using System;
using System.Collections.ObjectModel;
using System.IO;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using IndignadoWeb.Common;
using IndignadoWeb.MeetingsServiceReference;
using IndignadoWeb.Models;
using IndignadoWeb.NewsResourcesServiceReference;
using IndignadoWeb.SessionServiceReference;
using IndignadoWeb.UsersServiceReference;
using System.Collections.Generic;
using System.Linq;
using IndignadoWeb.MovAdminServiceReference;

namespace IndignadoWeb.Controllers
{
    public static class ListsHelper
    {

        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<DTLayout> layouts, int selectedId)
        {
            return
                layouts.Select(layout =>
                          new SelectListItem
                          {
                              Selected = (layout.id == selectedId),
                              Text = layout.name,
                              Value = layout.id.ToString()
                          });
        }
    }


    public class HomeControllerConstants
    {
        public const string viewAccessDenied = "AccessDenied";
        public const string viewLogOn = "LogOn";
        public const string viewIndex = "Index";
        public const string viewMeetingCreate = "MeetingCreate";
        public const string viewMeetingsList = "MeetingsList";
        public const string viewMeetingsListOnAttend = "MeetingsListOnAttend";
        public const string viewMeetingsListOnInterest = "MeetingsListOnInterest";
        public const string viewMeetingsNotificationsList = "MeetingsNotificationsList";
        public const string viewNewsList = "NewsList";
        public const string viewResourceShare = "ResourceShare";
        public const string viewResourcesList = "ResourcesList";
        public const string viewResourcesListTopRanked = "ResourcesListTopRanked";
        public const string viewResourcesListUser = "ResourcesListUser";
        public const string viewThemeCategoriesList = "ThemeCategoriesList";
        public const string viewUserConfig = "UserConfig";
        public const string viewUserDetails = "UserDetails";

        public const string urlIndignadoServer = "http://localhost:8730/IndignadoServer";
        public const string urlMeetingsService = urlIndignadoServer + "/MeetingsService/";
        public const string urlNewsResourcesService = urlIndignadoServer + "/NewsResourcesService/";
        public const string urlSessionService = urlIndignadoServer + "/SessionService/";
        public const string urlSysAdminService = urlIndignadoServer + "/SysAdminService/";
        public const string urlUsersService = urlIndignadoServer + "/UsersService/";
        public const string urlTestService = urlIndignadoServer + "/TestService/";
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

        // index
        public ActionResult Index(DTTenantInfo tenantInfo)
        {
            // get movement info
            IUsersService serv2 = GetService<IUsersService>(HomeControllerConstants.urlUsersService);
            IndignadoWeb.UsersServiceReference.DTMovement movement = serv2.getMovement();
            (serv2 as ICommunicationObject).Close();

            // open service
            INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

            // send the meeting to the model.
            HomeModel model = new HomeModel();
            model.movement = movement;
            model.resources = serv.getResourcesList(1);

            // close service
            (serv as ICommunicationObject).Close();

            // open service
            IMeetingsService serv3 = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

            // add the meetings and central location to the model
            model.meetings = new MeetingsMapModel();
            model.meetings.meetings = serv3.getMeetingsList();
            model.meetings.locationLati = movement.locationLati;
            model.meetings.locationLong = movement.locationLong;

            // close service
            (serv3 as ICommunicationObject).Close();

            return View(model);
        }

        // index - change meeting attendance, like / unlike resource, mark / unmark resource as inappropriate.
        [HttpPost]
        public ActionResult Index(string buttonDoAttend, string buttonDontAttend, string buttonUnconfirmAttendance,
            string buttonLike, string buttonUnlike, string buttonMarkInappr, string buttonUnmarkInappr, string buttonRemove, 
            int id)
        {
            // meetings
            if ((buttonDoAttend != null) || (buttonDontAttend != null) || (buttonUnconfirmAttendance != null))
            {
                return meetingChangeAttendance(buttonDoAttend, buttonDontAttend, buttonUnconfirmAttendance, id, HomeControllerConstants.viewIndex);
            }

            // resources
            else
            {
                return ResourcesListGeneric(buttonLike, buttonUnlike, buttonMarkInappr, buttonUnmarkInappr, buttonRemove, id, HomeControllerConstants.viewIndex);
            }
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        // shows all meetings.
        public ActionResult MeetingsList()
        {
            // get movement
            IUsersService serv2 = GetService<IUsersService>(HomeControllerConstants.urlUsersService);
            IndignadoWeb.UsersServiceReference.DTMovement movement = serv2.getMovement();
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

        // shows all meetings - change attendance.
        [HttpPost]
        public ActionResult MeetingsList(string buttonDoAttend, string buttonDontAttend, string buttonUnconfirmAttendance, int id)
        {
            return meetingChangeAttendance(buttonDoAttend, buttonDontAttend, buttonUnconfirmAttendance, id, HomeControllerConstants.viewMeetingsList);
        }

        // shows all meetings that the user will attend or didn't confirm - change attendance.
        [HttpPost]
        public ActionResult MeetingsListOnAttend(string buttonDoAttend, string buttonDontAttend, string buttonUnconfirmAttendance, int id)
        {
            return meetingChangeAttendance(buttonDoAttend, buttonDontAttend, buttonUnconfirmAttendance, id, HomeControllerConstants.viewMeetingsListOnAttend);
        }

        // shows all meetings that the user is interested in - change attendance.
        [HttpPost]
        public ActionResult MeetingsListOnInterest(string buttonDoAttend, string buttonDontAttend, string buttonUnconfirmAttendance, int id)
        {
            return meetingChangeAttendance(buttonDoAttend, buttonDontAttend, buttonUnconfirmAttendance, id, HomeControllerConstants.viewMeetingsListOnInterest);
        }

        // meetings - change attendance.
        public ActionResult meetingChangeAttendance(string buttonDoAttend, string buttonDontAttend, string buttonUnconfirmAttendance, int id, string view)
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

                    // reload the view
                    return RedirectToAction(view);
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

                    // reload the view
                    return RedirectToAction(view);
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

                    // reload the view
                    return RedirectToAction(view);
                }

                return View();
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // shows all meetings that the user has been notified.
        public ActionResult MeetingsNotificationsList()
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
                MeetingsNotificationsMapModel model = new MeetingsNotificationsMapModel();
                model.meetingsNotifications = serv.getMeetingsNotifications();
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

        // shows all meetings that the user has been notified - change attendance.
        [HttpPost]
        public ActionResult MeetingsNotificationsList(string buttonDoAttend, string buttonDontAttend, string buttonUnconfirmAttendance, string buttonRemove, int id)
        {
            try
            {
                // remove meeteing notification
                if (buttonRemove != null)
                {
                    // open service
                    IMeetingsService serv = GetService<IMeetingsService>(HomeControllerConstants.urlMeetingsService);

                    // remove meeting
                    DTMeeting dtMeeting = new DTMeeting();
                    dtMeeting.id = id;
                    serv.deleteMeetingNotification(dtMeeting);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(HomeControllerConstants.viewMeetingsNotificationsList);
                }

                else
                {
                    return meetingChangeAttendance(buttonDoAttend, buttonDontAttend, buttonUnconfirmAttendance, id, HomeControllerConstants.viewMeetingsNotificationsList);
                }
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
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
                IUsersService servValidate = GetService<IUsersService>(HomeControllerConstants.urlUsersService);
                DTUser_Users dtUser = servValidate.getUser();
                (servValidate as ICommunicationObject).Close();

                // get movement
                IUsersService serv2 = GetService<IUsersService>(HomeControllerConstants.urlUsersService);
                IndignadoWeb.UsersServiceReference.DTMovement movement = serv2.getMovement();
                (serv2 as ICommunicationObject).Close();
            
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

                        if (model.themeCategoriesId == null)
                            dtMeeting.themeCategories = null;
                        else
                        {
                            dtMeeting.themeCategories = new DTThemeCategoryMeetings[model.themeCategoriesId.Count];
                            for (int idx = 0; idx < model.themeCategoriesId.Count; idx += 1)
                            {
                                int idThemeCat = model.themeCategoriesId[idx];
                                DTThemeCategoryMeetings dtThemeCat = new DTThemeCategoryMeetings();
                                dtThemeCat.id = idThemeCat;
                                dtMeeting.themeCategories[idx] = dtThemeCat;
                            }
                        }
                        if (model.ImageUploaded != null)
                        {
                            string fileName = Guid.NewGuid().ToString();
                            string serverPath = Server.MapPath("~");
                            string imagesPath = serverPath + "Content\\Images\\";
                            string thumbPath = imagesPath + "Thumb\\";
                            string fullPath = imagesPath + "Full\\";
                
                            CreateMeetingModel.ResizeAndSave(thumbPath, fileName, model.ImageUploaded.InputStream, 80, true);
                            CreateMeetingModel.ResizeAndSave(thumbPath, fileName + "_90", model.ImageUploaded.InputStream, 90, true);
                            CreateMeetingModel.ResizeAndSave(fullPath, fileName, model.ImageUploaded.InputStream, 300, true);

                            dtMeeting.imagePath = fileName + ".jpg";
                        }

                        serv.createMeeting(dtMeeting);

                        // get all meetings
                        DTMeetingsCol meetings = serv.getMeetingsList();

                        // close service
                        (serv as ICommunicationObject).Close();

                        // show the meetings list
                        return RedirectToAction(HomeControllerConstants.viewMeetingsList);
                    }

                // If we got this far, something failed, redisplay form
                    return View(model);
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // shows all news in a list.
        //[OutputCache(Duration = 180, VaryByParam = "none")]
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
        public ActionResult ResourcesList(ListResourcesModel listResourcesModel)
        {
            try
            {
                // open service
                INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                // get all news
                int currentPage = listResourcesModel.id;
                listResourcesModel = new ListResourcesModel();
                listResourcesModel.itemsList = serv.getResourcesList(currentPage);

                // close service
                (serv as ICommunicationObject).Close();

                return View(listResourcesModel);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // shows the top ranked resources in a list.
        public ActionResult ResourcesListTopRanked(ListResourcesModel listResourcesModel)
        {
            try
            {
                // open service
                INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                // get all news
                int currentPage = listResourcesModel.id;
                listResourcesModel = new ListResourcesModel();
                listResourcesModel.itemsList = serv.getResourcesListTopRanked(currentPage);

                // close service
                (serv as ICommunicationObject).Close();

                return View(listResourcesModel);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // shows the user's resources in a list.
        public ActionResult ResourcesListUser(int id, int currentPage)
        {
            try
            {
                // open service
                INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                // get all news
                ListResourcesModel listResourcesModel = new ListResourcesModel();
                DTUser_NewsResources dtUser = new DTUser_NewsResources();
                dtUser.id = id;
                DTUserDetails_NewsResources userDetails = serv.getUserDetails(dtUser, currentPage);
                listResourcesModel.itemsList = userDetails.resources;
                listResourcesModel.id = userDetails.user.id;
                listResourcesModel.username = userDetails.user.username;

                // close service
                (serv as ICommunicationObject).Close();

                return View(listResourcesModel);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // shows all resources in a list - respond to user action.
        [HttpPost]
        public ActionResult ResourcesList(string buttonLike, string buttonUnlike,
            string buttonMarkInappr, string buttonUnmarkInappr, string buttonRemove, int id)
        {
            return ResourcesListGeneric(buttonLike, buttonUnlike, buttonMarkInappr, buttonUnmarkInappr, buttonRemove, id, HomeControllerConstants.viewResourcesList);
        }

        // shows the top ranked resources in a list - respond to user action.
        [HttpPost]
        public ActionResult ResourcesListTopRanked(string buttonLike, string buttonUnlike,
            string buttonMarkInappr, string buttonUnmarkInappr, string buttonRemove, int id)
        {
            return ResourcesListGeneric(buttonLike, buttonUnlike, buttonMarkInappr, buttonUnmarkInappr, buttonRemove, id, HomeControllerConstants.viewResourcesListTopRanked);
        }

        // shows the user's resources in a list - respond to user action.
        [HttpPost]
        public ActionResult ResourcesListUser(string buttonLike, string buttonUnlike,
            string buttonMarkInappr, string buttonUnmarkInappr, string buttonRemove, int id)
        {
            return ResourcesListGeneric(buttonLike, buttonUnlike, buttonMarkInappr, buttonUnmarkInappr, buttonRemove, id, HomeControllerConstants.viewResourcesListUser);
        }

        // like / dislike resource.
        [HttpPost]
        public ActionResult ResourceLike(string like, string id)
        {
            if (like == "0")
            {
                // open service
                INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                // like resource
                DTResource_NewsResources dtResource = new DTResource_NewsResources();
                dtResource.id = int.Parse(id);
                serv.likeResource(dtResource);

                // close service
                (serv as ICommunicationObject).Close();

                return Content("exito");
            }
            else 
            {
                INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                // like resource
                DTResource_NewsResources dtResource = new DTResource_NewsResources();
                dtResource.id = int.Parse(id);
                serv.unlikeResource(dtResource);

                // close service
                (serv as ICommunicationObject).Close();

                return Content("exito"); ;
            }
            
        }

        // like / dislike resource.
        public ActionResult ResourcesListGeneric(string buttonLike, string buttonUnlike,
            string buttonMarkInappr, string buttonUnmarkInappr, string buttonRemove, int id, string view)
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

                    // reload the view
                    return RedirectToAction(view);
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

                    // reload the view
                    return RedirectToAction(view);
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

                    // reload the view
                    return RedirectToAction(view);
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
                    
                    // reload the view
                    return RedirectToAction(view);
                }

                else if (buttonRemove != null)
                {
                    // open service
                    INewsResourcesService serv = GetService<INewsResourcesService>(HomeControllerConstants.urlNewsResourcesService);

                    // remove resource by the user
                    DTResource_NewsResources dtResource = new DTResource_NewsResources();
                    dtResource.id = id;
                    serv.removeResource(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    // reload the view
                    return RedirectToAction(view);
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
            try{
                // check if the user is a registered user.
                IUsersService servValidate = GetService<IUsersService>(HomeControllerConstants.urlUsersService);
                DTUser_Users dtUser = servValidate.getUser();
                (servValidate as ICommunicationObject).Close();

                // show form
                return View();
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
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
                else if (buttonGetData != null && model.urlLink != null)
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

        // shows all theme categories in a list.
        public ActionResult ThemeCategoriesList()
        {
            try
            {
                // check if the user is a registered user.
                IUsersService servValidate = GetService<IUsersService>(HomeControllerConstants.urlUsersService);
                DTUser_Users dtUser = servValidate.getUser();
                (servValidate as ICommunicationObject).Close();

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
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // shows all theme categories in a list
        [HttpPost]
        public ActionResult ThemeCategoriesList(string buttonImInterested, int id)
        {
            try
            {
                // open service
                IUsersService serv = GetService<IUsersService>(HomeControllerConstants.urlUsersService);

                // button ImInterested
                if (buttonImInterested.CompareTo("buttonImInterested")==0)
                {
                    // get interested
                    DTThemeCategoryUsers dtThemeCategory = new DTThemeCategoryUsers();
                    dtThemeCategory.id = id;
                    serv.getInterestedThemeCategory(dtThemeCategory);
                }

                // button NotInterested
                else
                {
                    // get interested
                    DTThemeCategoryUsers dtThemeCategory = new DTThemeCategoryUsers();
                    dtThemeCategory.id = id;
                    serv.getUninterestedThemeCategory(dtThemeCategory);
                }

                // close service
                (serv as ICommunicationObject).Close();

                return Content("exito");
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
        }

        // configure user.
        public ActionResult UserConfig()
        {
            try{
                // show configuration
                IUsersService serv = GetService<IUsersService>(HomeControllerConstants.urlUsersService);

                // get movement
                DTUser_Users user = serv.getUser();

                // close service
                (serv as ICommunicationObject).Close();

                // send the user to the model.
                UserConfigModel model = new UserConfigModel();
                model.fullName = user.fullName;
                model.mail = user.mail;
                model.locationLati = user.locationLati;
                model.locationLong = user.locationLong;

                return View(model);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewLogOn, "Account");
            }
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
    }
}
