using FluentNHibernate.Cfg; 
using FluentNHibernate.Cfg.Db; 
using NHibernate;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;

namespace Task20;

public class NHibernateHelper
{
    private static ISessionBuilder _sessionFactory;

    private static ISessionBuilder SessionFactory
    {
        get
        {
            if (_sessionFactory is null) InitializeSessionFactory();
            return _sessionFactory!;
        }
    }

    private static void InitializeSessionFactory()
    {
        _sessionFactory = Fluently
                .Configure()
                .Database(
                PostgreSQLConfiguration.Standard
                .ConnectionString("Server=213.226.68.154;Database=Internship;User ID=postgres;Password=root;Enlist=true;")
                .Dialect("NHibernate.Dialect.PostgreSQL83Dialect")
                )
            
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Fluenter>())
            .ExposeConfiguration(cfg => { new SchemaExport(cfg).Create(false, true); })
            .BuildSessionFactory()
            .WithOptions()
            .Interceptor(new MyInterceptor())
            ;
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }
}