using System.Configuration;

namespace BOB
{
    /// <summary>
    /// DB Connection string 
    /// </summary>
    public static class DBConnectionSetting
    {
        /// <summary>
        /// Default connection string
        /// </summary>
        public static string BOBConnectionString
        {
            get
            {
                return ConfigurationSettings.AppSettings["BOBConnectionString"];
            }
        }
    }
}