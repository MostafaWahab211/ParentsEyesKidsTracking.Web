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
        [Column(Order = 1)]
        public DateTime Date { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        public virtual ICollection<Kid> Kids { get; }

        public virtual ICollection<Parent> Parents { get; }
    }
}