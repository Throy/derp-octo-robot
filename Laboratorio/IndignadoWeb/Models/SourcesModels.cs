using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections.ObjectModel;
using IndignadoWeb.MovAdminServiceReference;

namespace IndignadoWeb.Models
{
    public class RssSourcesModel
    {
        public DTRssSourcesCol items { get; set; }

        public DTRssSource newItem { get; set; }
    }
}
