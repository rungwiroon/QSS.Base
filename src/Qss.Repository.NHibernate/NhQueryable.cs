using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Qss.Repository.NHibernate
{
    public class NhQueryable<T> : IQueryable<T>
    {
        private IQueryable<T> _queryable;

        public NhQueryable(ISession session)
        {
            _queryable = session.Query<T>();
        }

        public Expression Expression
        {
            get
            {
                return _queryable.Expression;
            }
        }

        public Type ElementType
        {
            get
            {
                return _queryable.ElementType;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return _queryable.Provider;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queryable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queryable.GetEnumerator();
        }
    }
}
