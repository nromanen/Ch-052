namespace Advertisements.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoftDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Feedbacks", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Votes", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.PasswordRecoveries", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Resources", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AdvertisementTypes", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdvertisementTypes", "IsDeleted");
            DropColumn("dbo.Resources", "IsDeleted");
            DropColumn("dbo.Categories", "IsDeleted");
            DropColumn("dbo.PasswordRecoveries", "IsDeleted");
            DropColumn("dbo.Votes", "IsDeleted");
            DropColumn("dbo.Feedbacks", "IsDeleted");
            DropColumn("dbo.AspNetUsers", "IsDeleted");
            DropColumn("dbo.Advertisements", "IsDeleted");
        }
    }
}
