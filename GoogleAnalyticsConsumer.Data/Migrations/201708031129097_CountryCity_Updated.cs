namespace GoogleAnalyticsConsumer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryCity_Updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "City", c => c.String(maxLength: 100));
            AddColumn("dbo.Client", "Country", c => c.String(maxLength: 100));
            AlterColumn("dbo.PageViewsDuration", "City", c => c.String(maxLength: 100));
            AlterColumn("dbo.PageViewsDuration", "Country", c => c.String(maxLength: 100));
            AlterColumn("dbo.PageViews", "City", c => c.String(maxLength: 100));
            AlterColumn("dbo.PageViews", "Country", c => c.String(maxLength: 100));
            AlterColumn("dbo.UniquePageViews", "City", c => c.String(maxLength: 100));
            AlterColumn("dbo.UniquePageViews", "Country", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UniquePageViews", "Country", c => c.String());
            AlterColumn("dbo.UniquePageViews", "City", c => c.String());
            AlterColumn("dbo.PageViews", "Country", c => c.String());
            AlterColumn("dbo.PageViews", "City", c => c.String());
            AlterColumn("dbo.PageViewsDuration", "Country", c => c.String());
            AlterColumn("dbo.PageViewsDuration", "City", c => c.String());
            DropColumn("dbo.Client", "Country");
            DropColumn("dbo.Client", "City");
        }
    }
}
