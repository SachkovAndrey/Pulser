using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Pulser.Common;

namespace Pulser.PulseService
{
    public class PulseService : IPulseService
    {
        #region IPulseService Members

        public async Task<AvailabilityStatus> Pulse(string url)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpResponseMessage response = await client.GetAsync(url);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return AvailabilityStatus.Available;
                    case HttpStatusCode.NotFound:
                        return AvailabilityStatus.NotFound;
                    default:
                        return AvailabilityStatus.Unavailable;
                }
            }
        }

        #endregion
    }
}
