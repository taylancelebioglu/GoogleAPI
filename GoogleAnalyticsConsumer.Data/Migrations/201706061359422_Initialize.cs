namespace GoogleAnalyticsConsumer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Browser = c.String(maxLength: 100),
                        OperatingSystem = c.String(maxLength: 100),
                        DeviceCategory = c.String(maxLength: 100),
                        Data = c.String(maxLength: 500),
                        DataTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PageViewsDuration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageTitle = c.String(maxLength: 200),
                        PagePathLevel = c.String(maxLength: 100),
                        PagePath = c.String(maxLength: 100),
                        Data = c.String(maxLength: 500),
                        DataTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PageViews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageTitle = c.String(maxLength: 200),
                        PagePathLevel = c.String(maxLength: 100),
                        PagePath = c.String(maxLength: 100),
                        Data = c.String(maxLength: 500),
                        DataTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UniquePageViews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageTitle = c.String(maxLength: 200),
                        PagePathLevel = c.String(maxLength: 100),
                        PagePath = c.String(maxLength: 100),
                        Data = c.String(maxLength: 500),
                        DataTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UniquePageViews");
            DropTable("dbo.PageViews");
            DropTable("dbo.PageViewsDuration");
            DropTable("dbo.Client");
        }
    }
}
