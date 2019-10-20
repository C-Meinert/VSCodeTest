using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace testNetCoreApp.Utilities.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseController : ControllerBase
    { 
        /// <summary>
        /// Logger
        /// </summary>
        protected ILogger _log;

        /// <summary>
        /// Base Constructor
        /// </summary>
        /// <param name="log"></param>
        protected BaseController(ILogger log) {
            _log = log;
        }
    }
}