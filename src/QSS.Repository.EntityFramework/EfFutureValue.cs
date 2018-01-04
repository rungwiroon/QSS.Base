using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qss.Repository.EntityFramework
{
    public class EfFutureValue<T> : Qss.Base.Queries.IFutureValue<T>
    {
        public T Value => throw new NotImplementedException();

        public Task<T> GetValueAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
