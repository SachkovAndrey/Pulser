using System.Collections.Generic;
using Pulser.Db.Entities;

namespace Pulser.Db
{
    public interface IDbContext
    {
        #region Methods

        void Add<T>(T item) where T : EntityBase;

        IEnumerable<T> All<T>() where T : EntityBase;

        #endregion
    }
}
