using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testNetCoreApp.V2.Controllers
{
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ValueController : Controller 
    {

        public ValueController() {

        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            return Ok(new List<string>(){"value1", "value2"});
        }

        [HttpGet("{id}", Name="GetById")]
        public async Task<IActionResult> Get(int id) {
            return Ok(id);
        }
    }    
}