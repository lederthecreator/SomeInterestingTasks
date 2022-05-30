using NHibernate.Util;
using Task18.Repositories;

namespace Task18.Tasks;

public class Task9
{
    public static void Run()
    {
        var repo = new WorkerRepository();
        int result = 0;
        repo.GetAllData()
            .Select(worker => worker.Salary)
            .ForEach(worker => result += worker);
        Console.WriteLine($"All sum is {result}");
        
        int result1 = 0;
        repo.GetAllData()
            .Where(worker => worker.Age >= 21 && worker.Age <= 25)
            .Select(worker => worker.Salary)
            .ForEach(worker => result1 += worker);
        Console.WriteLine($"For 21-25 workers sum is {result1}");
        
        Console.WriteLine($"Avg sum is {result / repo.GetAllData().ToList().Count}");
    }
}