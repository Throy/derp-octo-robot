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
        [Display(Name = "Layout: ")]
        public int layoutId { get; set; }

        [Required]
        [Display(Name = "Location - Latitude: ")]
        public float locationLati { get; set; }

        [Required]
        [Display(Name = "Location - Longitude: ")]
        public float locationLong { get; set; }

        [Display(Name = "Layouts: ")]
        public IEnumerable<SelectListItem> layouts { get; set; }
    }
}
