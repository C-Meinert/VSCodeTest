using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testNetCoreApp.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/[controller]")]
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