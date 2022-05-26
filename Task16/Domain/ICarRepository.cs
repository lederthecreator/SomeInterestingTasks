namespace Task16.Domain;

public interface ICarRepository
{
    void Add(Car car);
    void Update(Car car);
    void Delete(Car car);

    Car GetById(int carId);
    Car GetByModelName(string name);
    ICollection<Car> GetByYear(int year);
}