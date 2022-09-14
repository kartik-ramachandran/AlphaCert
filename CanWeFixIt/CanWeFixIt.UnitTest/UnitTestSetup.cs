using CanWeFixIt.Logging;
using CanWeFixItService;
using Microsoft.Extensions.DependencyInjection;

namespace CanWeFixIt.UnitTest
{
    public class UnitTestSetup
    {
        public ServiceProvider CreateServiceCollection()
        {
            var services = new ServiceCollection();

            services.AddTransient<ICustomLogger, CustomLogger>();
            services.AddTransient<IDatabaseService, DatabaseService>();

            return services.BuildServiceProvider();
        }
    }
}
