using Qss.Base.Models;
using Qss.Base.Patterns;
using Qss.Base.Queries;
using Qss.TestBase.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qss.TestBase.Patterns
{
    public class FakeRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        protected ICollection<T> _list;

        static FakeRepository()
        {
            IQueryableExtension.FetchingProvider = () => new FakeFetchingProvider();
            IQueryableExtension.FutureProvider = () => new FakeFutureProvider();
            IQueryableExtension.AsyncProvider = () => new FakeAsyncProvider();
        }

        public FakeRepository(ICollection<T> collection)
        {
            _list = collection;
        }

        public T Get<TId>(TId id) where TId : struct
        {
            return _list.SingleOrDefault(l => ((IEntityKey<TId>)l).Id.Equals(id));
        }

        public object Create(T dbModel)
        {
            dynamic dbModelDyn = dbModel;

            if(!IsSubclassOfRawGeneric(typeof(IEntityKey<>), typeof(T)))
            {
                return null;
            }

            if (!(dbModelDyn.Id is int) 
                && !(dbModelDyn.Id is long))
            {
                return dbModelDyn.Id;
            }

            int lastId = default(int);

            if (_list.Any())
            {
                lastId = _list.Max(l => ((dynamic)l).Id);
            }

            lastId++;

            dbModelDyn.Id = lastId;

            _list.Add(dbModel);

            return lastId;
        }

        private static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }

        public void Update(T dbModel)
        {

        }

        public void Delete(T dbModel)
        {
            dynamic dbModelDyn = dbModel;

            if (IsSubclassOfRawGeneric(typeof(IEntityKey<>), typeof(T)))
            {
                var obj = _list.SingleOrDefault(l => (bool)(((dynamic)l).Id).Equals(
                (dbModelDyn.Id)));
                _list.Remove(obj);
            }

            else
            {
                var obj = _list.SingleOrDefault(l => l.Equals(dbModelDyn));
                _list.Remove(obj);
            }
        }

        public void Delete<TId>(TId id) where TId : struct
        {
            if (IsSubclassOfRawGeneric(typeof(IEntityKey<>), typeof(T)))
            {
                var obj = _list.SingleOrDefault(l => ((IEntityKey<TId>)l).Id.Equals(id));
                _list.Remove(obj);
            }
        }

        public IQueryable<T> Query
        {
            get
            {
                return _list.AsQueryable();
            }
        }

        public Task<T> GetAsync<TId>(TId id, CancellationToken cancellationToken = default(CancellationToken)) where TId : struct
        {
            return Task.FromResult(Get(id));
        }

        public Task<object> CreateAsync(T dbModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(Create(dbModel));
        }

        public Task UpdateAsync(T dbModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => Update(dbModel));
        }

        public Task DeleteAsync(T dbModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => Delete(dbModel));
        }

        public Task DeleteAsync<TId>(TId id, CancellationToken cancellationToken = default(CancellationToken)) where TId : struct
        {
            return Task.Run(() => Delete(id));
        }
    }
}
