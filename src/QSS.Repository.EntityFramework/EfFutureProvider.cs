using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Qss.Base.Queries;

namespace Qss.Repository.EntityFramework
{
    public class EfFutureProvider : IFutureProvider
    {
        public IFutureEnumerable<TSource> ToFuture<TSource>(IQueryable<TSource> source)
        {
            throw new NotImplementedException();
        }

        public IFutureValue<TSource> ToFutureValue<TSource>(IQueryable<TSource> source)
        {
            throw new NotImplementedException();
        }

        public IFutureValue<TResult> ToFutureValue<TSource, TResult>(IQueryable<TSource> source, Expression<Func<IQueryable<TSource>, TResult>> selector)
        {
            throw new NotImplementedException();
        }
    }
}
