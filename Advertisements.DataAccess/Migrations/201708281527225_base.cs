namespace Advertisements.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _base : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Feedbacks", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Feedbacks", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Agree = c.Boolean(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        FeedbackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Feedbacks", t => t.FeedbackId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.FeedbackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "FeedbackId", "dbo.Feedbacks");
            DropForeignKey("dbo.Votes", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Votes", new[] { "FeedbackId" });
            DropIndex("dbo.Votes", new[] { "ApplicationUserId" });
            DropTable("dbo.Votes");
            RenameIndex(table: "dbo.Feedbacks", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Feedbacks", name: "ApplicationUserId", newName: "ApplicationUser_Id");
        }
    }
}
