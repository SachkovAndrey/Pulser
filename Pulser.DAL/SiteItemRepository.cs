using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pulser.Common;
using Pulser.Core;
using Pulser.Db;

namespace Pulser.DAL
{
    internal class SiteItemRepository : ISiteItemRepository
    {
        #region Static and Readonly Fields

        private readonly IMapToNew<SiteItem, Db.Entities.SiteItem> coreSiteItemMapper;

        private readonly IDbContext dbContext;
        private readonly IMapToNew<Db.Entities.SiteItem, SiteItem> dbSiteItemMapper;

        #endregion

        #region Constructors

        public SiteItemRepository(IDbContext dbContext,
            IMapToNew<Db.Entities.SiteItem, SiteItem> dbSiteItemMapper,
            IMapToNew<SiteItem, Db.Entities.SiteItem> coreSiteItemMapper)
        {
            this.dbContext = dbContext;
            this.dbSiteItemMapper = dbSiteItemMapper;
            this.coreSiteItemMapper = coreSiteItemMapper;
        }

        #endregion

        #region ISiteItemRepository Members

        public void Add(SiteItem item)
        {
            dbContext.Add(coreSiteItemMapper.Map(item));
        }

        public async Task<IEnumerable<SiteItem>> GetSiteItems()
        {
            return await Task.Run(() => dbContext.All<Db.Entities.SiteItem>().Select(i => dbSiteItemMapper.Map(i)).ToList());
        }

        #endregion
    }
}
