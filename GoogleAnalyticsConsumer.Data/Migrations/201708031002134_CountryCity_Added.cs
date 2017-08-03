namespace GoogleAnalyticsConsumer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryCity_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageViewsDuration", "City", c => c.String());
            AddColumn("dbo.PageViewsDuration", "Country", c => c.String());
            AddColumn("dbo.PageViews", "City", c => c.String());
            AddColumn("dbo.PageViews", "Country", c => c.String());
            AddColumn("dbo.UniquePageViews", "City", c => c.String());
            AddColumn("dbo.UniquePageViews", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UniquePageViews", "Country");
            DropColumn("dbo.UniquePageViews", "City");
            DropColumn("dbo.PageViews", "Country");
            DropColumn("dbo.PageViews", "City");
            DropColumn("dbo.PageViewsDuration", "Country");
            DropColumn("dbo.PageViewsDuration", "City");
        }
    }
}
