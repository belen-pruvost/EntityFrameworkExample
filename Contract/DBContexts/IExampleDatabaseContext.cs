using Example.Domain.Entities;
using System.Data.Entity;

namespace Example.Common.Contracts.DBContexts
{
    public interface IExampleDatabaseContext : IContext
    {
        IDbSet<Usuario> Usuarios { get; }
        void SetDeleted(object entity);
    }
}
