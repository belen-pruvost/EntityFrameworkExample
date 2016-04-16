using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Example.Common.Contracts.Repositories
{
    public interface IEntityRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        T Find(string id);

        void InsertOrUpdate(T programEntity);

        void Delete(string id);

        Task<T> FindAsync(string id);
    }
}