using Example.Domain.Entities;

namespace Example.Common.Contracts.Repositories
{
    public interface IUsuarioRepository : IEntityRepository<Usuario>
    {
        void Save();
        Usuario FindByName(string name);


    }
}