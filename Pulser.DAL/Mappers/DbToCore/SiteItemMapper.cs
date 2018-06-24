using Pulser.Common;
using Pulser.Db.Entities;

namespace Pulser.DAL.Mappers.DbToCore
{
    internal class SiteItemMapper : IMapToNew<SiteItem, Core.SiteItem>
    {
        #region IMapToNew<SiteItem,SiteItem> Members

        public Core.SiteItem Map(SiteItem source)
        {
            return new Core.SiteItem(source.Id, source.Name, source.Address);
        }

        #endregion
    }
}
