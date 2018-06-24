using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Pulser.Common;
using Pulser.Db.Entities;

namespace Pulser.Db
{
    internal class DbContext : IDbContext, IDbInitializator
    {
        #region Static and Readonly Fields

        private readonly IConfiguration configuration;

        #endregion

        #region Constructors

        public DbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region Static Methods

        private static IEnumerable<SiteItem> GetItems()
        {
            var list = new List<SiteItem>()
            {
                new SiteItem() { Address = "https://www.google.com/", Name = "Google" },
                new SiteItem() { Address = "https://www.yandex.ru/", Name = "Yandex" },
                new SiteItem() { Address = "https://github.com/", Name = "Github" },
                new SiteItem() { Address = " https://habr.com/", Name = "Habr" },
                new SiteItem() { Address = " https://stackoverflow.com/", Name = "Stackoverflow" }
            };

            return list;
        }

        #endregion

        #region IDbContext Members

        public void Add<T>(T item) where T : EntityBase
        {
            using (var db = new LiteDatabase(configuration.ConnectionString))
            {
                LiteCollection<T> collection = db.GetCollection<T>();
                collection.Insert(item);
            }
        }

        public IEnumerable<T> All<T>() where T : EntityBase
        {
            using (var db = new LiteDatabase(configuration.ConnectionString))
            {
                LiteCollection<T> collection = db.GetCollection<T>();
                return collection.FindAll();
            }
        }

        #endregion

        #region IDbInitializator Members

        public async Task<int> Initialize()
        {
            return await Task.Run(() =>
            {
                using (var db = new LiteDatabase(configuration.ConnectionString))
                {
                    LiteCollection<SiteItem> collection = db.GetCollection<SiteItem>();
                    IEnumerable<SiteItem> result = collection.FindAll();
                    if (!result.Any())
                    {
                        return collection.InsertBulk(GetItems());
                    }
                    return 0;
                }
            });
        }

        #endregion
    }
}
