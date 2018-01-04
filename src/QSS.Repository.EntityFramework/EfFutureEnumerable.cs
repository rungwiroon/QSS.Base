using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qss.Repository.EntityFramework
{
    public class EfFutureEnumerable<T> : Qss.Base.Queries.IFutureEnumerable<T>
    {
        public IEnumerable<T> GetEnumerable()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetEnumerableAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
