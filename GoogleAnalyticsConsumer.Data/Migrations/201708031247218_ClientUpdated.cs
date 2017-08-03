namespace GoogleAnalyticsConsumer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "City", c => c.String());
            AddColumn("dbo.Client", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "Country");
            DropColumn("dbo.Client", "City");
        }
    }
}
