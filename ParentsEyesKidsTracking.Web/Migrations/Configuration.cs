namespace ParentsEyesKidsTracking.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ParentsEyesKidsTracking.Web.Models.KidsTrackingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ParentsEyesKidsTracking.Web.Models.KidsTrackingContext";
        }

        protected override void Seed(ParentsEyesKidsTracking.Web.Models.KidsTrackingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
