using Qss.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Qss.Base.Queries
{
    public static class IQueryableExtension
    {
        public static Func<IFetchingProvider> FetchingProvider;
        public static Func<IFutureProvider> FutureProvider;
        public static Func<IAsyncProvider> AsyncProvider;

        public static IFetchRequest<TQuery, TFetch> Fetch<TQuery, TFetch>(this IQueryable<TQuery> query,
            Expression<Func<TQuery, TFetch>> selector)
        {
            return FetchingProvider().Fetch(query, selector);
        }

        public static IFetchRequest<TQuery, TFetch> FetchMany<TQuery, TFetch>(this IQueryable<TQuery> query,
            Expression<Func<TQuery, IEnumerable<TFetch>>> selector)
        {
            return FetchingProvider().FetchMany(query, selector);
        }

        public static IFetchRequest<T, TRel2> ThenFetch<T, TRel, TRel2>(this IFetchRequest<T, TRel> fetchRequest,
            Expression<Func<TRel, TRel2>> selector)
        {
            return FetchingProvider().ThenFetch(fetchRequest, selector);
        }

        public static IFetchRequest<T, TRel2> ThenFetchMany<T, TRel, TRel2>(this IFetchRequest<T, TRel> fetchRequest,
            Expression<Func<TRel, IEnumerable<TRel2>>> selector)
        {
            return FetchingProvider().ThenFetchMany(fetchRequest, selector);
        }
        
        public static IOrderedQueryable<T> OrderBy<T, U>(this IQueryable<T> query, Expression<Func<T, U>> keySelector, bool isAsecending)
        {
            if (isAsecending) return query.OrderBy(keySelector);
            else return query.OrderByDescending(keySelector);
        }

        /// <summary>
		/// Wraps the query in a deferred <see cref="IFutureEnumerable{T}"/> which enumeration will trigger a batch of all pending future queries.
		/// </summary>
		/// <param name="source">An <see cref="T:System.Linq.IQueryable`1" /> to convert to a future query.</param>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
		/// <returns>A <see cref="IFutureEnumerable{T}"/>.</returns>
		/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is <see langword="null"/>.</exception>
		/// <exception cref="T:System.NotSupportedException"><paramref name="source" /> <see cref="IQueryable.Provider"/> is not a <see cref="INhQueryProvider"/>.</exception>
		public static IFutureEnumerable<TSource> ToFuture<TSource>(this IQueryable<TSource> source)
        {
            return FutureProvider().ToFuture(source);
        }

        /// <summary>
        /// Wraps the query in a deferred <see cref="IFutureValue{T}"/> which will trigger a batch of all pending future queries
        /// when its <see cref="IFutureValue{T}.Value"/> is read.
        /// </summary>
        /// <param name="source">An <see cref="T:System.Linq.IQueryable`1" /> to convert to a future query.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <returns>A <see cref="IFutureValue{T}"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is <see langword="null"/>.</exception>
        /// <exception cref="T:System.NotSupportedException"><paramref name="source" /> <see cref="IQueryable.Provider"/> is not a <see cref="INhQueryProvider"/>.</exception>
        public static IFutureValue<TSource> ToFutureValue<TSource>(this IQueryable<TSource> source)
        {
            return FutureProvider().ToFutureValue(source);
        }

        /// <summary>
        /// Wraps the query in a deferred <see cref="IFutureValue{T}"/> which will trigger a batch of all pending future queries
        /// when its <see cref="IFutureValue{T}.Value"/> is read.
        /// </summary>
        /// <param name="source">An <see cref="T:System.Linq.IQueryable`1" /> to convert to a future query.</param>
        /// <param name="selector">An aggregation function to apply to <paramref name="source"/>.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by the function represented by <paramref name="selector"/>.</typeparam>
        /// <returns>A <see cref="IFutureValue{T}"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is <see langword="null"/>.</exception>
        /// <exception cref="T:System.NotSupportedException"><paramref name="source" /> <see cref="IQueryable.Provider"/> is not a <see cref="INhQueryProvider"/>.</exception>
        public static IFutureValue<TResult> ToFutureValue<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<IQueryable<TSource>, TResult>> selector)
        {
            return FutureProvider().ToFutureValue(source, selector);
        }

        /// <summary>Returns the only element of a sequence, or a default value if the sequence is empty; this method throws an exception if there is more than one element in the sequence.</summary>
		/// <param name="source">The <see cref="T:System.Linq.IQueryable`1" /> to return the single element of.</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
		/// <returns>default(<paramref name="source" />) if <paramref name="source" /> is empty; otherwise, the single element in <paramref name="source" />.</returns>
		/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is <see langword="null"/>.</exception>
		/// <exception cref="T:System.NotSupportedException"><paramref name="source" /> <see cref="IQueryable.Provider"/> is not a <see cref="INhQueryProvider"/>.</exception>
        public static Task<TSource> SingleOrDefaultAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken = default(CancellationToken))
        {
            return AsyncProvider().SingleOrDefaultAsync(source, cancellationToken);
        }

        public static Task<List<TSource>> ToListAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken = default(CancellationToken))
        {
            return AsyncProvider().ToListAsync(source, cancellationToken);
        }

        public static PagingResultModel<TQuery> ToPagingResult<TQuery>(this IQueryable<TQuery> query, GridRequestModel gridRequest)
        {
            var rowCount = query.ToFutureValue(q => q.Count());

            var query1 = query
                .Skip((gridRequest.Page - 1) * gridRequest.Rows)
                .Take(gridRequest.Rows);

            var dbModel = query1.ToList();

            var gridData = new PagingResultModel<TQuery>(dbModel, rowCount.Value);

            return gridData;
        }

        public static Task<PagingResultModel<TQuery>> ToPagingResultAsync<TQuery>(this IQueryable<TQuery> query, GridRequestModel gridRequest)
        {
            var rowCount = query.ToFutureValue(q => q.Count());

            var query1 = query
                .Skip((gridRequest.Page - 1) * gridRequest.Rows)
                .Take(gridRequest.Rows);

            var gridData = query1.ToListAsync()
                .ContinueWith(antecendent => new PagingResultModel<TQuery>(antecendent.Result, rowCount.Value));

            return gridData;
        }
    }
}