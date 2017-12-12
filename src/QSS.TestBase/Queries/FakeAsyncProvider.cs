using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Qss.Base.Queries;

namespace Qss.TestBase.Queries
{
    public class FakeAsyncProvider : IAsyncProvider
    {
        public Task<TSource> SingleOrDefaultAsync<TSource>(IQueryable<TSource> source, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<List<TSource>> ToListAsync<TSource>(IQueryable<TSource> source, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(source.ToList());
        }
    }
}
