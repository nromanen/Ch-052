namespace Advertisements.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PasswordRecoveries", name: "UserId", newName: "Id");
            RenameIndex(table: "dbo.PasswordRecoveries", name: "IX_UserId", newName: "IX_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PasswordRecoveries", name: "IX_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.PasswordRecoveries", name: "Id", newName: "UserId");
        }
    }
}
