using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParentsEyesKidsTracking.Web.Models
{
    public class Kid : User
    {
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public Location Location { get; set; }

        public Parent Parent { get; set; }

    }
}