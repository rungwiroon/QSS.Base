using Qss.Base.Models;
using Qss.Base.Patterns;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Qss.Repository.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        protected DbContext _dbContext;
        protected DbContextTransaction _transaction;

        protected object _locker = new object();
        protected Dictionary<Type, IRepository> _repositoryList = new Dictionary<Type, IRepository>();

        public EfUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;

            _dbContext.Database.BeginTransaction();
        }

        public void ClearCache()
        {
            var dbSetProperties = _dbContext.GetDbSetProperties();

            foreach(var propertyInfo in dbSetProperties)
            {
                var dbSet = (dynamic)propertyInfo.GetValue(_dbContext);
                dbSet.Local.Clear();
            }
        }

        public virtual void Commit()
        {
            _transaction.Commit();
        }

        public virtual void Dispose()
        {
            DisposeSession();
        }

        public virtual void Flush()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Rollback()
        {
            _transaction.Rollback();
        }

        protected virtual object GetObject(Type type)
        {
            object repo;

            lock (_locker)
            {
                if (!_repositoryList.ContainsKey(type))
                {
                    repo = Activator.CreateInstance(type, _dbContext);

                    _repositoryList.Add(type, (IRepository)repo);
                }
                else
                {
                    repo = _repositoryList[type];
                }
            }

            return repo;
        }

        public virtual IRepository<T> GetRepository<T>()
            where T : class, IEntity, new()
        {
            var repository = (IRepository<T>)GetObject(typeof(EfRepository<T>));

            return repository;
        }

        public virtual object GetRepository(Type type)
        {
            return GetObject(type);
        }

        public void Lock(object obj)
        {
            throw new NotImplementedException();
        }

        public void Unlock(object obj)
        {
            throw new NotImplementedException();
        }

        public void Attach(object obj)
        {
            throw new NotImplementedException();
        }

        public void Detach(object obj)
        {
            throw new NotImplementedException();
        }

        public void DisposeSession()
        {
            _dbContext.Dispose();
        }
    }
}
