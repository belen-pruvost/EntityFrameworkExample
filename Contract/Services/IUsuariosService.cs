using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Domain.Entities;

namespace Example.Common.Contracts.Services
{
    public interface IUsuariosService
    {
        /// <summary>
        /// Devuelve todos los usuarios
        /// </summary>
        /// <returns>Una coleccion de usuarios.</returns>
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
        /// <summary>
        /// Actualiza un usuario asincrónicamente
        /// </summary>
        bool UpdateUsuario(Usuario metric);

    }
}