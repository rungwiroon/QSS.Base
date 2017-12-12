using Qss.Base.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Qss.TestBase.Queries
{
    public class FakeFutureProvider : IFutureProvider
    {
        public IFutureEnumerable<TSource> ToFuture<TSource>(IQueryable<TSource> source)
        {
            return new FakeFutureEnumerable<TSource>(source);
        }

        public IFutureValue<TSource> ToFutureValue<TSource>(IQueryable<TSource> source)
        {
            return new FakeFutureValue<TSource>(source.First());
        }

        public IFutureValue<TResult> ToFutureValue<TSource, TResult>(IQueryable<TSource> source, 
            Expression<Func<IQueryable<TSource>, TResult>> selector)
        {
            return new FakeFutureValue<TResult>(selector.Compile().Invoke(source));
        }
    }
}
