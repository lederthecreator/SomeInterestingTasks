using Task20;

using var session = NHibernateHelper.OpenSession();
using var tx = session.BeginTransaction();

var fluenter = new Fluenter()
{
    FirstName = "Leder",
    LastName = "Alexandr"
};
session.Save(fluenter);
tx.Commit();

var getFluenter = session.Get<Fluenter>(1);
Console.WriteLine($"Get fluenter: {getFluenter.FirstName} {getFluenter.LastName}");