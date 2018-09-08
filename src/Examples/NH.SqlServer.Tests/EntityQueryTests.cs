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

        [TestMethod]
        public void TestInsertUpdateDelete()
        {
            using (var session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var newItem = new ItemEntity()
                {
                    Name = "NewItem"
                };

                session.Save(newItem);

                Assert.AreNotEqual(0, newItem.Id);

                newItem.Name = "UpdatedItem";

                session.Flush();

                Assert.AreEqual("UpdatedItem", newItem.Name);

                session.Delete(newItem);

                session.Flush();
            }
        }
    }
}
