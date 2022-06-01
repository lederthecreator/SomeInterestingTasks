using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Task21.Domain;

namespace Task21;

public class NHibernateHelper
{
    private static ISessionFactory _sessionFactory;
    private static ISessionFactory SessionFactory
    {
        get
        {
            if(_sessionFactory is null)
                _sessionFactory = Fluently
                    .Configure()
                    .Database(PostgreSQLConfiguration.PostgreSQL82
                        .ConnectionString(c =>
                    
                            c.Host("213.226.68.154")
                                .Port(5432)
                                .Database("Internship")
                                .Username("postgres")
                                .Password("root")
                        )
                        .AdoNetBatchSize(25)
                        .ShowSql()
                    )
                    .Cache(cache =>
                        cache.UseQueryCache()
                            .UseMinimalPuts()
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Car>())
                    .ExposeConfiguration(cfg => {new SchemaExport(cfg).Create(false, true);})
                    .BuildSessionFactory();
            return _sessionFactory;
        }
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }
}