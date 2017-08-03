namespace GoogleAnalyticsConsumer.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GoogleAnalyticsConsumer.Data.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GoogleAnalyticsConsumer.Data.MainContext context)
        {
        }
    }
}