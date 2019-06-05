using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParentsEyesKidsTracking.Web.Models
{
    [Table("Kids")]
    public class Kid : User
    {
        public Kid()
        {
            Location = new Location();
            Parent = new Parent();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public virtual Location Location { get; set; }

        [Required]
        public virtual Parent Parent { get; set; }

    }
}