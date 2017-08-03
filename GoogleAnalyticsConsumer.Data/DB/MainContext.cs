using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GoogleAnalyticsConsumer.Data
{
    public class MainContext : DbContext
    {
        public MainContext() : base("DbContextConnection") { }
        
        public DbSet<Client> ClientEntities { get; set; } 
        public DbSet<PageViews> PageViewsEntities { get; set; }
        public DbSet<UniquePageViews> UniquePageViewsEntities { get; set; }
        public DbSet<PageViewsDuration> PageViewsDurationEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MainContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}