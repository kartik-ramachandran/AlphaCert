using CanWeFixItService;
using CanWeFixItService.BusinessRules;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/valuations")]
    public class MarketValuationsController : ControllerBase
    {
        private readonly IDbAction _database;

        public MarketValuationsController(IDbAction database)
        {
            _database = database;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketValuation>>> Get()
        {
            return Ok(_database.GetMarketValuations().Result);
        }
    }
}
