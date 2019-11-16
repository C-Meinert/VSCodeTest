using Microsoft.AspNetCore.Mvc;
using Serilog;
using testNetCoreApp.Utilities.Configuration;

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
        /// Application Settings
        /// </summary>
        protected IAppConfiguration _appConfig;

        /// <summary>
        /// Base Constructor
        /// </summary>
        /// <param name="appConfig"></param>
        /// <param name="log"></param>
        protected BaseController(IAppConfiguration appConfig, ILogger log) {
            _log = log;
            _appConfig = appConfig;
        }
    }
}