using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Pulser.Common;
using Pulser.Db.Entities;

namespace Pulser.Db.Tests
{
    [TestFixture]
    public class DbContextTest
    {
        [Test]
        public void InitializeCommonConditionSuccessTest()
        {
            var mock = new Mock<IConfiguration>();
            mock.Setup(x => x.ConnectionString).Returns(@"D:\Temp\MyData2.db");

            var db = new DbContext(mock.Object);

            Task.WaitAll(db.Initialize());
            List<SiteItem> list = db.All<SiteItem>().ToList();

            Assert.AreEqual(5, list.Count);
        }
    }
}
