using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Qss.Base.Patterns
{
    public interface IRepository
    {
        bool HasErrors { get; }
    }

    public interface IRepository<T> : IRepository
    {
        T Get<TId>(TId id)
            where TId : struct;
        Task<T> GetAsync<TId>(TId id,
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

        int GetNextSequenceValue();

        void ResetSequenceValue(int value);

        IQueryable<T> Query { get; }
    }
}