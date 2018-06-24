using NUnit.Framework;
using Pulser.DAL.Mappers.DbToCore;
using Pulser.Db.Entities;

namespace Pulser.DAL.Tests.Mappers.DbToCore
{
    [TestFixture]
    public class SiteItemMapperTest
    {
        [Test]
        public void MapCommonConditionSuccessTest()
        {
            var item = new SiteItem { Id = 1, Address = "TestAddress", Name = "TestSite" };

            var mapper = new SiteItemMapper();
            Core.SiteItem result = mapper.Map(item);

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("TestSite", result.Name);
            Assert.AreEqual("TestAddress", result.Address);
        }
    }
}
