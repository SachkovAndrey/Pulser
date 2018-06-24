using System.Configuration;

namespace Pulser.ConsoleClient
{
    internal static class AppSettingsProvider
    {
        #region Static and Readonly Fields

        private static string connectionString;
        private static string observableScheduleInterval;
        private static bool? usePulseEmulator;

        #endregion

        #region Static Methods

        public static string GetConnectionString()
        {
            connectionString = connectionString ?? ConfigurationManager.AppSettings["ConnectionString"];

            return connectionString;
        }

        public static string GetObservableScheduleInterval()
        {
            observableScheduleInterval = observableScheduleInterval ?? ConfigurationManager.AppSettings["ObservableScheduleInterval"];

            return observableScheduleInterval;
        }

        public static bool GetUsePulseEmulator()
        {
            usePulseEmulator = usePulseEmulator ?? bool.Parse(ConfigurationManager.AppSettings["UsePulseEmulator"]);

            return (bool)usePulseEmulator;
        }

        #endregion
    }
}
