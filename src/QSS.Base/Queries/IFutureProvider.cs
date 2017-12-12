using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Qss.Base.Queries
{
    public interface IFutureProvider
    {
        IFutureEnumerable<TSource> ToFuture<TSource>(IQueryable<TSource> source);

        IFutureValue<TSource> ToFutureValue<TSource>(IQueryable<TSource> source);

        IFutureValue<TResult> ToFutureValue<TSource, TResult>(IQueryable<TSource> source, Expression<Func<IQueryable<TSource>, TResult>> selector);
    }
}
