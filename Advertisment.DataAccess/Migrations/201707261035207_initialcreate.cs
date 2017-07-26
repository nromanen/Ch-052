namespace Advertisement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adverts",
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
                .ForeignKey("dbo.AdvTypes", t => t.TypeId, cascadeDelete: true)
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
                .ForeignKey("dbo.Adverts", t => t.AdvertisementId, cascadeDelete: true)
                .Index(t => t.AdvertisementId);
            
            CreateTable(
                "dbo.AdvTypes",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adverts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.PasswordRecoveries", "UserId", "dbo.Users");
            DropForeignKey("dbo.Adverts", "TypeId", "dbo.AdvTypes");
            DropForeignKey("dbo.Resources", "AdvertisementId", "dbo.Adverts");
            DropForeignKey("dbo.Adverts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.PasswordRecoveries", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Resources", new[] { "AdvertisementId" });
            DropIndex("dbo.Adverts", new[] { "TypeId" });
            DropIndex("dbo.Adverts", new[] { "CategoryId" });
            DropIndex("dbo.Adverts", new[] { "UserId" });
            DropTable("dbo.Roles");
            DropTable("dbo.PasswordRecoveries");
            DropTable("dbo.Users");
            DropTable("dbo.AdvTypes");
            DropTable("dbo.Resources");
            DropTable("dbo.Categories");
            DropTable("dbo.Adverts");
        }
    }
}
