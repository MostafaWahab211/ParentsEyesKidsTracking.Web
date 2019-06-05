using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParentsEyesKidsTracking.Web.Models
{
    [Table("Parents")]
    public class Parent:User
    {
     
        public Parent()
        {
            Location = new Location();
            Kids = new List<Kid>();
        }
        public virtual Location Location { get; set; }

        public virtual ICollection<Kid> Kids { get; set; }

    }
}