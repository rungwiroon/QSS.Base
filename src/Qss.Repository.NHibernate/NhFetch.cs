using NHibernate.Linq;
using Qss.Base.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Qss.Repository.NHibernate
{
    internal class NhFetch<TQuery, TFetch> : IFetchRequest<TQuery, TFetch>
    {
        public INhFetchRequest<TQuery, TFetch> NhFetchRequest { get; private set; }

        //this is the real deal for NHibernate queries
        internal NhFetch(INhFetchRequest<TQuery, TFetch> realFetchRequest)
        {
            this.NhFetchRequest = realFetchRequest;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can
        /// be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<TQuery> GetEnumerator()
        {
            return (NhFetchRequest).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object
        /// that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (NhFetchRequest).GetEnumerator();
        }

        /// <summary>
        /// Gets the expression tree that is associated with the instance of
        /// <see cref="T:System.Linq.IQueryable"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Linq.Expressions.Expression"/> that is
        /// associated with this instance of <see cref="T:System.Linq.IQueryable"/>.
        /// </returns>
        public Expression Expression
        {
            get { return (NhFetchRequest).Expression; }
        }

        /// <summary>
        /// Gets the type of the element(s) that are returned when the expression
        /// tree associated with this instance of
        /// <see cref="T:System.Linq.IQueryable"/> is executed.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Type"/> that represents the type of the
        /// element(s) that are returned when the expression tree associated
        /// with this object is executed.
        /// </returns>
        public Type ElementType
        {
            get { return (NhFetchRequest).ElementType; }
        }

        /// <summary>
        /// Gets the query provider that is associated with this data source.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Linq.IQueryProvider"/> that is associated
        /// with this data source.
        /// </returns>
        public IQueryProvider Provider
        {
            get { return (NhFetchRequest).Provider; }
        }
    }
}