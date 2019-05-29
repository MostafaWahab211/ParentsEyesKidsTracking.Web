using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ParentsEyesKidsTracking.Web.Models
{
    public class KidsTrackingContext : IdentityDbContext
    {
        public KidsTrackingContext() : base("KidsTrackingConection") { }

        public static KidsTrackingContext Create()
        {
            return new KidsTrackingContext();
        }

        public DbSet <Parent> Parents { get; set; }

        public DbSet <Kid> Kids { get; set; }

        public DbSet <Location> Locations { get; set; }

    }
}