using Task16.Domain;
using NHibernate.Cfg;
using NHibernate;

namespace Task16.Repositories;

public class NHibernateHelper
{
    private static ISessionFactory _sessionFactory;

    private static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory is null)
            {
                var configuration = new Configuration();
                configuration.Configure();
               // configuration.AddAssembly(typeof(Person).Assembly);
               // configuration.AddAssembly(typeof(Car).Assembly);
                _sessionFactory = configuration.BuildSessionFactory();
            }

            return _sessionFactory;
        }
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }
}