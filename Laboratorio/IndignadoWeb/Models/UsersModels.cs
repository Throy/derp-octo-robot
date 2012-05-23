using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using IndignadoWeb.MovAdminServiceReference;

namespace IndignadoWeb.Models
{
    // model for User manage

    public class UsersModel
    {
        public DTUsersCol users { get; set; }

        // 0: show everyone.
        // 1: show allowed users.
        // 2: show banned users.
        public int listType { get; set; }
    }
}
