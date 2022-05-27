using Task18.Repositories;
using Task18.Domain;

namespace Task18.Tasks;

public class Task1
{
    public static void Run()
    {
        var repo = new WorkerRepository();
        var result = repo.GetByName("Дмитрий")
            .Union(repo.GetByName("Альберт"))
            .Union(repo.GetByName("Артем"));
        foreach (var worker in result)
        {
            Console.WriteLine(worker);
        }
    }
}