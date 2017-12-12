using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qss.Base.Queries
{
    /// <summary>
	/// <para>A deferred query result. Accessing its enumerable result will trigger execution of all other pending futures.</para>
	/// <para>This interface is directly usable as a <see cref="IEnumerable{T}"/> for backward compatibility, but this will
	/// be dropped in a later version. Please get the <see cref="IEnumerable{T}"/> from <see cref="IFutureEnumerable{T}.GetEnumerable"/>
	/// or <see cref="IFutureEnumerable{T}.GetEnumerableAsync(CancellationToken)"/>.</para>
	/// </summary>
	/// <typeparam name="T">The type of the enumerated elements.</typeparam>
	public interface IFutureEnumerable<T>
    {
        /// <summary>
        /// Asynchronously triggers the future query and all other pending future if the query was not already resolved, then
        /// returns a non-deferred enumerable of the query resulting items.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>A non-deferred enumerable listing the resulting items of the future query.</returns>
        Task<IEnumerable<T>> GetEnumerableAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Synchronously triggers the future query and all other pending future if the query was not already resolved, then
        /// returns a non-deferred enumerable of the query resulting items.
        /// </summary>
        /// <returns>A non-deferred enumerable listing the resulting items of the future query.</returns>
        IEnumerable<T> GetEnumerable();
    }
}
