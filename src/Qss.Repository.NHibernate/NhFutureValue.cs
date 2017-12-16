using System.Threading;
using System.Threading.Tasks;
using Nh = NHibernate;

namespace Qss.Repository.NHibernate
{
    public class NhFutureValue<T> : Qss.Base.Queries.IFutureValue<T>
    {
        public Nh.IFutureValue<T> FutureValue { get; private set; }

        public T Value => FutureValue.Value;

        public NhFutureValue(Nh.IFutureValue<T> futureValue)
        {
            FutureValue = futureValue;
        }

        public Task<T> GetValueAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return FutureValue.GetValueAsync(cancellationToken);
        }
    }
}