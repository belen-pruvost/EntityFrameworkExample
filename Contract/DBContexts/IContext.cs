using System;
using System.Threading.Tasks;

namespace Example.Common.Contracts.DBContexts
{
    public interface IContext : IDisposable
    {
        int SaveChanges();
        void SetModified(object entity);
        void SetAdd(object entity);
        Task<int> SaveChangesAsync();

    }
}