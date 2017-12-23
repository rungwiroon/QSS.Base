using NHibernate;
using NHibernate.Linq;
using Qss.Base.Models;
using Qss.Base.Patterns;
using Qss.Base.Queries;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Qss.Repository.NHibernate
{
    public class NhRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        protected ISession _session;

        static NhRepository()
        {
            IQueryableExtension.FetchingProvider = () => new NhFetchingProvider();
            IQueryableExtension.FutureProvider = () => new NhFutureProvider();
            IQueryableExtension.AsyncProvider = () => new NhAsyncProvider();
        }

        public NhRepository(ISession session)
        {
            _session = session;
        }

        public T Get<TId>(TId id)
            where TId : struct
        {
            return _session.Get<T>(id);
        }

        public Task<T> GetAsync<TId>(TId id,
            CancellationToken cancellationToken = default(CancellationToken))
            where TId : struct
        {
            return _session.GetAsync<T>(id, cancellationToken);
        }

        public virtual object Create(T dbModel)
        {
            var id = _session.Save(dbModel);

            _session.Flush();

            return id;
        }

        public virtual async Task<object> CreateAsync(T dbModel,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var id = await _session.SaveAsync(dbModel, cancellationToken);

            await _session.FlushAsync();

            return id;
        }

        public void Update(T dbModel)
        {
            _session.Update(dbModel);
        }

        public Task UpdateAsync(T dbModel,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return _session.UpdateAsync(dbModel, cancellationToken);
        }

        public virtual void Delete(T dbModel)
        {
            _session.Delete(dbModel);
            _session.Flush();
        }

        public virtual async Task DeleteAsync(T dbModel,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _session.DeleteAsync(dbModel, cancellationToken);

            await _session.FlushAsync();
        }

        public virtual void Delete<TId>(TId id)
            where TId : struct
        {
            _session.Query<T>()
                .Where(e => (object)((IEntityKey<TId>)e).Id == (object)id)
                .Delete();
        }

        public virtual async Task DeleteAsync<TId>(TId id,
            CancellationToken cancellationToken = default(CancellationToken))
            where TId : struct
        {
            await _session.Query<T>()
                .Where(e => (object)((IEntityKey<TId>)e).Id == (object)id)
                .DeleteAsync(cancellationToken);
        }

        public IQueryable<T> Query
        {
            get
            {
                return _session.Query<T>();
            }
        }
    }
}
