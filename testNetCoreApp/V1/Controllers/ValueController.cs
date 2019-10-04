using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testNetCoreApp.Utilities.Controllers;
using testNetCoreApp.Utilities.Logging;

namespace testNetCoreApp.V1.Controllers
{
    /// <summary>
    ///  
    /// </summary>
    // [ApiVersion("1.0")]
    [Produces("application/json")]
    // [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/v1/[controller]")]
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
            _log.Debug("Test");
            return Ok(new List<string>() { "value1", "value2" });
        }

        /// <summary>
        ///  Get Values by ID
        /// </summary>
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(id);
        }
    }
}