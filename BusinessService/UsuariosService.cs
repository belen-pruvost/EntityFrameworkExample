using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Common.Contracts.Repositories;
using Example.Common.Contracts.Services;
using Example.Domain.Entities;

namespace Example.BusinessServices
{
    public class UsuariosService : IUsuariosService
    {
        #region Private Members

        private readonly IUsuarioRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        /// The contructor for UsuariosService.
        /// </summary>      
        public UsuariosService(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region Private Methods
        public IEnumerable<Usuario> GetUsuarios()
        {
            IEnumerable<Usuario> usuarios = new List<Usuario>();
            if (repository != null)
            {
                usuarios = repository.All.ToList();
            }
            return usuarios;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all usuarios asynchronically
        /// </summary>
        /// <returns>A collection of usuarios.</returns>
        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            try
            {
                var result = await Task.Run(() => GetUsuarios());
                return result.AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Updates an usuario asynchronically
        /// </summary>
        public bool UpdateUsuario(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    Usuario usuarioToUpdate = new Usuario();
                    usuarioToUpdate = repository.Find(usuario.IdUsuario.ToString());

                    if (usuarioToUpdate != null)
                    {
                        if (!string.IsNullOrEmpty(usuario.NombreUsuario))
                        {
                            usuarioToUpdate.NombreUsuario = usuario.NombreUsuario;
                        }

                        repository.InsertOrUpdate(usuarioToUpdate);
                        repository.Save();
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
