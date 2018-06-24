using Pulser.Common;
using Pulser.Core;

namespace Pulser.DAL.Mappers.CoreToDb
{
    internal class SiteItemMapper : IMapToNew<SiteItem, Db.Entities.SiteItem>
    {
        #region IMapToNew<SiteItem,SiteItem> Members

        public Db.Entities.SiteItem Map(SiteItem source)
        {
            return new Db.Entities.SiteItem() { Id = source.Id, Address = source.Address, Name = source.Name };
        }

        #endregion
    }
}
