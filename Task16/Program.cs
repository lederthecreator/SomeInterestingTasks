using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Transaction;
using Task16.Domain;
using Task16.Repositories;

var car = new Car(){ModelName = "Priora", Year = 2000, ModelClass = Class.Cheap};
var car2 = new Car{ModelName = "Granta", Year = 2000, ModelClass = Class.Average};
var car3 = new Car{ModelName = "Vesta", Year = 2020, ModelClass = Class.Luxury};

var repo = new CarRepository();
using ISession session = NHibernateHelper.OpenSession();
using ITransaction transaction = session.BeginTransaction();
for (var i = 0; i < 25; i += 1)
{
    var cr = new Car
    {
        ModelName = $"Model{i}", Year = 2000 + i, ModelClass = (Class) (i % 3),
        Owner = new Person
        {
            FirstName = $"Firstname{i}",
            LastName = $"LastName{i}",
            Age = 18 + i
        }
    };
    session.Save(cr);
}
transaction.Commit();

