using NHibernate;
using NHibernate.Cfg;
using Task18.Domain;

namespace Task18.Repositories;

public class NHibernateHelper
{
    private static ISessionFactory _sessionFactory;

    private static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory is null)
            {
                var cfg = new Configuration();
                cfg.Configure();
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                //cfg.AddAssembly(typeof(Worker).Assembly);
                _sessionFactory = cfg.BuildSessionFactory();
            }
            return _sessionFactory;
        }
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }
}