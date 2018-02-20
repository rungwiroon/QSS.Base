using Qss.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Qss.Base.Queries
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static IOrderedEnumerable<T> OrderBy<T, TKey>
            (this IEnumerable<T> query, Func<T, TKey> keySelector, bool isAsecending)
        {
            if (isAsecending) return query.OrderBy(keySelector);
            else return query.OrderByDescending(keySelector);
        }

        public static PagingResultModel<TQuery> ToPagingResult<TQuery>(this IEnumerable<TQuery> query, GridRequestModel gridRequest)
        {
            var rowCount = query.Count();

            var query1 = query
                .Skip((gridRequest.Page - 1) * gridRequest.Rows)
                .Take(gridRequest.Rows);

            var dbModel = query1.ToList();

            var gridData = new PagingResultModel<TQuery>(dbModel, rowCount);

            return gridData;
        }
    }
}