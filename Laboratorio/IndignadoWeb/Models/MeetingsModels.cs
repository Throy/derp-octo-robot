using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace IndignadoWeb.Models
{
    // model for Create meeting

    public class CreateMeetingModel
    {
        [Required]
        [Display(Name = "Name: ")]
        public String name { get; set; }

        [Required]
        [Display(Name = "Description: ")]
        public String description { get; set; }

        [Required]
        [Display(Name = "Minimum quorum: ")]
        public int minQuorum { get; set; }
    }
}
