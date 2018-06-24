using Pulser.Common;
using Pulser.Core;
using Pulser.DAL.Mappers.CoreToDb;
using SimpleInjector;

namespace Pulser.DAL
{
    public static class RepositoryComponentRegistration
    {
        #region Static Methods

        public static void RegisterRepositories(Container container)
        {
            container.Register<IMapToNew<SiteItem, Db.Entities.SiteItem>, SiteItemMapper>();

            container.Register<IMapToNew<Db.Entities.SiteItem, SiteItem>, Mappers.DbToCore.SiteItemMapper>();

            container.Register<ISiteItemRepository, SiteItemRepository>();
        }

        #endregion
    }
}
