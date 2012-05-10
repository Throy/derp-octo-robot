using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace IndignadoWeb.Models
{
    // model for Create Resource Feed

    public class ResourceConfig
    {
        [Required]
        [Display(Name = "Name: ")]
        public String name { get; set; }

        [Required]
        [Display(Name = "Tag: ")]
        public String filter { get; set; }

        [Required]
        [Display(Name = "RSS URL: ")]
        public String rssUrl { get; set; }
    }
}
