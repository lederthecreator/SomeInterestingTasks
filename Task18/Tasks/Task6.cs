using Task18.Repositories;

namespace Task18.Tasks;

public class Task6
{
    public static void Run()
    {
        var repo = new WorkerRepository();

        var res = repo.GetAllData()
            .DistinctBy(worker => worker.Age)
            .Select(worker => worker.Age);
        
        foreach (var workerAge in res)
        {
            Console.WriteLine(workerAge);
        }
    }
}