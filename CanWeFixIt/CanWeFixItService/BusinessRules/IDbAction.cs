using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixItService.BusinessRules
{
    public interface IDbAction
    {
        Task<IEnumerable<Instrument>> GetInstruments();
        Task<IEnumerable<MarketData>> GetMarketData();
        Task<IEnumerable<Instrument>> GetActiveInstruments();
        Task<IEnumerable<MarketDataDto>> GetActiveMarketData();
        Task<IEnumerable<MarketValuation>> GetMarketValuations();
    }
}