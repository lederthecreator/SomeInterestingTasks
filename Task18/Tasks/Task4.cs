using Task18.Repositories;

namespace Task18.Tasks;

public class Task4
{
    public static void Run()
    {
        // Выберите из таблицы workers записи c зарплатой от 100 до 1000 (переделал под реалии своей бд)
        var repo = new WorkerRepository();
        var res = repo
            .GetAllData()
            .Where(worker => worker.Salary > 10000 && worker.Salary < 20000);
        foreach (var worker in res)
        {
            Console.WriteLine(worker);
        }
    }
}