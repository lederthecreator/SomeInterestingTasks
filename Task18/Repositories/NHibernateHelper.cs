using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using Task18.Domain;
using Task20;

namespace Task18.Repositories;

public class NHibernateHelper
{
    private static ISessionBuilder _sessionFactory;

    private static ISessionBuilder SessionFactory
    {
        get
        {
            NHibernateLogger.SetLoggersFactory(new NLogLoggerFactory());
            if (_sessionFactory is null)
            {
                _sessionFactory = Fluently
                    .Configure()
                    .Database(
                        PostgreSQLConfiguration.PostgreSQL82.ConnectionString(
                                "Server=213.226.68.154;Database=Internship;User ID=postgres;Password=root;Enlist=true;")
                            .AdoNetBatchSize(25)
                            .ShowSql()
                            .FormatSql()
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Worker>())
                    //.ExposeConfiguration(cfg => { new SchemaExport(cfg).Create(false, true); })
                    .BuildSessionFactory()
                    .WithOptions()
                    .Interceptor(new MyInterceptor());
            }

            return _sessionFactory;
        }
    }
    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }
}