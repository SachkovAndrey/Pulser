using System.Collections.Generic;
using System.Threading.Tasks;
using Pulser.Core;

namespace Pulser.Services
{
    public interface ISiteItemService
    {
        #region Methods

        void Add(SiteItem siteItem);

        Task<IEnumerable<SiteItem>> GetAll();

        #endregion
    }
}
