using System;
using System.Threading.Tasks;

namespace Example.Common.Contracts.DBContexts
{
    public interface IUnitOfWork<T> : IDisposable
        where T : IContext
    {
        int Save();

        Task<int> SaveAsync();
        T Context { get; }

    }
}
