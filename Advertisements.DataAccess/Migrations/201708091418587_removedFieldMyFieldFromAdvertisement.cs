namespace Advertisements.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedFieldMyFieldFromAdvertisement : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Advertisements", "Myfield");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Advertisements", "Myfield", c => c.String());
        }
    }
}
