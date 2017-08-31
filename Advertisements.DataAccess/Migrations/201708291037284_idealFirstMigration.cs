namespace Advertisements.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idealFirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EmailToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "EmailToken");
        }
    }
}
