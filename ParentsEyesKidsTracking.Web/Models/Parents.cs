using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParentsEyesKidsTracking.Web.Models
{
    public class Parent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Userame { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string Phonenumber { get; set; }

        public IEnumerable<Kid> Kids { get; set; }

    }
}