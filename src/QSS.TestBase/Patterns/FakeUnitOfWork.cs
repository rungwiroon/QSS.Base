using Qss.Base.Models;
using Qss.Base.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qss.TestBase.Patterns
{
    public class FakeUnitOfWork
    {
        protected object _locker = new object();
        protected Dictionary<Type, IRepository> Repositories { get; private set; }

        public FakeUnitOfWork()
        {
            Repositories = new Dictionary<Type, IRepository>();
        }

        public FakeUnitOfWork(IEnumerable<IRepository> repositories)
            : this()
        {
            foreach(var repository in repositories)
            {
                var repoType = repository.GetType();

                if (repoType.IsGenericType)
                {
                    Type type = repoType.GetGenericArguments()[0];

                    Repositories.Add(type, repository);
                }
            }
        }

        public FakeUnitOfWork(Dictionary<Type, IRepository> repositories)
        {
            Repositories = repositories;
        }

        public bool HasErrors => throw new NotImplementedException();

        public void Attach(object obj)
        {
        }

        public void ClearCache()
        {
        }

        public void Commit()
        {
        }

        public void Detach(object obj)
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void DisposeSession()
        {
        }

        public void Flush()
        {
        }

        public Task FlushAsync()
        {
            throw new NotImplementedException();
        }

        public int GetNextSequenceValue(string sequenceName)
        {
            throw new NotImplementedException();
        }

        public void Lock(object obj)
        {
        }

        public IQueryable<T> Query<T>()
        {
            throw new NotImplementedException();
        }

        public void ResetSequenceValue(string sequenceName, int value)
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
        }

        public void Unlock(object obj)
        {
        }

        protected object GetObject(Type type)
        {
            object repo = null;

            lock (_locker)
            {
                if (Repositories.ContainsKey(type))
                {
                    repo = Repositories[type];
                }
            }

            return repo;
        }

        public IRepository<T> GetRepository<T>()
            where T : class, IEntity
        {
            return (IRepository<T>)GetObject(typeof(T));
        }

        public object GetRepository(Type type)
        {
            return GetObject(type);
        }
    }
}
