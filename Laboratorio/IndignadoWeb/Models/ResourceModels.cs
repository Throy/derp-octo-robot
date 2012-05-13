using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using IndignadoWeb.NewsResourcesServiceReference;

namespace IndignadoWeb.Models
{
    // model for Create resource

    public class ShareResourceModel
    {
        [Display(Name = "Title: ")]
        public String title { get; set; }

        [Display(Name = "Description: ")]
        public String description { get; set; }

        [Display(Name = "Link: ")]
        public String urlLink { get; set; }

        [Display(Name = "Thumbnail: ")]
        public String urlThumb { get; set; }

        [Display(Name = "Image: ")]
        public String urlImage { get; set; }

        [Display(Name = "Video: ")]
        public String urlVideo { get; set; }
    }

    // model for List resources

    public class ListResourcesModel
    {
        public DTResourcesCol items { get; set; }

        [Display(Name = "ID: ")]
        public int id { get; set; }
    }
}
