using CanWeFixIt.Logging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanWeFixItService.BusinessRules
{
    public class DbAction : IDbAction
    {
        private readonly MyDbContext _myDbContext;
        private readonly ICustomLogger _customLogger;

        public DbAction(MyDbContext myDbContext, ICustomLogger customLogger)
        {
            _myDbContext = myDbContext;
            _customLogger = customLogger;
        }

        public async Task<IEnumerable<Instrument>> GetInstruments()
        {
            return await _myDbContext.Instrument.ToListAsync();
        }

        public async Task<IEnumerable<Instrument>> GetActiveInstruments()
        {
            var allInstruments = await GetInstruments();

            if (allInstruments == null)
            {
                _customLogger.LogInfo("No Instruments found");
                return null;            
            }

            return allInstruments.ToList().FindAll(i => i.Active);
        }

        public async Task<IEnumerable<MarketData>> GetMarketData()
        {
            return await _myDbContext.MarketData.ToListAsync();
        }

        public async Task<IEnumerable<MarketDataDto>> GetActiveMarketData()
        {
            var allMarketData = await GetMarketData();

            if (allMarketData == null)
            {
                _customLogger.LogInfo("No MarketData found");
                return null;
            }

            var activeMarketData = allMarketData.ToList().FindAll(i => i.Active);

            var activeInstruments = await GetActiveInstruments();

            var returnData = new List<MarketDataDto>();

            activeMarketData.ForEach(md =>
            {
                var matchedInstrumentData = activeInstruments.SingleOrDefault(ins => ins.Sedol == md.Sedol);

                if (matchedInstrumentData != null)
                {
                    returnData.Add(new MarketDataDto
                    {
                        Id = md.Id,
                        Active = md.Active,
                        DataValue = md.DataValue,
                        InstrumentId = matchedInstrumentData.Id
                    });
                }
            });

            return returnData;
        }

        public async Task<IEnumerable<MarketValuation>> GetMarketValuations()
        {
            var activeMarketData = await GetActiveMarketData();

            var returnValuation = new List<MarketValuation>
            {
                new MarketValuation
                {
                    Name = "DataValueTotal",
                    Total = activeMarketData != null ? activeMarketData.ToList().Sum(data => data.DataValue).Value : 0
                }
            };

            return returnValuation;
        }
    }
}
