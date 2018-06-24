using Pulser.Common;
using Pulser.DAL;
using Pulser.Db;
using Pulser.PulseService;
using Pulser.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Pulser.ConsoleClient
{
    internal static class Bootstrapper
    {
        #region Static Methods

        public static Container Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            container.Register<IConfiguration, Configuration>();

            if (AppSettingsProvider.GetUsePulseEmulator())
            {
                container.Register<IPulseService, PulseServiceEmulator>();
            }
            else
            {
                container.Register<IPulseService, PulseService.PulseService>();
            }

            container.RegisterSingleton<IReactiveLoader, ReactiveLoader>();

            DbComponentRegistration.RegisterDb(container);
            RepositoryComponentRegistration.RegisterRepositories(container);
            ServicesComponentRegistrations.RegisterServices(container);

            container.Verify();

            return container;
        }

        #endregion
    }
}
