using Task19.Domain;

namespace Task19.Repositories;

public class WorkerRepository : IWorkerRepository
{
    public WorkerRepository(){}
    
    public void Add(Worker worker)
    {
        using var session = NHibernateHelper.OpenSession();
        using var transaction = session.BeginTransaction();
        session.Save(worker);
        transaction.Commit();
    }

    public void Update(Worker worker)
    {
        using var session = NHibernateHelper.OpenSession();
        using var transaction = session.BeginTransaction();
        session.Update(worker);
        transaction.Commit();
    }

    public void Delete(Worker worker)
    {
        using var session = NHibernateHelper.OpenSession();
        using var transaction = session.BeginTransaction();
        session.Delete(worker);
        transaction.Commit();
    }

    public Worker GetById(int id)
    {
        using var session = NHibernateHelper.OpenSession();
        return session.Get<Worker>(id);
    }

    public ICollection<Worker> GetByName(string name)
    {
        using var session = NHibernateHelper.OpenSession();
        var result = session.Query<Worker>()
            .Where(worker => worker.Name == name)
            .ToList();
        return result;
    }

    public ICollection<Worker> GetByLogin(string login)
    {
        using var session = NHibernateHelper.OpenSession();
        var result = session.Query<Worker>()
            .Where(worker => worker.Login == login)
            .ToList();
        return result;
    }

    public ICollection<Worker> GetAllData()
    {
        using var session = NHibernateHelper.OpenSession();
        var result = session.Query<Worker>().ToList();
        return result;
    }
}