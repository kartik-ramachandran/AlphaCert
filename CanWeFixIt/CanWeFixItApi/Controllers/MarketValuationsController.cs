using CanWeFixItService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/valuations")]
    public class MarketValuationsController : ControllerBase
    {
        private readonly IDatabaseService _database;

        public MarketValuationsController(IDatabaseService database)
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
