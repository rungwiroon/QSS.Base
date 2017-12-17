using NHibernate;
using Qss.Base.Patterns;
using QSS.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qss.Repository.NHibernate
{
    public class NhUnitOfWork : IUnitOfWork
    {
        protected ISession _session;
        protected ITransaction _transaction;

        protected bool _supportDispose = true;

        protected IsolationLevel _isolationLevel = IsolationLevel.ReadCommitted;

        protected IEventLog _eventLog;

        protected object _locker = new object();
        protected Dictionary<Type, IRepository> _repositoryList = new Dictionary<Type, IRepository>();

        public bool HasErrors => throw new NotImplementedException();

        protected NhUnitOfWork()
        {
        }

        public NhUnitOfWork(ISession session, IEventLog eventLog)
        {
            _session = session;
            _eventLog = eventLog;

            BeginTransaction();
        }

        protected void BeginTransaction()
        {
            _transaction = _session.BeginTransaction(_isolationLevel);
        }

        public virtual void ClearCache()
        {
            _session.Clear();
        }

        public virtual void Commit()
        {
            if (_transaction.IsActive)
                _transaction.Commit();
        }

        public virtual void Dispose()
        {
            if (_supportDispose)
            {
                DisposeSession();
            }
        }

        public virtual void DisposeSession()
        {
            if (_transaction != null && _transaction.IsActive)
            {
                try
                {
                    _transaction.Dispose();
                }
                catch (Exception ex)
                {
                    _eventLog.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }

            try
            {
                _session.Dispose();
            }
            catch (Exception ex)
            {
                _eventLog.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
            }
        }

        public virtual void Flush()
        {
            _session.Flush();
        }

        public virtual Task FlushAsync()
        {
            return _session.FlushAsync();
        }

        public virtual void Lock(object obj)
        {
            _session.Lock(obj, LockMode.Upgrade);
        }

        public virtual void Attach(object obj)
        {
            _session.Merge(obj);
        }

        public virtual void Detach(object obj)
        {
            _session.Evict(obj);
        }

        public virtual void Rollback()
        {
            _transaction.Rollback();
        }

        public virtual void Unlock(object obj)
        {
            _session.Lock(obj, LockMode.None);
        }

        protected virtual T GetObject<T>()
        {
            return (T)GetObject(typeof(T));
        }

        protected virtual object GetObject(Type type)
        {
            object repo;

            lock (_locker)
            {
                if (!_repositoryList.ContainsKey(type))
                {
                    repo = Activator.CreateInstance(type, _session);

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
            where T : class
        {
            var repository = GetObject<NhRepository<T>>();

            return repository;
        }

        public virtual object GetRepository(Type type)
        {
            return GetObject(type);
        }

        public virtual int GetNextSequenceValue(string sequenceName)
        {
            var query = _session.CreateSQLQuery("select nextval('" + sequenceName + "')");

            var result = query.UniqueResult<long>();
            return (int)result;
        }

        public virtual void ResetSequenceValue(string sequenceName, int value)
        {
            var query = _session.CreateSQLQuery("ALTER SEQUENCE " + sequenceName + " RESTART WITH " + value + ";");

            query.UniqueResult();
        }

        public virtual IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }
    }
}
