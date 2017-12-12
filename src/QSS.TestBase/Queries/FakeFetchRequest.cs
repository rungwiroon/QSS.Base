using Qss.Base.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Qss.TestBase.Queries
{
    public class FakeFetchRequest<TQueried, TFetch> : IFetchRequest<TQueried, TFetch>
    {
        public readonly IQueryable<TQueried> query;

        public IEnumerator<TQueried> GetEnumerator()
        {
            return query.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return query.GetEnumerator();
        }

        public Type ElementType
        {
            get { return query.ElementType; }
        }

        public Expression Expression
        {
            get { return query.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return query.Provider; }
        }

        public FakeFetchRequest(IQueryable<TQueried> query)
        {
            this.query = query;
        }
    }
}
