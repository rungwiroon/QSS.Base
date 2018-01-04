using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qss.Repository.EntityFramework
{
    public class EfAsyncProvider : Qss.Base.Queries.IAsyncProvider
    {
        public Task<TSource> SingleOrDefaultAsync<TSource>(IQueryable<TSource> source, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<List<TSource>> ToListAsync<TSource>(IQueryable<TSource> source, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
