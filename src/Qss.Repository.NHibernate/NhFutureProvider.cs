using NHibernate.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Qss.Repository.NHibernate
{
    public class NhFutureProvider : Qss.Base.Queries.IFutureProvider
    {
        public Qss.Base.Queries.IFutureEnumerable<TSource> ToFuture<TSource>(IQueryable<TSource> source)
        {
            return new NhFutureEnumerable<TSource>(source.ToFuture());
        }

        public Qss.Base.Queries.IFutureValue<TSource> ToFutureValue<TSource>(IQueryable<TSource> source)
        {
            return new NhFutureValue<TSource>(source.ToFutureValue());
        }

        public Qss.Base.Queries.IFutureValue<TResult> ToFutureValue<TSource, TResult>(IQueryable<TSource> source, Expression<Func<IQueryable<TSource>, TResult>> selector)
        {
            return new NhFutureValue<TResult>(source.ToFutureValue(selector));
        }
    }
}