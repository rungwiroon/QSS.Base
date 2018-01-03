using System;
using System.Linq;
using Examples.Entities;
using Examples.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EF.SqlServer.Tests
{
    [TestClass]
    public class EntityQueryTests
    {
        public EntityQueryTests()
        {
            //using (var session = new Model1())
            //{
            //    session.Groups.AddRange(new GroupEntity[]
            //    {
            //        new GroupEntity()
            //        {
            //            Name = "Name 1"
            //        },
            //        new GroupEntity()
            //        {
            //            Name = "Name 2"
            //        }
            //    });

            //    session.SaveChanges();
            //}
        }

        [TestMethod]
        public void TestGroup()
        {
            using (var session = new Model1())
            {
                var list = session.Groups
                    .ToList();

                Assert.AreEqual(2, list.Count);
            }
        }

        [TestMethod]
        public void TestItem()
        {
            using (var session = new Model1())
            {
                var list = session.Items
                    .ToList();

                Assert.AreEqual(3, list.Count);
                Assert.AreEqual(2, list.Select(l => l.Group)
                    .Where(g => g != null)
                    .Count());
            }
        }
    }
}
