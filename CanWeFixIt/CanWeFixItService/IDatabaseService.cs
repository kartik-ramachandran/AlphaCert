using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixItService
{
    public interface IDatabaseService
    {
        void SetupDatabase();
        Task<IEnumerable<Instrument>> GetActiveInstruments();
        Task<IEnumerable<MarketData>> GetActiveMarketData();
        Task<IEnumerable<MarketValuation>> GetMarketValuations();
        void CleanUpDatabase();
    }
}