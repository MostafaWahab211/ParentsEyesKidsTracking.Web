using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ParentsEyesKidsTracking.Web.Models
{
    public class KidsTrackingContext : DbContext
    {
        public KidsTrackingContext() : base("KidsTrackingConection") { }

        public DbSet <Parent> Parents { get; set; }

        public DbSet <Kid> Kids { get; set; }

        public DbSet <Location> Locations { get; set; }

    }
}