using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleProgressBar;
using Pulser.Core;
using Pulser.Db;
using Pulser.Services;
using SimpleInjector;

namespace Pulser.ConsoleClient
{
    class Program
    {
        #region Constants

        private const string messagePattern = "{0}:  {1}{2}";

        #endregion

        #region Static and Readonly Fields

        private static IDbInitializator dbInitializator;

        private static List<ItemWithStatus> items;

        private static IReactiveLoader loader;

        private static IPulseRunner pulseService;

        private static ReactiveObserver<IEnumerable<ItemWithStatus>> reactiveObserver;

        #endregion

        #region Static Methods

        private static async Task DbInit()
        {
            int result;

            using (var pb = new ProgressBar())
            {
                pb.StatusOnSeparateLine = true;
                using (Progress p1 = pb.Progress.Fork(1, "Data Base Initialization..."))
                {
                    p1.Report(1);
                    result = await dbInitializator.Initialize();
                }
            }
        }

        static void Main(string[] args)
        {
            Container container = Bootstrapper.Initialize();
            dbInitializator = container.GetInstance<IDbInitializator>();
            pulseService = container.GetInstance<IPulseRunner>();
            loader = container.GetInstance<IReactiveLoader>();
            ObserverInitialize();

            DbInit().Wait();
            Pulse().Wait();

            foreach (ItemWithStatus i in items)
            {
                Console.Write(messagePattern, i.Item.Name, i.Status, Environment.NewLine);
            }

            loader.RegisterObserver(reactiveObserver);

            Console.ReadKey();
        }

        private static void ObserverInitialize()
        {
            reactiveObserver = new ReactiveObserver<IEnumerable<ItemWithStatus>>(async () => await pulseService.Run(),
                (data) =>
                {
                    foreach (ItemWithStatus i in data)
                    {
                        Console.Write(messagePattern, i.Item.Name, i.Status, Environment.NewLine);
                    }
                });
        }

        private static async Task Pulse()
        {
            using (var pb = new ProgressBar())
            {
                pb.StatusOnSeparateLine = true;
                using (Progress p1 = pb.Progress.Fork(0.5, "Pulse first time..."))
                {
                    p1.Report(0.5);
                    IEnumerable<ItemWithStatus> result = await pulseService.Run();
                    items = result.ToList();
                }
            }
        }

        #endregion
    }
}
