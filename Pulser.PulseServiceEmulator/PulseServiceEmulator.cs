using System;
using System.Threading.Tasks;
using Pulser.Common;

namespace Pulser.PulseService
{
    public class PulseServiceEmulator : IPulseService
    {
        #region Static and Readonly Fields

        private readonly Random random = new Random();

        #endregion

        #region IPulseService Members

        public async Task<AvailabilityStatus> Pulse(string url)
        {
            return await Task.Run(() =>
            {
                Array values = Enum.GetValues(typeof(AvailabilityStatus));
                return (AvailabilityStatus)values.GetValue(random.Next(0, values.Length));
            });
        }

        #endregion
    }
}
