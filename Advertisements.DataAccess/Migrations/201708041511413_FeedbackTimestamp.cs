namespace Advertisements.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackTimestamp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "User_Id", "dbo.Users");
            DropIndex("dbo.Feedbacks", new[] { "User_Id" });
            RenameColumn(table: "dbo.Feedbacks", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Feedbacks", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterColumn("dbo.Feedbacks", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Feedbacks", "UserId");
            AddForeignKey("dbo.Feedbacks", "UserId", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.Users");
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            AlterColumn("dbo.Feedbacks", "UserId", c => c.Int());
            DropColumn("dbo.Feedbacks", "RowVersion");
            RenameColumn(table: "dbo.Feedbacks", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Feedbacks", "User_Id");
            AddForeignKey("dbo.Feedbacks", "User_Id", "dbo.Users", "Id");
        }
    }
}
