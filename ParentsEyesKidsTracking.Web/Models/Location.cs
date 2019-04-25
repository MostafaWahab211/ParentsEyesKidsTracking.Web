using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParentsEyesKidsTracking.Web.Models
{
    public class Location
    {
        [Key]
        [Column(Order = 0)]
        public Kid Kid { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Date { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public decimal Latitude { get; set; }
    }
}