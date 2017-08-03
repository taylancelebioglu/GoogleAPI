namespace GoogleAnalyticsConsumer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.PageViewsDuration", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.PageViews", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.UniquePageViews", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UniquePageViews", "Created");
            DropColumn("dbo.PageViews", "Created");
            DropColumn("dbo.PageViewsDuration", "Created");
            DropColumn("dbo.Client", "Created");
        }
    }
}
