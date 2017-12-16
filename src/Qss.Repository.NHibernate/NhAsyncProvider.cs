using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Qss.Repository.NHibernate
{
    public class NhAsyncProvider : Qss.Base.Queries.IAsyncProvider
    {
        public Task<TSource> SingleOrDefaultAsync<TSource>(IQueryable<TSource> source, CancellationToken cancellationToken = default(CancellationToken))
        {
            return source.SingleOrDefaultAsync();
        }

        public Task<List<TSource>> ToListAsync<TSource>(IQueryable<TSource> source, CancellationToken cancellationToken = default(CancellationToken))
        {
            return source.ToListAsync();
        }
    }
}