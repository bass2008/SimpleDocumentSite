using AlphaLeasing.DataAccess.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace AlphaLeasing.DataAccess.Configuration
{
    public static class NHibernateConfiguration
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString
                         (@"Server=localhost\SQLEXPRESS;Database=testDb;Trusted_Connection=True"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DocumentsMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, false))
                .BuildSessionFactory();
        }
    }
}
