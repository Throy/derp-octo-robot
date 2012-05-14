using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using IndignadoWeb.SessionServiceReference;
using System.Web.Security;

namespace IndignadoWeb.Common
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class AuthFilter : AuthorizeAttribute
    {
        private string _loginUrl;

        public string LoginUrl               // Topic is a named parameter
        {
            get 
            { 
                return _loginUrl; 
            }
            set 
            { 
                _loginUrl = value; 
            }
        }
   
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.HttpContext.Session["token"] == null)
            {
                if (_loginUrl != null)
                    filterContext.Result = new RedirectResult(_loginUrl);
                else
                    filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}