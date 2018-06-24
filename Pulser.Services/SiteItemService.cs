using System.Collections.Generic;
using System.Threading.Tasks;
using Pulser.Core;
using Pulser.DAL;

namespace Pulser.Services
{
    internal class SiteItemService : ISiteItemService
    {
        #region Static and Readonly Fields

        private readonly ISiteItemRepository repository;

        #endregion

        #region Constructors

        public SiteItemService(ISiteItemRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region ISiteItemService Members

        public void Add(SiteItem siteItem)
        {
            repository.Add(siteItem);
        }

        public async Task<IEnumerable<SiteItem>> GetAll()
        {
            return await repository.GetSiteItems();
        }

        #endregion
    }
}
