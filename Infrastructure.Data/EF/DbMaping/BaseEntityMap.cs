using System;
using System.Runtime.InteropServices;
using Core.Domain.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;

namespace Infrastructure.Data.EF.DbMaping
{
    public abstract class BaseEntityMap<T>: IDisposable where T:BaseEntity
    {
        bool _disposed = false;
        readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        public virtual void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>(entity => {

                entity.ToTable($"tbl_{typeof(T).Name}");
                

            });
        }


        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _handle.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseEntityMap()
        {
            Dispose(false);
        }
    }
}
