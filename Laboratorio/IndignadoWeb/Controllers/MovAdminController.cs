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
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace IndignadoWeb.Controllers
{
    public class MovAdminControllerConstants
    {
        public const string viewMovementConfig = "MovementConfig";
        public const string viewResourcesManage = "ResourcesManage";
        public const string viewRssSourcesConfig = "RssSourcesConfig";
        public const string viewThemeCategoriesConfig = "ThemeCategoriesConfig";
        public const string viewUserDetails = "UserDetails";
        public const string viewUsersManage = "UsersManage";
        public const string viewUsersRegisterReport = "UsersRegisterReport";

        public const string urlIndignadoServer = "http://localhost:8730/IndignadoServer";
        public const string urlMovAdminService = urlIndignadoServer + "/MovAdminService/";
    }


    [MultiTenanActionFilter]
    public class MovAdminController : Controller
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

        // configure movement.
        public ActionResult MovementConfig()
        {
            try
            {
                // get movement configuration
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);
                IndignadoWeb.MovAdminServiceReference.DTMovement movement = serv.getMovement();


                // send the meeting to the model.
                SingleMovementModel model = new SingleMovementModel();
                model.name = movement.name;
                model.description = movement.description;
                model.locationLati = movement.locationLati;
                model.locationLong = movement.locationLong;
                model.layouts = serv.getLayouts().ToSelectListItems(movement.idLayout);
                model.maxMarcasInadecuadasRecursoX = movement.maxMarcasInadecuadasRecursoX;
                model.maxRecursosInadecuadosUsuarioZ = movement.maxRecursosInadecuadosUsuarioZ;
                model.maxRecursosPopularesN = movement.maxRecursosPopularesN;
                model.maxUltimosRecursosM = movement.maxUltimosRecursosM;

                (serv as ICommunicationObject).Close();

                return View(model);
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // configure movement.
        [HttpPost]
        public ActionResult MovementConfig(SingleMovementModel model)
        {
            try
            {
                // open service
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                if (ModelState.IsValidField("description") && ModelState.IsValidField("name") && ModelState.IsValidField("locationLati")
                    && ModelState.IsValidField("locationLong") && ModelState.IsValidField("layoutId"))
                {


                    // create new movement
                    //serv.addEmptyMovement();

                    IndignadoWeb.MovAdminServiceReference.DTMovement dtMovement = new IndignadoWeb.MovAdminServiceReference.DTMovement();
                    dtMovement.id = -1;
                    dtMovement.name = model.name;
                    dtMovement.description = model.description;
                    dtMovement.locationLati = model.locationLati;
                    dtMovement.locationLong = model.locationLong;
                    dtMovement.idLayout = model.layoutId;
                    if (model.ImageU != null)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        string serverPath = Server.MapPath("~");
                        string imagesPath = serverPath + "Content\\Images\\";
                        string thumbPath = imagesPath + "Thumb\\";
                        string fullPath = imagesPath + "Full\\";

                        CreateMeetingModel.ResizeAndSave(thumbPath, fileName, model.ImageU.InputStream, 170, false);

                        dtMovement.imagePath = fileName + ".jpg";
                    }
                    else
                    {
                        dtMovement.imagePath = null;
                    }
                    dtMovement.maxMarcasInadecuadasRecursoX = model.maxMarcasInadecuadasRecursoX;
                    dtMovement.maxRecursosInadecuadosUsuarioZ = model.maxRecursosInadecuadosUsuarioZ;
                    dtMovement.maxRecursosPopularesN = model.maxRecursosPopularesN;
                    dtMovement.maxUltimosRecursosM = model.maxUltimosRecursosM;


                    serv.setMovement(dtMovement);

                    // close service
                    (serv as ICommunicationObject).Close();

                    // send the movements to the model.
                    return RedirectToAction("MovementConfigSuccess");
                }

                // Vuelvo a rellenar la lista de layouts
                model.layouts = serv.getLayouts().ToSelectListItems(model.layoutId);

                // close service
                (serv as ICommunicationObject).Close();


                // If we got this far, something failed, redisplay form
                return View(model);
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        public ActionResult MovementConfigSuccess()
        {
            return View("MovementConfigSuccess");
        }

        // configures the rss sources.
        public ActionResult RssSourcesConfig()
        {
            try
            {
                // open service
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                // initialize model
                RssSourcesModel model = new RssSourcesModel();
                model.newItem = new DTRssSource();
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

        // configures the rss sources.
        [HttpPost]
        public ActionResult RssSourcesConfig(string buttonAdd, RssSourcesModel model, string url, string tag)
        {
            try
            {
                // open service
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                // button Add
                if (buttonAdd != null)
                {
                    if (model.newItem != null)
                    {
                        serv.addRssSource(model.newItem);
                    }
                }

                // show rss sources
                return RedirectToAction(MovAdminControllerConstants.viewRssSourcesConfig);
            }
            catch
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        public ActionResult RemoveRssSource(string url, string tag)
        {
            IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);
            try
            {
                DTRssSource dtRssSource = new DTRssSource();
                dtRssSource.url = url;
                dtRssSource.tag = tag;
                serv.removeRssSource(dtRssSource);
                return Content("exito");
            }
            catch
            {
                return Content("The RSS source cannot be removed.");
            }
        }

        // configures the theme categories.
        public ActionResult ThemeCategoriesConfig()
        {
            IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

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
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

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

        [HttpPost]
        public ActionResult RemoveThemeCategory(int id)
        {
            try
            {
                // open service
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);
                string retorno = "";
                // button Remove
                if (id != null)
                {
                    // remove theme category
                    DTThemeCategoryMovAdmin dtThemeCategory = new DTThemeCategoryMovAdmin();
                    dtThemeCategory.id = id;
                    if (serv.removeThemeCategory(dtThemeCategory))
                        retorno = "exito";
                    else
                        retorno = "The theme category has dependences, so it cannot be removed.";
                }
                else
                    retorno = "The theme category cannot be removed.";

                // close service
                (serv as ICommunicationObject).Close();
                return Content(retorno);

            }
            catch
            {
                return Content("The theme category cannot be removed.");
            }
        }


        // manages the resources.
        public ActionResult ResourcesManage(ManageResourcesModel model, int? listType)
        {
            try
            {
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

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
                    return RedirectToAction(MovAdminControllerConstants.viewResourcesManage, new { listType = 0 });
                }

                // show enabled resources.
                else if (buttonShowEnabled != null)
                {
                    return RedirectToAction(MovAdminControllerConstants.viewResourcesManage, new { listType = 1 });
                }

                // show disabled resources.
                else if (buttonShowDisabled != null)
                {
                    return RedirectToAction(MovAdminControllerConstants.viewResourcesManage, new { listType = 2 });
                }

                // disable resource
                else if (buttonDisable != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                    // ban user
                    DTResource_MovAdmin dtResource = new DTResource_MovAdmin();
                    dtResource.id = id;
                    serv.disableResource(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(MovAdminControllerConstants.viewResourcesManage);
                }

                // enable resource
                else if (buttonEnable != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                    // ban user
                    DTResource_MovAdmin dtResource = new DTResource_MovAdmin();
                    dtResource.id = id;
                    serv.enableResource(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(MovAdminControllerConstants.viewResourcesManage);
                }

                return View();
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // manages the users.
        public ActionResult UsersManage(UsersModel model, int? listType)
        {
            try
            {
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

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
                    return RedirectToAction(MovAdminControllerConstants.viewUsersManage, new { listType = 0 });
                }

                // show allowed users.
                else if (buttonShowAllowed != null)
                {
                    return RedirectToAction(MovAdminControllerConstants.viewUsersManage, new { listType = 1 });
                }

                // show banned users.
                else if (buttonShowBanned != null)
                {
                    return RedirectToAction(MovAdminControllerConstants.viewUsersManage, new { listType = 2 });
                }

                // ban user
                else if (buttonBan != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                    // ban user
                    DTUser_MovAdmin dtUser = new DTUser_MovAdmin();
                    dtUser.id = id;
                    serv.banUser(dtUser);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(MovAdminControllerConstants.viewUsersManage);
                }

                // reallow user
                else if (buttonReallow != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                    // ban user
                    DTUser_MovAdmin dtUser = new DTUser_MovAdmin();
                    dtUser.id = id;
                    serv.reallowUser(dtUser);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(MovAdminControllerConstants.viewUsersManage);
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
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

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
                    IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                    // ban user
                    DTUser_MovAdmin dtUser = new DTUser_MovAdmin();
                    dtUser.id = id;
                    serv.banUser(dtUser);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(MovAdminControllerConstants.viewUserDetails, new { id = id });
                }

                // reallow user
                else if (buttonReallow != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                    // ban user
                    DTUser_MovAdmin dtUser = new DTUser_MovAdmin();
                    dtUser.id = id;
                    serv.reallowUser(dtUser);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(MovAdminControllerConstants.viewUserDetails, new { id = id });
                }

                // disable resource
                else if (buttonDisable != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                    // ban user
                    DTResource_MovAdmin dtResource = new DTResource_MovAdmin();
                    dtResource.id = id;
                    serv.disableResource(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(MovAdminControllerConstants.viewUserDetails, new { id = model.userId });
                }

                // enable resource
                else if (buttonEnable != null)
                {
                    // open service
                    IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                    // enable resource
                    DTResource_MovAdmin dtResource = new DTResource_MovAdmin();
                    dtResource.id = id;
                    serv.enableResource(dtResource);

                    // close service
                    (serv as ICommunicationObject).Close();

                    return RedirectToAction(MovAdminControllerConstants.viewUserDetails, new { id = model.userId });
                }

                return View(model);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // shows the users register report.
        public ActionResult UsersRegisterReport(DTUsersRegisterReport dtUsersReport)
        {
            try
            {
                // open service
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                // get users register report.
                if (dtUsersReport == null)
                {
                    dtUsersReport = new DTUsersRegisterReport();
                    dtUsersReport.periodType = DTUsersRegisterReport_PeriodType.Day;
                }
                dtUsersReport = serv.getUsersRegisterReport(dtUsersReport);

                // close service
                (serv as ICommunicationObject).Close();

                // send the report to the model.
                return View(dtUsersReport);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // shows the users register report - change period type.
        [HttpPost]
        public ActionResult UsersRegisterReport(string buttonShowByYear, string buttonShowByMonth, string buttonShowByDay, DTUsersRegisterReport model)
        {
            // by year.
            if (buttonShowByYear != null)
            {
                model.periodType = DTUsersRegisterReport_PeriodType.Year;
                return RedirectToAction(MovAdminControllerConstants.viewUsersRegisterReport, model);
            }

            // by month.
            else if (buttonShowByMonth != null)
            {
                model.periodType = DTUsersRegisterReport_PeriodType.Month;
                return RedirectToAction(MovAdminControllerConstants.viewUsersRegisterReport, model);
            }

            // by day.
            else if (buttonShowByDay != null)
            {
                model.periodType = DTUsersRegisterReport_PeriodType.Day;
                return RedirectToAction(MovAdminControllerConstants.viewUsersRegisterReport, model);
            }

            return View();
        }

        // shows the users register report - chart by year.
        public ActionResult UsersRegisterReport_ChartByYear()
        {
            try
            {
                // open service
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                // get users register report.
                DTUsersRegisterReport dtUsersReport = new DTUsersRegisterReport();
                dtUsersReport.periodType = DTUsersRegisterReport_PeriodType.Year;
                dtUsersReport = serv.getUsersRegisterReport(dtUsersReport);

                // close service
                (serv as ICommunicationObject).Close();

                // send the report to the model.
                return View(dtUsersReport);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // shows the users register report - chart by month.
        public ActionResult UsersRegisterReport_ChartByMonth()
        {
            try
            {
                // open service
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                // get users register report.
                DTUsersRegisterReport dtUsersReport = new DTUsersRegisterReport();
                dtUsersReport.periodType = DTUsersRegisterReport_PeriodType.Month;
                dtUsersReport = serv.getUsersRegisterReport(dtUsersReport);

                // close service
                (serv as ICommunicationObject).Close();

                // send the report to the model.
                return View(dtUsersReport);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }

        // shows the users register report - chart by day.
        public ActionResult UsersRegisterReport_ChartByDay()
        {
            try
            {
                // open service
                IMovAdminService serv = GetService<IMovAdminService>(MovAdminControllerConstants.urlMovAdminService);

                // get users register report.
                DTUsersRegisterReport dtUsersReport = new DTUsersRegisterReport();
                dtUsersReport.periodType = DTUsersRegisterReport_PeriodType.Day;
                dtUsersReport = serv.getUsersRegisterReport(dtUsersReport);

                // close service
                (serv as ICommunicationObject).Close();

                // send the report to the model.
                return View(dtUsersReport);
            }
            catch (Exception error)
            {
                return RedirectToAction(HomeControllerConstants.viewAccessDenied);
            }
        }
    }
}
