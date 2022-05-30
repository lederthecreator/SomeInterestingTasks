namespace Task19.Domain;

public interface IWorkerRepository
{
    public void Add(Worker worker);
    public void Update(Worker worker);
    public void Delete(Worker worker);

    public Worker GetById(int id);
    public ICollection<Worker> GetByName(string name);
    public ICollection<Worker> GetByLogin(string name);

    public ICollection<Worker> GetAllData();
}