using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testNetCoreApp.Utilities.Controllers;
using testNetCoreApp.Utilities.Logging;

namespace testNetCoreApp.V2.Controllers
{
    /// <summary>
    ///  
    /// </summary>
    // [ApiVersion("2.0")]
    [Produces("application/json")]
    // [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/v2/[controller]")]
    public class ValueController : BaseController
    {

        /// <summary>
        ///  Constructor
        /// </summary>
        public ValueController(ILoggingService log)
            : base(log)
        {

        }

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