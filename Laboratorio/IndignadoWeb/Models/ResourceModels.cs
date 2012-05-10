using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace IndignadoWeb.Models
{
    // model for Create resource

    public class CreateResourceModel
    {
        [Display(Name = "Title: ")]
        public String title { get; set; }

        [Display(Name = "Description: ")]
        public String description { get; set; }

        [Display(Name = "URL: ")]
        public String link { get; set; }

        [Display(Name = "Thumbnail: ")]
        public String thumbnail { get; set; }
    }
}
