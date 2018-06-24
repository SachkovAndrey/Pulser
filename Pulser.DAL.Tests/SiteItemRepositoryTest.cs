using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Pulser.Common;
using Pulser.Core;
using Pulser.DAL.Mappers.DbToCore;
using Pulser.Db;

namespace Pulser.DAL.Tests
{
    [TestFixture]
    public class SiteItemRepositoryTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            dbContextMock = new Mock<IDbContext>();
            coreMapperMock = new Mock<IMapToNew<SiteItem, Db.Entities.SiteItem>>();
            dbMapperMock = new Mock<IMapToNew<Db.Entities.SiteItem, SiteItem>>();
            siteItems = new List<Db.Entities.SiteItem>()
            {
                new Db.Entities.SiteItem() { Address = "w", Id = 1, Name = "Foo" },
                new Db.Entities.SiteItem() { Address = "f", Id = 2, Name = "Bar" }
            };
        }

        [TearDown]
        public void TearDown()
        {
            dbContextMock = null;
            coreMapperMock = null;
            dbMapperMock = null;
            siteItems = null;
        }

        #endregion

        private Mock<IDbContext> dbContextMock;
        private Mock<IMapToNew<SiteItem, Db.Entities.SiteItem>> coreMapperMock;
        private Mock<IMapToNew<Db.Entities.SiteItem, SiteItem>> dbMapperMock;
        private List<Db.Entities.SiteItem> siteItems;

        [Test]
        public void AddCallsDbSuccessTest()
        {
            coreMapperMock.Setup(x => x.Map(It.IsAny<SiteItem>())).Returns(new Db.Entities.SiteItem());
            var repository = new SiteItemRepository(dbContextMock.Object, dbMapperMock.Object, coreMapperMock.Object);
            repository.Add(It.IsAny<SiteItem>());

            dbContextMock.Verify(x => x.Add(It.IsAny<Db.Entities.SiteItem>()), Times.Exactly(1));
        }

        [Test]
        public void GetSiteItemsCommonConditionSuccessTest()
        {
            dbContextMock.Setup(x => x.All<Db.Entities.SiteItem>()).Returns(siteItems);
            var repository = new SiteItemRepository(dbContextMock.Object, new SiteItemMapper(), coreMapperMock.Object);

            Task<IEnumerable<SiteItem>> task = repository.GetSiteItems();

            Task.WaitAll(task);

            List<SiteItem> items = task.Result.ToList();

            Assert.AreEqual(2, items.Count);
            Assert.AreEqual(siteItems[0].Id, items[0].Id);
            Assert.AreEqual(siteItems[1].Id, items[1].Id);
        }
    }
}
