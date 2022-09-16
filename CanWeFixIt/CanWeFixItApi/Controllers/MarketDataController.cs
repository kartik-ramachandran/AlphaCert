using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixItService;
using CanWeFixItService.BusinessRules;
using Microsoft.AspNetCore.Mvc;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/marketdata")]
    public class MarketDataController : ControllerBase
    {
        private readonly IDbAction _database;

        public MarketDataController(IDbAction database)
        {
            _database = database;
        }
        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketDataDto>>> Get()
        {
            return Ok(_database.GetActiveMarketData().Result);
        }
    }
}