using Qss.Base.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Qss.Repository.EntityFramework
{
    public class EfFetchingProvider : IFetchingProvider
    {
        public IFetchRequest<TOriginating, TRelated> Fetch<TOriginating, TRelated>(IQueryable<TOriginating> query, Expression<Func<TOriginating, TRelated>> relatedObjectSelector)
        {
            throw new NotImplementedException();
        }

        public IFetchRequest<TOriginating, TRelated> FetchMany<TOriginating, TRelated>(IQueryable<TOriginating> query, Expression<Func<TOriginating, IEnumerable<TRelated>>> relatedObjectSelector)
        {
            throw new NotImplementedException();
        }

        public IFetchRequest<TQueried, TRelated> ThenFetch<TQueried, TFetch, TRelated>(IFetchRequest<TQueried, TFetch> query, Expression<Func<TFetch, TRelated>> relatedObjectSelector)
        {
            throw new NotImplementedException();
        }

        public IFetchRequest<TQueried, TRelated> ThenFetchMany<TQueried, TFetch, TRelated>(IFetchRequest<TQueried, TFetch> query, Expression<Func<TFetch, IEnumerable<TRelated>>> relatedObjectSelector)
        {
            throw new NotImplementedException();
        }
    }
}
