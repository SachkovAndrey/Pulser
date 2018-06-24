using SimpleInjector;

namespace Pulser.Db
{
    public static class DbComponentRegistration
    {
        #region Static Methods

        public static void RegisterDb(Container container)
        {
            container.Register<IDbContext, DbContext>();
            container.Register<IDbInitializator, DbContext>();
        }

        #endregion
    }
}
