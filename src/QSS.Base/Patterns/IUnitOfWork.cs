﻿using System;
using System.Linq;

namespace Qss.Base.Patterns
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>()
            where T : class;

        object GetRepository(Type type);

        void Commit();

        void Rollback();

        void Flush();

        void Lock(object obj);

        void Unlock(object obj);

        void ClearCache();

        void Attach(object obj);

        void Detach(object obj);

        void DisposeSession();
    }
}