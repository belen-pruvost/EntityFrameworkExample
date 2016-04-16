using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Example.Domain.Entities;

namespace Example.Common.Data.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.IdUsuario);

            // Properties

            this.Property(t => t.NombreUsuario)
                .HasMaxLength(50);
            

            // Table & Column Mappings
            this.ToTable("Usuarios");
        }
    }
}
