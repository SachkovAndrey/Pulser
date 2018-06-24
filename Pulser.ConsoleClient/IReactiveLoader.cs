using System;

namespace Pulser.ConsoleClient
{

    public interface IReactiveLoader : IDisposable
    {
        #region Methods

        void RegisterObserver(IObserver<long> observer);

        #endregion
    }
}
