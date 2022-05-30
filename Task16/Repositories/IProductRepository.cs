using Task16.Domain;

namespace Task16.Repositories;

public interface IProductRepository
{
    void Add(Product product);
    void Update(Product product);
    void Remove(Product product);

    Product GetByID(int id);
    Product GetByName(string name);
}