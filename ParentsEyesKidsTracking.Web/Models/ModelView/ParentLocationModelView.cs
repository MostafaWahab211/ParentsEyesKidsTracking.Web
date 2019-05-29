using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParentsEyesKidsTracking.Web.Models.ModelView
{
    public class ParentLocationModelView
    {
        [Required]
        public string ParentId { get; set; }

        [Required]
        public Location Location { get; set; }
    }
}