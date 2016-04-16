using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;


namespace Example.Common.Data.DBContexts
{
    using System.Data.Entity;

    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        private Type _Hack = typeof(SqlProviderServices);

        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }
        protected BaseContext()
            : base("name=ExampleConnection")
        { }
    }
}