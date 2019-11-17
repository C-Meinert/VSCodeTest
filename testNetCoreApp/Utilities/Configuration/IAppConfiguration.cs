namespace testNetCoreApp.Utilities.Configuration
{
    /// <summary>
    /// Class for loading, reading, and setting application
    /// settings
    /// </summary>
    public interface IAppConfiguration
    {
        /// <summary>
        /// Test Setting
        /// </summary>
        string SomeSetting { get; set; }
        /// <summary>
        /// Test Setting
        /// </summary>
        string ImmutableSetting {get;}
    }
}