using Task18.Repositories;

namespace Task18.Tasks;

public class Task14
{
    public static void Run()
    {
        var repo = new WorkerRepository();
        var data = repo.GetAllData().ToList();
        //Выберите из таблицы workers все записи за 2020 год
        var res1 = data.Where(worker => worker.Date.Year == 2020);
        //Выберите из таблицы workers все записи за март любого года
        var res2 = data.Where(worker => worker.Date.Month == 3);
        // Выберите из таблицы workers все записи за третий день месяца
        var res3 = data.Where(worker => worker.Date.Day == 3);
        // Выберите из таблицы workers все записи за пятый день апреля любого года
        var res4 = data.Where
            (worker => worker.Date.Month == 4 && worker.Date.Day == 5);
        //  Выберите из таблицы workers все записи за следующие дни любого
        //месяца: 1, 7, 11, 12, 15, 19, 21, 29
        var res5 = data.Where
            (worker => new int[] { 1, 7, 11, 12, 15, 19, 21, 29 }.Contains(worker.Date.Day));
        //  Выберите из таблицы workers все записи, в которых день меньше
        // месяца.
        var res6 = data.Where(
            worker => worker.Date.Day < worker.Date.Month);
        
    }
}