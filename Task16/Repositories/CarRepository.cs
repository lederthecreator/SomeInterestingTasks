using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transaction;
using Task16.Domain;
namespace Task16.Repositories;

public class CarRepository : ICarRepository
{
    public void Add(Car car)
    {
        using ISession session = NHibernateHelper.OpenSession();
        using ITransaction transaction = session.BeginTransaction();
        session.Save(car);
        transaction.Commit();
    }

    public void Update(Car car)
    {
        using ISession session = NHibernateHelper.OpenSession();
        using ITransaction transaction = session.BeginTransaction();
        session.Update(car);
        transaction.Commit();
    }

    public void Delete(Car car)
    {
        using ISession session = NHibernateHelper.OpenSession();
        using ITransaction transaction = session.BeginTransaction();
        session.Delete(car);
        transaction.Commit();
    }

    public Car GetById(int carId)
    {
        using ISession session = NHibernateHelper.OpenSession();
        return session.Get<Car>(carId);
    }

    public Car GetByModelName(string name)
    {
        using ISession session = NHibernateHelper.OpenSession();
        Car car = session
            .CreateCriteria(typeof(Car))
            .Add(Restrictions.Eq("model_name", name))
            .UniqueResult<Car>();
        return car;
    }
    
    public ICollection<Car> GetAllData()
    {
        using ISession session = NHibernateHelper.OpenSession();
        using ITransaction transaction = session.BeginTransaction();
        var cars = session.CreateCriteria<Car>().List<Car>();
        transaction.Commit();
        return cars;
    }

    public ICollection<Car> GetByYear(int year)
    {
        using ISession session = NHibernateHelper.OpenSession();
        ICollection<Car> cars = session
            .CreateCriteria(typeof(Car))
            .Add(Restrictions.Eq("Year", year))
            .List<Car>();
        return cars;
    }
}