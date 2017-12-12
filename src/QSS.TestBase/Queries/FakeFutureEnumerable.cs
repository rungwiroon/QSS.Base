using Qss.Base.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Qss.TestBase.Queries
{
    public class FakeFutureEnumerable<TSource> : IFutureEnumerable<TSource>
    {
        private readonly IQueryable<TSource> _query;

        public FakeFutureEnumerable(IQueryable<TSource> query)
        {
            _query = query;
        }

        public IEnumerable<TSource> GetEnumerable()
        {
            return _query.AsEnumerable();
        }

        public Task<IEnumerable<TSource>> GetEnumerableAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(_query.AsEnumerable());
        }
    }
}
