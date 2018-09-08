using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Qss.Base.Patterns
{
    public class CriteriaBuilder<T>
    {
        List<(Func<bool> codition, Expression<Func<T, bool>> predicate)> _criteriaList
            = new List<(Func<bool> codition, Expression<Func<T, bool>>)>();

        public CriteriaBuilder<T> Add(Expression<Func<T, bool>> wherePredicate)
        {
            _criteriaList.Add((() => true, wherePredicate));

            return this;
        }

        public CriteriaBuilder<T> Add(bool checkValue, Expression<Func<T, bool>> wherePredicate)
        {
            if(checkValue)
            {
                Add(wherePredicate);
            }

            return this;
        }

        public CriteriaBuilder<T> Add(Func<bool> checkFunc, Expression<Func<T, bool>> wherePredicate)
        {
            _criteriaList.Add((checkFunc, wherePredicate));

            return this;
        }

        public IQueryable<T> Build(IQueryable<T> query)
        {
            foreach(var criteria in _criteriaList.Where(c => c.codition()))
            {
                query = query.Where(criteria.predicate);
            }

            return query;
        }
    }
}
