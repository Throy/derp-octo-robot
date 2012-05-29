using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndignadoWeb.MovAdminServiceReference;
using IndignadoWeb.NewsResourcesServiceReference;

namespace IndignadoWeb.Models
{
    public class HomeModel
    {
        public DTMovement movement { get; set; }

        public DTResourcesCol_NewsResources resources { get; set; }

        public MeetingsMapModel meetings { get; set; }
    }
}