using Pulser.Common;

namespace Pulser.ConsoleClient
{
    internal class Configuration : IConfiguration
    {
        #region IConfiguration Members

        public string ConnectionString
        {
            get
            {
                return AppSettingsProvider.GetConnectionString();
            }
        }

        #endregion
    }
}
