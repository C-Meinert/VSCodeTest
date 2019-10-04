using Microsoft.AspNetCore.Mvc;
using testNetCoreApp.Utilities.Logging;

namespace testNetCoreApp.Utilities.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        protected ILoggingService _log;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        protected BaseController(ILoggingService log) {
            _log = log;
        }
    }
}