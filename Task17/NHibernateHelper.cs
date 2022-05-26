using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using Task17.Domain;

namespace Task17;

public static class NHibernateHelper
{
    private static ISessionFactory _sessionFactory; 

    private static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory is not null) return _sessionFactory;
            var configuration = new Configuration();
            //configuration.AddAssembly(Assembly.GetExecutingAssembly());
            configuration.Configure();
            _sessionFactory = configuration.BuildSessionFactory();
            return _sessionFactory;
        }
    }

    public static ISession GetSession()
    {
        return SessionFactory.OpenSession();
    }
}