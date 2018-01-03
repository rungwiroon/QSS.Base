using System;
using Examples.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Examples.NHibernate.SqlServer.Tests
{
    [TestClass]
    public class EntityQueryTests
    {
        [TestMethod]
        public void TestGroup()
        {
            using (var session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var list = session.Query<GroupEntity>()
                    .ToList();

                Assert.AreEqual(2, list.Count);
            }
        }

        [TestMethod]
        public void TestItem()
        {
            using (var session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var list = session.Query<ItemEntity>()
                    .ToList();

                Assert.AreEqual(3, list.Count);
                Assert.AreEqual(2, list.Select(l => l.Group)
                    .Where(g => g != null)
                    .Count());
            }
        }
    }
}
