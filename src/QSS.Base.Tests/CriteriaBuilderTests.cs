using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qss.Base.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSS.Base.Tests
{
    [TestClass]
    public class CriteriaBuilderTests
    {
        [TestMethod]
        public void WhenAddCriteria_ShouldHaveExpressionInQuery()
        {
            var queryBuilder = new CriteriaBuilder<int>();

            queryBuilder.Add(num => num > 5);

            var query = Enumerable.Range(1, 10)
                .AsQueryable();

            query = queryBuilder.Build(query);

            var result = query.ToArray();

            Assert.AreEqual(5, result.Count());
            Assert.AreEqual(6, result.First());
        }

        [TestMethod]
        public void WhenAddCheckCriteria_ShouldHaveExpressionInQuery()
        {
            var queryBuilder = new CriteriaBuilder<int>();

            queryBuilder.Add(true, num => num > 5);
            queryBuilder.Add(false, num => num < 5);

            var query = Enumerable.Range(1, 10)
                .AsQueryable();

            query = queryBuilder.Build(query);

            var result = query.ToArray();

            Assert.AreEqual(5, result.Count());
            Assert.AreEqual(6, result.First());
        }

        [TestMethod]
        public void WhenAddConditoinedCriteria_ShouldHaveExpressionInQuery()
        {
            var queryBuilder = new CriteriaBuilder<int>();

            queryBuilder.Add(() => true, num => num > 5);
            queryBuilder.Add(() => false, num => num < 5);

            var query = Enumerable.Range(1, 10)
                .AsQueryable();

            query = queryBuilder.Build(query);

            var result = query.ToArray();

            Assert.AreEqual(5, result.Count());
            Assert.AreEqual(6, result.First());
        }
    }
}
