using Domain.Interfaces.Generics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infrastructure.Repository.Generics
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryGenerics(DbContextOptions<ContextBase> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }

        public async Task Add(T obj)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T obj)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                data.Set<T>().Remove(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                T? t = await data.Set<T>().FindAsync(id);
                return t;
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task update(T obj)
        {
            using var data = new ContextBase(_optionsBuilder);
            data.Set<T>().Update(obj);
            await data.SaveChangesAsync();
        }


        #region Disposed

        bool dispoded = false;

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose(bool disposing)
        {
            if (dispoded)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            dispoded = true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
