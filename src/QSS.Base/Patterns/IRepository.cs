using LanguageExt;
using Qss.Base.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Qss.Base.Patterns
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository
        where T : class, IEntity
    {
        Option<T> Get<TId>(TId id)
            where TId : struct;
        Task<Option<T>> GetAsync<TId>(TId id,
            CancellationToken cancellationToken = default(CancellationToken))
            where TId : struct;

        object Create(T dbModel);
        Task<object> CreateAsync(T dbModel,
            CancellationToken cancellationToken = default(CancellationToken));

        void Update(T dbModel);
        Task UpdateAsync(T dbModel,
            CancellationToken cancellationToken = default(CancellationToken));

        void Delete(T dbModel);
        Task DeleteAsync(T dbModel,
            CancellationToken cancellationToken = default(CancellationToken));

        void Delete<TId>(TId id)
            where TId : struct;

        Task DeleteAsync<TId>(TId id,
            CancellationToken cancellationToken = default(CancellationToken))
            where TId : struct;

        IQueryable<T> Query { get; }
    }
}