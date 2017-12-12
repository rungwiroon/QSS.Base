using Qss.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Qss.Base.Services
{
    public class ServiceOrderByList<T>
    {
        private SortedDictionary<string, Expression<Func<T, dynamic>>> dictionary
            = new SortedDictionary<string, Expression<Func<T, dynamic>>>();

        public void Add(string propertyName, Expression<Func<T, dynamic>> expression)
        {
            dictionary.Add(propertyName, expression);
        }

        public IQueryable<T> CreateQuery(IQueryable<T> query, GridRequestModel gridRequestModel)
        {
            return CreateQuery(query, gridRequestModel.Sidx, gridRequestModel.IsSortAsending);
        }

        public IQueryable<T> CreateQuery(IQueryable<T> query, string propertyName, bool isSortAscending)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                propertyName = dictionary.First().Key;

            if (isSortAscending)
            {
                query = query.OrderBy(dictionary[propertyName]);
            }
            else
            {
                query = query.OrderByDescending(dictionary[propertyName]);
            }

            return query;
        }
    }
}