using System.Threading.Tasks;

namespace Pulser.Db
{
    public interface IDbInitializator
    {
        #region Methods

        Task<int> Initialize();

        #endregion
    }
}
