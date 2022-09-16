using CanWeFixItService.BusinessRules;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace CanWeFixIt.UnitTest
{
    public class Tests
    {
        private UnitTestSetup _initialize;
        private ServiceProvider _serviceprovider;
        private IDbAction _databaseService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _initialize = new UnitTestSetup();

            _serviceprovider = _initialize.CreateServiceCollection();

            _databaseService = _serviceprovider.GetService<IDbAction>();
        }               

        [Test]
        public async Task Instrument_Get_Success()
        {
            var getInstruments = await _databaseService.GetInstruments();

            getInstruments.Should().NotBeNull();
        }

        [Test]
        public async Task MarketData_Get_Success()
        {
            var getMarketData = await _databaseService.GetMarketData();

            getMarketData.Should().NotBeNull();
        }

        [Test]
        public async Task ActiveInstrument_Get_Success()
        {
            var getActiveInstruments = await _databaseService.GetActiveInstruments();

            getActiveInstruments.Should().NotBeNull();
        }

        [Test]
        public async Task ActiveMarketData_Get_Success()
        {
            var getActiveMarketData = await _databaseService.GetActiveMarketData();

            getActiveMarketData.Should().NotBeNull();
        }

        [Test]
        public async Task MarketValuations_Get_Success()
        {
            var getMarketValuations = await _databaseService.GetMarketValuations();

            getMarketValuations.Should().NotBeNull();
            getMarketValuations.Should().ContainSingle();
            getMarketValuations.ToList()[0].Total.Should().BeGreaterThanOrEqualTo(6666);
        }
    }
}