using Qss.Base.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Qss.TestBase.Queries
{
    public class FakeFetchingProvider : IFetchingProvider
    {
        public IFetchRequest<TOriginating, TRelated> Fetch<TOriginating, TRelated>(IQueryable<TOriginating> query,
            Expression<Func<TOriginating, TRelated>> relatedObjectSelector)
        {
            return new FakeFetchRequest<TOriginating, TRelated>(query);
        }

        public IFetchRequest<TOriginating, TRelated> FetchMany<TOriginating, TRelated>(IQueryable<TOriginating> query,
            Expression<Func<TOriginating, IEnumerable<TRelated>>> relatedObjectSelector)
        {
            return new FakeFetchRequest<TOriginating, TRelated>(query);
        }

        public IFetchRequest<TQueried, TRelated> ThenFetch<TQueried, TFetch, TRelated>(IFetchRequest<TQueried, TFetch> query,
            Expression<Func<TFetch, TRelated>> relatedObjectSelector)
        {
            var impl = query as FakeFetchRequest<TQueried, TFetch>;
            return new FakeFetchRequest<TQueried, TRelated>(impl.query);
        }

        public IFetchRequest<TQueried, TRelated> ThenFetchMany<TQueried, TFetch, TRelated>(IFetchRequest<TQueried, TFetch> query,
            Expression<Func<TFetch, IEnumerable<TRelated>>> relatedObjectSelector)
        {
            var impl = query as FakeFetchRequest<TQueried, TFetch>;
            return new FakeFetchRequest<TQueried, TRelated>(impl.query);
        }
    }
}