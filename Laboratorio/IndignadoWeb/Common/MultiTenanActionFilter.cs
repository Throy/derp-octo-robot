﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using IndignadoWeb.SessionServiceReference;

namespace IndignadoWeb.Common
{
    public class MultiTenanActionFilter : ActionFilterAttribute
    {
        private DTTenantInfo _tenantInfo;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ISessionService session = GetService<ISessionService>("http://localhost:8730/IndignadoServer/SessionService/");
            String movimiento = filterContext.RouteData.Values["movimiento"] as String;

            _tenantInfo = session.GetTenantInfo(movimiento);

            filterContext.HttpContext.Session.Add("tenantInfo", _tenantInfo);
            filterContext.ActionParameters["tenantInfo"] = _tenantInfo;

            (session as ICommunicationObject).Close();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                ViewResult view = filterContext.Result as ViewResult;
                view.MasterName = _tenantInfo.layoutFile;
                view.ViewBag.TenantInfo = _tenantInfo;
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