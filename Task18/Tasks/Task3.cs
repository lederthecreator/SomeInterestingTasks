using Task18.Repositories;

namespace Task18.Tasks;

public class Task3
{
    public static void Run()
    {
        /*Выберите из таблицы workers записи с name равным ‘Алина’,
‘Андрей’, ‘Виктория’, и логином, равным 'user', 'admin', 'ivan' и
зарплатой больше 300.*/
        var repo = new WorkerRepository();
        var getByNames = repo.GetByName("Алина")
            .Union(repo.GetByName("Андрей"))
            .Union(repo.GetByName("Виктория"));
        var getByLogins = repo.GetByLogin("user")
            .Union(repo.GetByLogin("admin")
                .Union(repo.GetByLogin("ivan")));
        var result = getByNames.Intersect(getByLogins).Where(worker => worker.Salary > 300);
        foreach (var worker in result)
        {
            Console.WriteLine(worker);
        }

    }
}