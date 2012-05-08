using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace IndignadoWeb.Models
{
    // model for Create movement

    public class SingleMovementModel
    {
        [Required]
        [Display(Name = "Name: ")]
        public String name { get; set; }

        [Required]
        [Display(Name = "Description: ")]
        public String description { get; set; }

        [Required]
        [Display(Name = "Location - Latitude: ")]
        public float locationLati { get; set; }

        [Required]
        [Display(Name = "Location - Longitude: ")]
        public float locationLong { get; set; }

        [Required]
        [Display(Name = "Admin nick: ")]
        public String adminNick { get; set; }

        [Required]
        [Display(Name = "Admin password: ")]
        public String adminPassword { get; set; }

        [Required]
        [Display(Name = "Admin mail: ")]
        public String adminMail { get; set; }
    }
}
