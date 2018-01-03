using Examples.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.NHibernate.SqlServer.Tests
{
    [TestClass]
    public class LegacyEntityTests
    {
        [TestMethod]
        public void TestGroup()
        {
            using (var session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var list = session.Query<GroupLegacyEntity>()
                    .ToList();

                Assert.AreEqual(2, list.Count);
            }
        }

        [TestMethod]
        public void TestItem()
        {
            using (var session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var list = session.Query<ItemLegacyEntity>()
                    .ToList();

                Assert.AreEqual(3, list.Count);
                Assert.AreEqual(2, list.Select(l => l.Group)
                    .Where(g => g != null)
                    .Count());
            }
        }
    }
}
