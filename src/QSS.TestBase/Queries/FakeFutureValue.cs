using Qss.Base.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;

namespace Qss.TestBase.Queries
{
    public class FakeFutureValue<T> : IFutureValue<T>
    {
        public FakeFutureValue(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }

        public Task<T> GetValueAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(Value);
        }
    }
}
