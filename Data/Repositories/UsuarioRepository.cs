using Example.Common.Contracts.DBContexts;
using Example.Common.Contracts.Repositories;
using Example.Common.Data.BaseDataLayer;

namespace Example.Common.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using DBContexts;
    using Domain.Entities;

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IExampleDatabaseContext _context;

        public UsuarioRepository(IUnitOfWork<IExampleDatabaseContext> uow)
        {
            _context = uow.Context;
        }


        public IQueryable<Usuario> AllIncluding(params Expression<Func<Usuario, object>>[] includeProperties)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public IQueryable<Usuario> All
        {
            get { return _context.Usuarios; }
        }

        public Usuario Find(string id)
        {
            long ID = Convert.ToInt64(id);
            return _context.Usuarios.FirstOrDefault(i => i.IdUsuario == ID);
        }

        public Usuario FindByName(string name)
        {
            return _context.Usuarios.FirstOrDefault(i => i.NombreUsuario == name);
        }

        public async Task<Usuario> FindAsync(string id)
        {
            long ID = Convert.ToInt64(id);
            return await _context.Usuarios.FirstOrDefaultAsync(i => i.IdUsuario == ID);
        }

        public void InsertOrUpdate(Usuario usuario)
        {
            if (usuario.IdUsuario != 0)
                _context.SetModified(usuario);
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public void Delete(string id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
        }


    }
}
