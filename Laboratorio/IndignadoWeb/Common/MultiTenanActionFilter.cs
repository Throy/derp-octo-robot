using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using IndignadoWeb.SessionServiceReference;
using System.Web.Security;
using System.Web.Routing;

namespace IndignadoWeb.Common
{
    public class MultiTenanActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                ISessionService session = GetService<ISessionService>("http://localhost:8730/IndignadoServer/SessionService/");
                String movimiento = filterContext.RouteData.Values["movimiento"] as String;

                DTTenantInfo tenantInfo = session.GetTenantInfo(movimiento);

                filterContext.HttpContext.Session.Add("tenantInfo", tenantInfo);
                filterContext.ActionParameters["tenantInfo"] = tenantInfo;

                if (filterContext.HttpContext.Session["token"] != null)
                {
                    if (!session.ValidateToken(tenantInfo.id, filterContext.HttpContext.Session["token"] as String))
                    {
                        filterContext.HttpContext.Session.Abandon();
                        FormsAuthentication.SignOut();

                        string[] myCookies = filterContext.HttpContext.Request.Cookies.AllKeys;
                        foreach (string cookie in myCookies)
                        {
                            filterContext.HttpContext.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                        }

                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
                    }
                }
                else
                {
                    FormsAuthentication.SignOut();
                }

                (session as ICommunicationObject).Close();
            }
            catch (Exception e)
            {
                ViewResult view = new ViewResult { ViewName = "Error" };
                view.ViewBag.ErrorMessage = e.Message;
                filterContext.Result = view;// new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Error" } });

            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                ViewResult view = filterContext.Result as ViewResult;
                if (filterContext.HttpContext.Session["tenantInfo"] != null)
                {
                    DTTenantInfo tenantInfo = filterContext.HttpContext.Session["tenantInfo"] as DTTenantInfo;
                    view.MasterName = tenantInfo.layoutFile;
                    view.ViewBag.TenantInfo = tenantInfo;
                }
                else
                {
                    view.MasterName = "~/Views/Shared/_Default.cshtml";
                    DTTenantInfo tenantInfo = new DTTenantInfo();
                    tenantInfo.habilitado = true;
                    view.ViewBag.TenantInfo = tenantInfo;
                }

                if (filterContext.HttpContext.Session["loginInfo"] != null)
                {
                    view.ViewBag.idUser = (filterContext.HttpContext.Session["loginInfo"] as DTLoginInfo).id;
                    view.ViewBag.UserIsRegUser = (filterContext.HttpContext.Session["loginInfo"] as DTLoginInfo).isRegUser;
                    view.ViewBag.UserIsMovAdmin = (filterContext.HttpContext.Session["loginInfo"] as DTLoginInfo).isMovAdmin;
                    view.ViewBag.UserIsSysAdmin = (filterContext.HttpContext.Session["loginInfo"] as DTLoginInfo).isSysAdmin;
                }
                else
                {
                    view.ViewBag.idUser = -1;
                    view.ViewBag.UserIsRegUser = false;
                    view.ViewBag.UserIsMovAdmin = false;
                    view.ViewBag.UserIsSysAdmin = false;
                }
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

        public T GetService<T>(String url)
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
    }
}