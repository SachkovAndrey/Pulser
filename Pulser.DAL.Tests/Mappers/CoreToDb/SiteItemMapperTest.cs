using NUnit.Framework;
using Pulser.Core;
using Pulser.DAL.Mappers.CoreToDb;

namespace Pulser.DAL.Tests.Mappers.CoreToDb
{
    [TestFixture]
    public class SiteItemMapperTest
    {
        [Test]
        public void MapCommonConditionSuccessTest()
        {
            var item = new SiteItem(1, "TestSite", "TestAddress");

            var mapper = new SiteItemMapper();
            Db.Entities.SiteItem result = mapper.Map(item);

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("TestSite", result.Name);
            Assert.AreEqual("TestAddress", result.Address);
        }
    }
}
