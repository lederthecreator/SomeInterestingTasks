using Task18.Repositories;

namespace Task18.Tasks;

public class Task2
{
    public static void Run()
    {
        //Выберите из таблицы workers записи с login равным 'user1', 'user2',
        //'user3'
        var repo = new WorkerRepository();
        var res = repo.GetByLogin("user1")
            .Union(repo.GetByLogin("user2"))
            .Union(repo.GetByLogin("user3"));
        foreach (var worker in res)
        {
            Console.WriteLine(worker);
        }
    }
}