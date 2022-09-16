using CanWeFixIt.Logging;
using CanWeFixItService;
using CanWeFixItService.BusinessRules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CanWeFixIt.UnitTest
{
    public class UnitTestSetup
    {
        public ServiceProvider CreateServiceCollection()
        {
            var services = new ServiceCollection();

            services.AddTransient<ICustomLogger, CustomLogger>();
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlite("DataSource=DatabaseService;"));
            //services.AddTransient<IDatabaseService, DatabaseService>();
            services.AddTransient<IDbAction, DbAction>();

            var dbOptionBuilder = new DbContextOptions<MyDbContext>();

            var context = new MyDbContext(dbOptionBuilder);

            MyDbContextSeeder.Seed(context);

            return services.BuildServiceProvider();
        }
    }
}
