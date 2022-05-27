using NHibernate.Util;
using Task18.Repositories;

namespace Task18.Tasks;

public class TaskN
{
    public static void Run()
    {
        var repos = new WorkerRepository();
        var data = repos.GetAllData();
        
        //  Найдите самые маленькие зарплаты по группам возрастов (для каждого
        //возраста свою минимальную зарплату)
        var res = data
            .GroupBy(worker => worker.Age)
            .Select(g => new { Age = g.Key, Salary = g.Min(worker => worker.Salary) })
            .ToList();
        
        //  Найдите самый большой возраст по группам зарплат (для каждой
        //зарплаты свой максимальный возраст)
        var res2 = data
            .GroupBy(worker => worker.Salary)
            .Select(group => new 
                { Salary = group.Key, Age = group.Max(worker => worker.Age) })
            .ToList();
        
        //  Выберите из таблицы workers все записи, зарплата в которых больше
        //средней зарплаты.
        var res3 = data
            .Where(worker => worker.Salary > data.Average(worker1 => worker1.Salary));
        
        //Выберите из таблицы workers все записи, возраст в которых меньше
        //среднего возраста, деленного на 2 и умноженного на 3.
        var res4 = data
            .Where(worker => worker.Age < data.Average(w => w.Age) * 3 / 2);
        
        //Выберите из таблицы workers записи с минимальной зарплатой
        var res5 = data
            .Where(w => w.Salary == data.Min(w1 => w1.Salary));
        
        //Выберите из таблицы workers записи с максимальной зарплатой.
        var res6 = data
            .Where(w => w.Salary == data.Max(w1 => w1.Salary));
    }
}