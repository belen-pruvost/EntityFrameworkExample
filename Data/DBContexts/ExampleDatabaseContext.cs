using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Example.Common.Contracts.DBContexts;
using Example.Common.Data.Mappings;
using Example.Domain.Entities;


namespace Example.Common.Data.DBContexts
{

    public class ExampleDatabaseContext : BaseContext<ExampleDatabaseContext>, IExampleDatabaseContext
    {
        public IDbSet<Usuario> Usuarios { get; set; }        

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void SetAdd(object entity)
        {
            Entry(entity).State = EntityState.Added;
        }

        public void SetDeleted(object entity)
        {
            Entry(entity).State = EntityState.Deleted;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Usuario>(new UsuarioMap());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
