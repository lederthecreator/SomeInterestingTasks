using Task21.Domain;

namespace Task21;

public class CarRepository
{
    public static void Add(Car car)
    {
        using var session = NHibernateHelper.OpenSession();
        using var tx = session.BeginTransaction();
        session.Save(car);
        tx.Commit();
    }
}