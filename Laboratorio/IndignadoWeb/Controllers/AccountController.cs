using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using IndignadoWeb.Models;
using System.ServiceModel;
using IndignadoWeb.SessionServiceReference;

namespace IndignadoWeb.Controllers
{
    public class AccountController : Controller
    {

        private static T GetService<T>(String url)
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
                ISessionService session = GetService<ISessionService>("http://localhost:8730/IndignadoServer/SessionService/");

                bool success = true;
                String token = "";
                DTTenantInfo tenantInfo = HttpContext.Session["tenantInfo"] as DTTenantInfo;
                try
                {
                    token = session.Login(tenantInfo.id, model.UserName, model.Password);
                }
                catch (FaultException e)
                {
                    ModelState.AddModelError("", e.Message);
                    success = false;
                }

                if (success)
                {
                    HttpContext.Session.Add("token", token);

                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                (session as ICommunicationObject).Close();
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            HttpContext.Session.Remove("token");

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ISessionService session = GetService<ISessionService>("http://localhost:8730/IndignadoServer/SessionService/");
                
                DTTenantInfo tenantInfo = HttpContext.Session["tenantInfo"] as DTTenantInfo;

                // Attempt to register the user
                //MembershipCreateStatus createStatus;
                //Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);
                DTRegisterModel user =  new DTRegisterModel();
                user.apodo = model.UserName;
                user.contraseña = model.Password;
                user.idMovimiento = tenantInfo.id;
                user.latitud = model.Latitud;
                user.longitud = model.Longitud;
                user.mail = model.Email;
                user.nombre = model.Name;

                DTUserCreateStatus createStatus = session.RegisterUser(user);

                if (createStatus == DTUserCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }

                (session as ICommunicationObject).Close();
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(DTUserCreateStatus createStatus)
        {
            switch (createStatus)
            {
                case DTUserCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case DTUserCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case DTUserCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case DTUserCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case DTUserCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case DTUserCreateStatus.GenericError:
                    return "Error generico de prueba";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
