using SimpleInjector;

namespace Pulser.Services
{
    public static class ServicesComponentRegistrations
    {
        #region Static Methods

        public static void RegisterServices(Container container)
        {
            container.Register<ISiteItemService, SiteItemService>();
            container.Register<IPulseRunner, PulseRunner>();
        }

        #endregion
    }
}
