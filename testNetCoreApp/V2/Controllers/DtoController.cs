using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testNetCoreApp.Utilities.Controllers;
using testNetCoreApp.V2.Dtos;

namespace testNetCoreApp.V2.Controllers
{
    /// <summary>
    ///  
    /// </summary>
    // [ApiVersion("2.0")]
    [Produces("application/json")]
    // [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/v2/[controller]")]
    public class DtoController : BaseController
    {
        /// <summary>
        ///  Constructor
        /// </summary>
        public DtoController(ILogger log)
            : base(log)
        {

        }

        /// <summary>
        ///  Get All the Values
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _log.Debug("test2");
            return Ok(makeDtos());
        }

        /// <summary>
        ///  Get Values by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = makeDtos().FirstOrDefault(dto => dto.Id == id);
            if(result != null)
                return Ok(result);

            return NotFound();
        }

        #region helper methods
        private List<SimpleDto> makeDtos() {
            return new List<SimpleDto> {
                new SimpleDto {
                    Id = new Guid("5fd79e97-b04c-4be9-9c44-e8d261ae8891"),
                    prop1 = "Some Value1"
                },
                new SimpleDto {
                    Id = new Guid("f0f42310-ac6b-41c1-97ca-88d4592bad07"),
                    prop1 = "Some Value2"
                },
                new SimpleDto {
                    Id = new Guid("500144fe-5df8-41fa-b9b7-f2db49eb8ade"),
                    prop1 = "Some Value3"
                },
                new SimpleDto {
                    Id = new Guid("a78b0946-6734-4294-92cb-f8e154d88313"),
                    prop1 = "Some Value4"
                }
            };
        }
        #endregion
    }
}