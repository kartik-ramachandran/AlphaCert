using Microsoft.EntityFrameworkCore;

namespace CanWeFixItService
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=DatabaseService;");
        }

        public DbSet<Instrument> Instrument { get; set; }
        public DbSet<MarketData> MarketData { get; set; }
    }
}
