using System.Threading.Tasks;
using Example.Common.Contracts.DBContexts;

namespace Example.Common.Data.BaseDataLayer
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
    where TContext : IContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public TContext Context
        {
            get { return (TContext)_context; }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

    }
}

