namespace Advertisements.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "ApplicationUser_Id", "dbo.AspNetUsers");
            AddColumn("dbo.AspNetUsers", "Avatar", c => c.Binary());
            AddColumn("dbo.AspNetUsers", "Feedback_Id", c => c.Int());
            AddColumn("dbo.Feedbacks", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "Feedback_Id");
            CreateIndex("dbo.Feedbacks", "ApplicationUser_Id1");
            AddForeignKey("dbo.AspNetUsers", "Feedback_Id", "dbo.Feedbacks", "Id");
            AddForeignKey("dbo.Feedbacks", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Feedback_Id", "dbo.Feedbacks");
            DropIndex("dbo.Feedbacks", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.AspNetUsers", new[] { "Feedback_Id" });
            DropColumn("dbo.Feedbacks", "ApplicationUser_Id1");
            DropColumn("dbo.AspNetUsers", "Feedback_Id");
            DropColumn("dbo.AspNetUsers", "Avatar");
            AddForeignKey("dbo.Feedbacks", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
