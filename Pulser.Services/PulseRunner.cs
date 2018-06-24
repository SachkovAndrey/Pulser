using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pulser.Common;
using Pulser.Core;
using Pulser.PulseService;

namespace Pulser.Services
{
    internal class PulseRunner : IPulseRunner
    {
        #region Static and Readonly Fields

        private readonly IPulseService pulseService;
        private readonly ISiteItemService siteItemService;

        #endregion

        #region Constructors

        public PulseRunner(IPulseService pulseService, ISiteItemService siteItemService)
        {
            this.pulseService = pulseService;
            this.siteItemService = siteItemService;
        }

        #endregion

        #region Methods

        private async Task<ItemWithStatus> DoWorkAsync(SiteItem item)
        {
            AvailabilityStatus res = await pulseService.Pulse(item.Address);
            return new ItemWithStatus(item, res);
        }

        #endregion

        #region IPulseRunner Members

        public async Task<IEnumerable<ItemWithStatus>> Run()
        {
            IEnumerable<SiteItem> siteItems = await siteItemService.GetAll();
            return await Task.WhenAll(siteItems.Select(x => DoWorkAsync(x)));
        }

        #endregion
    }
}
