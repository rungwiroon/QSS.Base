using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qss.TestBase.Patterns;

namespace QSS.TestBase.Tests
{
    [TestClass]
    public class FakeRepositoryTests
    {
        [TestMethod]
        public void TestGetRepository()
        {
            var list = new List<EntityModel>()
            {
                new EntityModel()
                {
                    Id = 1,
                    Name = "Name 1"
                },

                new EntityModel()
                {
                    Id = 2,
                    Name = "Name 2"
                }
            };
            var repository = new FakeRepository<EntityModel>(list);

            var getResult = repository.Get(1);

            Assert.AreEqual(list[0], getResult);

            var createResult = repository.Create(new EntityModel()
            {
                Name = "Name 3"
            });

            Assert.AreEqual(3, (int)createResult);

            repository.Delete(list[0]);
            repository.Delete(2);
        }
    }
}
