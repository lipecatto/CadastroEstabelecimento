using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Context;

namespace WebApplication1.Repository.Infra
{
    public abstract class RepositoryBase : IDisposable
    {
        protected readonly FitCardContext Contexto;
        private bool _disposed;

        protected RepositoryBase(FitCardContext contexto)
        {
            Contexto = contexto;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Contexto.Dispose();
                }
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}