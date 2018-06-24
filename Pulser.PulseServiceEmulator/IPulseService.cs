using System.Threading.Tasks;
using Pulser.Common;

namespace Pulser.PulseService
{
    public interface IPulseService
    {
        #region Methods

        Task<AvailabilityStatus> Pulse(string url);

        #endregion
    }
}
