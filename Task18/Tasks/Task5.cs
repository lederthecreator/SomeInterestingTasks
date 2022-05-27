using Task18.Domain;
using Task18.Repositories;

namespace Task18.Tasks;

public class Task5
{
    public static void Run()
    {
        // Записи с разной зп
        var repo = new WorkerRepository();
        var res = repo.GetAllData().DistinctBy(worker => worker.Salary);
    
        Console.WriteLine($"Count of workers {res.ToList().Count}");
        // foreach (var worker in res)
        // {
        //     Console.WriteLine(worker);
        // }
    }
}