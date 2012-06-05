using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignadoWeb.Models;
using IndignadoWeb.SysAdminServiceReference;
using System.ServiceModel;
using IndignadoWeb.SessionServiceReference;
using IndignadoWeb.MovAdminServiceReference;
using System.Web.Security;
using IndignadoWeb.Common;
using System.Text.RegularExpressions;

namespace IndignadoWeb.Controllers
{
    public class SysAdminControllerConstants
    {
        public const string loginUrl = "~/admin/LogOn";
        public const string viewAccessDenied = "AccessDenied";
        public const string viewMovementCreate = "MovementCreate";
        public const string viewMovementsList = "MovementsList";

        public const string urlSessionService = "http://localhost:8730/IndignadoServer/SessionService/";
        public const string urlSysAdminService = "http://localhost:8730/IndignadoServer/SysAdminService/";
    }

    public class SysAdminController : Controller
    {
        private static T GetSessionService<T>(String url)
        {
            var binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.None;

            ChannelFactory<T> scf;
            scf = new ChannelFactory<T>(
                        binding,
                        url);

            return scf.CreateChannel();
        }

        private T GetService<T>(String url)
        {
            var binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

            ChannelFactory<T> scf;
            scf = new ChannelFactory<T>(
                        binding,
                        url);

            scf.Credentials.UserName.UserName = "0"; // idMovimiento
            scf.Credentials.UserName.Password = (HttpContext.Session["token"] == null) ? "Guest" : HttpContext.Session["token"].ToString();

            return scf.CreateChannel();
        }

        [AuthFilter(LoginUrl = SysAdminControllerConstants.loginUrl)]
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ISessionService session = GetSessionService<ISessionService>("http://localhost:8730/IndignadoServer/SessionService/");

                bool success = true;
                DTLoginInfo loginInfo = new DTLoginInfo();
                try
                {
                    loginInfo = session.Login(0, model.UserName, model.Password);
                }
                catch (FaultException e)
                {
                    ModelState.AddModelError("", e.Message);
                    success = false;
                }

                if (success)
                {
                    HttpContext.Session.Add("token", loginInfo.token);

                    FormsAuthentication.SetAuthCookie(loginInfo.name, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "SysAdmin");
                    }
                }

                (session as ICommunicationObject).Close();
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AuthFilter(LoginUrl = SysAdminControllerConstants.loginUrl)]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            HttpContext.Session.Remove("token");
            HttpContext.Session.Remove("FBtoken");

            return RedirectToAction("LogOn", "SysAdmin");
        }


        // shows all movements in a list.
        [AuthFilter(LoginUrl = SysAdminControllerConstants.loginUrl)]
        public ActionResult MovementsList()
        {
            ISysAdminService serv = GetService<ISysAdminService>(SysAdminControllerConstants.urlSysAdminService);

            // get all movements
            DTMovementsCol movements = serv.getMovementsList();

            // close service
            (serv as ICommunicationObject).Close();

            // send the movements to the model.
            return View(movements);
        }

        // create movement.
        [AuthFilter(LoginUrl = SysAdminControllerConstants.loginUrl)]
        public ActionResult MovementCreate()
        {
            /*
            try
            {
                // check if the user is a system admin.
                ISessionService serv = GetService<ISessionService>(HomeControllerConstants.urlSessionService);
                serv.ValidateSysAdmin();
            */
            // show form
            return View();
            /*
            }
            catch (Exception error)
            {
                return RedirectToAction(SysAdminControllerConstants.viewAccessDenied);
            }
            */
        }

        // create movement.
        [HttpPost]
        [AuthFilter(LoginUrl = SysAdminControllerConstants.loginUrl)]
        public ActionResult MovementCreate(SingleMovementModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ISysAdminService serv = GetService<ISysAdminService>(SysAdminControllerConstants.urlSysAdminService);

                    IndignadoWeb.SysAdminServiceReference.DTMovement dtMovement = new IndignadoWeb.SysAdminServiceReference.DTMovement();
                    dtMovement.id = -1;
                    dtMovement.name = model.name;
                    dtMovement.description = model.description;
                    dtMovement.locationLati = model.locationLati;
                    dtMovement.locationLong = model.locationLong;               

                    dtMovement.subURL = model.url.Replace(' ','_');
                    serv.createMovement(dtMovement);

                    // get all movements
                    DTMovementsCol movements = serv.getMovementsList();

                    // close service
                    (serv as ICommunicationObject).Close();

                    // send the movements to the model.
                    return View(SysAdminControllerConstants.viewMovementsList, movements);
                }

                // If we got this far, something failed, redisplay form
                return View(model);
            }
            catch
            {
                return RedirectToAction(SysAdminControllerConstants.viewAccessDenied);
            }
        }


    }
}
