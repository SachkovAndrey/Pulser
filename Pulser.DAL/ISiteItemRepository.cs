using System.Collections.Generic;
using System.Threading.Tasks;
using Pulser.Core;

namespace Pulser.DAL
{
    public interface ISiteItemRepository
    {
        #region Methods

        void Add(SiteItem item);

        Task<IEnumerable<SiteItem>> GetSiteItems();

        #endregion
    }
}
