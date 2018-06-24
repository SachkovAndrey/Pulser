using System.Collections.Generic;
using System.Threading.Tasks;
using Pulser.Core;

namespace Pulser.Services
{
    public interface IPulseRunner
    {
        #region Methods

        Task<IEnumerable<ItemWithStatus>> Run();

        #endregion
    }
}
