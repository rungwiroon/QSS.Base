using Examples.Entities;
using Examples.Services;
using FizzWare.NBuilder;
using NUnit.Framework;
using Qss.Base.Patterns;
using Qss.TestBase.Patterns;
using Should;
using SpecsFor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    public class ItemServiceTests
    {
        public class WhenGet : SpecsFor<ItemService>
        {
            private IList<ItemEntity> _list;

            protected override void Given()
            {
                var items = Builder<ItemEntity>
                    .CreateListOfSize(10)
                    .Build();

                GetMockFor<IRepository<ItemEntity>>()
                    .SetupGet(r => r.Query)
                    .Returns(items.AsQueryable());
            }

            protected override void When()
            {
                _list = SUT.Get();
            }

            [Test]
            public void then_has_rows()
            {
                _list.Count.ShouldEqual(10);
            }
        }

        public class WhenGet2 : SpecsFor<ItemService>
        {
            private IList<ItemEntity> _list;

            protected override void InitializeClassUnderTest()
            {
                var items = Builder<ItemEntity>
                    .CreateListOfSize(10)
                    .Build();

                var fakeRepo = new FakeRepository<ItemEntity>(items);

                SUT = new ItemService(fakeRepo);
            }

            protected override void Given()
            {

            }

            protected override void When()
            {
                _list = SUT.Get();
            }

            [Test]
            public void then_has_rows()
            {
                _list.Count.ShouldEqual(10);
            }
        }
    }
}
