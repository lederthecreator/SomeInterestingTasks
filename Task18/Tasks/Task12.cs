using Task18.Repositories;

namespace Task18.Tasks;

public class Task12
{
    public static void Run()
    {
        var repo = new WorkerRepository();

        var res = repo.GetAllData()
            .Where(worker => worker.Date > DateTime.Now);
        foreach (var worker in res)
        {
            Console.WriteLine(worker);
        }
    }
}