using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Qss.Base.Services
{
    public class ServiceSearchList<T, U>
    {
        private List<Tuple<Func<T, bool>, Func<T, Expression<Func<U, bool>>>>> expressions =
            new List<Tuple<Func<T, bool>, Func<T, Expression<Func<U, bool>>>>>();

        public void Add(Func<T, bool> expression1, Func<T, Expression<Func<U, bool>>> expression2)
        {
            expressions.Add(new Tuple<Func<T, bool>, Func<T, Expression<Func<U, bool>>>>(expression1, expression2));
        }

        public IQueryable<U> CreateQuery(IQueryable<U> query, T model)
        {
            foreach (var exp in expressions)
            {
                if (exp.Item1(model))
                {
                    query = query.Where(exp.Item2(model));
                }
            }

            return query;
        }
    }
}