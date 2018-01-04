using Qss.Base.Models;
using Qss.Base.Patterns;
using Qss.Base.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qss.Repository.EntityFramework
{
    public class EfRepository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        protected DbSet<T> _dbSet;
        protected DbContext _dbContext;

        static EfRepository()
        {
            IQueryableExtension.FetchingProvider = () => new EfFetchingProvider();
            IQueryableExtension.FutureProvider = () => new EfFutureProvider();
            IQueryableExtension.AsyncProvider = () => new EfAsyncProvider();
        }

        public EfRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public T Get<TId>(TId id)
            where TId : struct
        {
            return _dbSet.Find(id);
        }

        public Task<T> GetAsync<TId>(TId id,
            CancellationToken cancellationToken = default(CancellationToken))
            where TId : struct
        {
            return _dbSet.FindAsync(cancellationToken, id);
        }

        public object Create(T dbModel)
        {
            dynamic model = _dbSet.Add(dbModel);
            _dbContext.SaveChanges();

            return model.Id;
        }

        public virtual async Task<object> CreateAsync(T dbModel,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            dynamic model = _dbSet.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return model.Id;
        }

        public void Update(T dbModel)
        {

        }

        public Task UpdateAsync(T dbModel,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult<object>(null);
        }

        public void Delete(T dbModel)
        {
            _dbSet.Remove(dbModel);
            _dbContext.SaveChanges();
        }

        public virtual async Task DeleteAsync(T dbModel,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbSet.Remove(dbModel);

            await _dbContext.SaveChangesAsync();
        }

        public virtual void Delete<TId>(TId id)
            where TId : struct
        {
            var model = (IEntityKey<TId>)(new T());
            model.Id = id;

            _dbSet.Attach((T)model);
            _dbSet.Remove((T)model);

            _dbContext.SaveChanges();
        }

        public virtual async Task DeleteAsync<TId>(TId id,
            CancellationToken cancellationToken = default(CancellationToken))
            where TId : struct
        {
            var model = (IEntityKey<TId>)(new T());
            model.Id = id;

            _dbSet.Attach((T)model);
            _dbSet.Remove((T)model);

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> Query
        {
            get
            {
                return _dbSet;
            }
        }
    }
}
