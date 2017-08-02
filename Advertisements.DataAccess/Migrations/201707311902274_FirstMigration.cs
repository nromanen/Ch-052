namespace Advertisements.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Myfield = c.String(),
                        Price = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AdvertisementTypes", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        AdvertisementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertisements", t => t.AdvertisementId, cascadeDelete: true)
                .Index(t => t.AdvertisementId);
            
            CreateTable(
                "dbo.AdvertisementTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Active = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.PasswordRecoveries",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        AccessHash = c.String(),
                        Expires = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        AgreeCount = c.Int(nullable: false),
                        DisagreeCount = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        AdvertisementId = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertisements", t => t.AdvertisementId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.AdvertisementId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "AdvertisementId", "dbo.Advertisements");
            DropForeignKey("dbo.Advertisements", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.PasswordRecoveries", "UserId", "dbo.Users");
            DropForeignKey("dbo.Advertisements", "TypeId", "dbo.AdvertisementTypes");
            DropForeignKey("dbo.Resources", "AdvertisementId", "dbo.Advertisements");
            DropForeignKey("dbo.Advertisements", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Feedbacks", new[] { "User_Id" });
            DropIndex("dbo.Feedbacks", new[] { "AdvertisementId" });
            DropIndex("dbo.PasswordRecoveries", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Resources", new[] { "AdvertisementId" });
            DropIndex("dbo.Advertisements", new[] { "TypeId" });
            DropIndex("dbo.Advertisements", new[] { "CategoryId" });
            DropIndex("dbo.Advertisements", new[] { "UserId" });
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Roles");
            DropTable("dbo.PasswordRecoveries");
            DropTable("dbo.Users");
            DropTable("dbo.AdvertisementTypes");
            DropTable("dbo.Resources");
            DropTable("dbo.Categories");
            DropTable("dbo.Advertisements");
        }
    }
}
