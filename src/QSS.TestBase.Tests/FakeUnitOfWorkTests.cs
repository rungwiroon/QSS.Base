using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qss.Base.Patterns;
using Qss.TestBase.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSS.TestBase.Tests
{
    [TestClass]
    public class FakeUnitOfWorkTests
    {
        [TestMethod]
        public void TestCreateInstance()
        {
            var repoEnt1 = new FakeRepository<EntityModel>(new List<EntityModel>());
            var repoEnt2 = new FakeRepository<EntityModel2>(new List<EntityModel2>());

            var repoList = new List<IRepository>()
            {
                repoEnt1, repoEnt2
            };

            var unitOfWork = new FakeUnitOfWork(repoList);

            var repoEntForCheck1 = unitOfWork.GetRepository<EntityModel>();
            var repoEntForCheck2 = unitOfWork.GetRepository<EntityModel2>();

            Assert.AreEqual(repoEnt1, repoEntForCheck1);
            Assert.AreEqual(repoEnt2, repoEntForCheck2);
        }
    }
}
