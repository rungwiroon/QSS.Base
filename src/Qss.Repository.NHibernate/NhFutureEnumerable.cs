using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nh = NHibernate;

namespace Qss.Repository.NHibernate
{
    public class NhFutureEnumerable<T> : Qss.Base.Queries.IFutureEnumerable<T>
    {
        private Nh.IFutureEnumerable<T> _futureEnumerable;

        public NhFutureEnumerable(Nh.IFutureEnumerable<T> futureEnumerable)
        {
            _futureEnumerable = futureEnumerable;
        }

        public Task<IEnumerable<T>> GetEnumerableAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _futureEnumerable.GetEnumerableAsync(cancellationToken);
        }

        public IEnumerable<T> GetEnumerable()
        {
            return _futureEnumerable.GetEnumerable();
        }
    }
}