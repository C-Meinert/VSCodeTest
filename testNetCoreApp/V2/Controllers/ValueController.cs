using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testNetCoreApp.V2.Controllers
{
    /// <summary>
    ///  
    /// </summary>
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ValueController : Controller
    {

        /// <summary>
        ///  Constructor
        /// </summary>
        public ValueController()
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
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(id);
        }
    }
}