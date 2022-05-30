using Task18.Repositories;

namespace Task18.Tasks;

public class Task7
{
    public static void Run()
    {
        var repo = new WorkerRepository();

        var min = repo.GetAllData().Min(worker => worker.Salary);
        var max = repo.GetAllData().Max(worker => worker.Salary);
        Console.WriteLine($"Min : {min}");
        Console.WriteLine($"Max : {max}");
        
    }
}