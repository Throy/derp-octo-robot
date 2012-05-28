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
        public DTUsersCol_MovAdmin users { get; set; }

        // 0: show everyone.
        // 1: show allowed users.
        // 2: show banned users.
        public int listType { get; set; }
    }

    // model for User config

    public class UserConfigModel
    {
        [Required]
        [Display(Name = "Full name: ")]
        public String fullName { get; set; }

        [Required]
        [Display(Name = "Email address")]
        public String mail { get; set; }

        [Required]
        [Display(Name = "Location - Latitude: ")]
        public float locationLati { get; set; }

        [Required]
        [Display(Name = "Location - Longitude: ")]
        public float locationLong { get; set; }
    }

    // model for User details

    public class UserDetailsModel
    {
        public DTUserDetails_MovAdmin userDetails { get; set; }

        [Display(Name = "User ID: ")]
        public int userId { get; set; }

        public int id { get; set; }
    }
}
