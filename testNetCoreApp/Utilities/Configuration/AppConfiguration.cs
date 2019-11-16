using Microsoft.Extensions.Configuration;

namespace testNetCoreApp.Utilities.Configuration
{
    /// <summary>
    /// Class for loading, reading, and setting application
    /// settings
    /// </summary>
    public class AppConfiguration : IAppConfiguration
    {
        private IConfiguration _config;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        public AppConfiguration(IConfiguration config)
        {
            _config = config;
            LoadConfig();
        }

        #region Mutable Settings
        /// <summary>
        /// Test Setting
        /// </summary>
        public string SomeSetting { get; set; }

        #region Load Initial Setting Values
        /// <summary>
        /// set initial values of settings that are mutable
        /// </summary>
        private void LoadConfig()
        {
            SomeSetting = _config.GetValue<string>("Key", "") ?? "";
        }
        #endregion
        #endregion

        #region Immutable Settings
        /// <summary>
        /// Test Setting
        /// </summary>
        public string ImmutableSetting => _config.GetValue<string>("Key", "") ?? "";
        #endregion
    }
}