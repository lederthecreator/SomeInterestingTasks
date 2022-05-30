using Task18.Repositories;

namespace Task18.Tasks;

public class Task11
{
    public static void Run()
    {
        var repo = new WorkerRepository();
        var res = repo.GetAllData()
            .Select(worker => worker.Age)
            .Average();
        Console.WriteLine($"Avg age is {res}");
    }
}