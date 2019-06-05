namespace ParentsEyesKidsTracking.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Date = c.DateTime(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Date);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Kids",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Location_Date = c.DateTime(),
                        Parent_Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Date)
                .ForeignKey("dbo.Parents", t => t.Parent_Id)
                .Index(t => t.Id)
                .Index(t => t.Location_Date)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Location_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Date)
                .Index(t => t.Id)
                .Index(t => t.Location_Date);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parents", "Location_Date", "dbo.Locations");
            DropForeignKey("dbo.Parents", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Kids", "Parent_Id", "dbo.Parents");
            DropForeignKey("dbo.Kids", "Location_Date", "dbo.Locations");
            DropForeignKey("dbo.Kids", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Parents", new[] { "Location_Date" });
            DropIndex("dbo.Parents", new[] { "Id" });
            DropIndex("dbo.Kids", new[] { "Parent_Id" });
            DropIndex("dbo.Kids", new[] { "Location_Date" });
            DropIndex("dbo.Kids", new[] { "Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.Parents");
            DropTable("dbo.Kids");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Locations");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
        }
    }
}
