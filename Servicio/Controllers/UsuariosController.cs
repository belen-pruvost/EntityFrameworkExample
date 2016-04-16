using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Example.Common.Contracts.Services;
using Example.Domain.Entities;

namespace Servicio.Controllers
{
    public class UsuariosController : ApiController
    {

        #region Private Members

        private readonly IUsuariosService usuariosService;

        #endregion

        #region Constructor

        /// <summary>
        /// The contructor for UsuariosController.
        /// </summary>        
        public UsuariosController(IUsuariosService usuariosService)
        {
            try
            {
                this.usuariosService = usuariosService;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all usuarios
        /// </summary>
        /// <returns>A collection of usuarios.</returns>
        [HttpGet]
        [Route("Usuarios")]
        public async Task<IQueryable<Usuario>> GetUsuariosAsync()
        {
            try
            {
                var result = await usuariosService.GetUsuariosAsync();
                return result.AsQueryable();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the name of an usuario.
        /// </summary>
        /// <param name="usuario">The usuario</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Usuarios")]
        public bool UpdateUsuarioValue([FromBody] Usuario usuario)
        {
            try
            {
                return usuariosService.UpdateUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }

}