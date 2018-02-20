using System;
using System.Linq;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qss.Base.Models;
using Qss.Base.Queries;

namespace QSS.Base.Tests
{
    [TestClass]
    public class IEnumerableExtensionTests
    {
        [TestMethod]
        public void TestToPagingResult()
        {
            var list = Enumerable.Range(1, 10);

            var pagedList = list.ToPagingResult(new GridRequestModel()
            {
                Page = 1,
                Rows = 2
            });

            Assert.AreEqual(10, pagedList.RowCount);
            Assert.AreEqual(2, pagedList.Rows.Count());
            Assert.AreEqual(1, pagedList.Rows.First());
            Assert.AreEqual(2, pagedList.Rows.Last());
        }
    }
}
