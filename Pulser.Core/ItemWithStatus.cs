using Pulser.Common;

namespace Pulser.Core
{
    public class ItemWithStatus
    {
        #region Constructors

        public ItemWithStatus(SiteItem item, AvailabilityStatus status)
        {
            Item = item;
            Status = status;
        }

        #endregion

        #region Properties

        public SiteItem Item { get; }
        public AvailabilityStatus Status { get; }

        #endregion
    }
}
