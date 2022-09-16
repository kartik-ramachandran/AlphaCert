using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixItService;
using CanWeFixItService.BusinessRules;
using Microsoft.AspNetCore.Mvc;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/instruments")]
    public class InstrumentController : ControllerBase
    {
        private readonly IDbAction _database;
        
        public InstrumentController(IDbAction database)
        {
            _database = database;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instrument>>> Get()
        {   
            return Ok(_database.GetActiveInstruments().Result);
        }
    }
}