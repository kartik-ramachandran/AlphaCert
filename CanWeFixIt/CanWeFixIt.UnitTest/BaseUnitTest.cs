using CanWeFixItService;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace CanWeFixIt.UnitTest
{
    public class Tests
    {
        private UnitTestSetup _initialize;
        private ServiceProvider _serviceprovider;
        private IDatabaseService _databaseService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _initialize = new UnitTestSetup();

            _serviceprovider = _initialize.CreateServiceCollection();

            _databaseService = _serviceprovider.GetService<IDatabaseService>();

            _databaseService.SetupDatabase();
        }
               

        [TearDown]
        public void TearDown()
        {
            _databaseService.CleanUpDatabase();
        }

        [Test]
        public void Instrument_Get_Success()
        {
            var getActiveInstruments = _databaseService.GetActiveInstruments();
        }

        [Test]
        public void MarketData_Get_Success()
        {
            var getActiveMarketData = _databaseService.GetActiveMarketData();
        }

        [Test]
        public void MarketValuations_Get_Success()
        {
            var getMarketValuations = _databaseService.GetMarketValuations();
        }
    }
}