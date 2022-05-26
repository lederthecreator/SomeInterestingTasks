namespace Task16.Domain;

public interface IPersonRepository
{
    void Add(Person person);
    void Update(Person person);
    void Remove(Person person);

    Person GetById(Guid personId);
    Person GetByName(string name);
}