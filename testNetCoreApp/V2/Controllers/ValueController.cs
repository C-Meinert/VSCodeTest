using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testNetCoreApp.Utilities.Configuration;
using testNetCoreApp.Utilities.Controllers;

namespace testNetCoreApp.V2.Controllers
{
    /// <summary>
    ///  
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]    
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/v2/[controller]")]
    [Produces("application/json")]
    public class ValueController : BaseController
    {

        /// <summary>
        ///  Constructor
        /// </summary>
        public ValueController(IAppConfiguration appConfig, ILogger log)
            : base(appConfig, log)
        {  }

        /// <summary>
        ///  Get All the Values
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new List<string>() { "value1", "value2" });
        }

        /// <summary>
        ///  Get Values by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(id);
        }
    }
}