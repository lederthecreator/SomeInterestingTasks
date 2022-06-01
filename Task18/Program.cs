using Task18.Domain;
using Task18.Repositories;
using Task18.Tasks;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//Filler.Fill();

var repo = new WorkerRepository();

using var session = NHibernateHelper.OpenSession();

var data = session.Query<Worker>().ToList();

/*Выберите из таблицы workers записи с login равным 'user1', 'user2', 'user3'
  Выберите из таблицы workers записи с name равным ‘Алина’, ‘Андрей’, ‘Виктория’, и логином,
  равным 'user', 'admin', 'ivan' и зарплатой больше 300. 
   Выберите из таблицы workers записи c зарплатой от 100 до 1000 
   Выберите из таблицы workers все записи так, чтобы туда попали только записи с 
  разной зарплатой (без дублей) 
   Получите все возрасты без дублирования 
   Найдите в таблице workers минимальную зарплату 
   Найдите в таблице workers максимальную зарплату 
   Найдите в таблице workers суммарную зарплату 
   Найдите в таблице workers суммарную зарплату для людей в возрасте от 21 до 25 
   Найдите в таблице workers среднюю зарплату 
   Найдите в таблице workers средний возраст 
   Выберите из таблицы workers все записи, у которых дата больше текущей 
   Вставьте в таблицу workers запись с полем date с текущим моментом времени в 
  формате 'год-месяц-день часы:минуты:секунды' 
   Вставьте в таблицу workers запись с полем date с текущей датой в формате 'год-месяц-день'. */

var task1 = session.Query<Worker>()
    .Where(w => 
        w.Name == "Дмитрий" || 
        w.Name.Contains("Альберт") || 
        w.Name.Contains("Артем"))
    .ToList();

var task2 = session.Query<Worker>()
    .Where(w => w.Login == "user1" || w.Login == "user2" || w.Login == "user3")
    .ToList();

var task3 = session.Query<Worker>()
    .Where(w =>
        (w.Name == "Алина" || w.Name == "Андрей" || w.Name == "Виктория")
        && w.Salary > 20000 &&
        (w.Login == "user" || w.Login == "admin" || w.Login == "ivan"))
    .ToList();

var task4 = session.Query<Worker>()
    .Where(w => w.Salary > 10000 && w.Salary < 20000)
    .ToList();

var task5 = session.Query<Worker>()
    .GroupBy(w => w.Salary)
    .ToDictionary(g => g.Key, g => g.ToList());

var task6 = session.Query<Worker>()
    .GroupBy(w => w.Salary)
    .Select(g => g.Key)
    .ToList();

var task7 = session.Query<Worker>()
    .Min(w => w.Salary);

var task8 = session.Query<Worker>()
    .Max(w => w.Salary);

var task9 = session.Query<Worker>()
    .Sum(w => w.Salary);

var task11 = session.Query<Worker>()
    .Average(w => w.Salary);

var task10 = session.Query<Worker>()
    .Where(w => w.Age >= 21 && w.Age <= 25)
    .Average(w => w.Salary);

var task12 = session.Query<Worker>()
    .Average(w => w.Age);

var task13 = session.Query<Worker>()
    .Where(w => w.Date > DateTime.Now)
    .ToList();

//task14
var workerFullDate = new Worker()
{
    Name = "SampleName",
    Login = "login14",
    Age = 34,
    Salary = 12312,
    Date = DateTime.Now
};
using var tx = session.BeginTransaction();
session.Save(workerFullDate);
tx.Commit();
tx.Dispose();

//task 15
var workerOnlyDate = workerFullDate;
workerOnlyDate.Date = DateTime.Today.Date;
using var tx1 = session.BeginTransaction();
session.Save(workerOnlyDate);
tx1.Commit();
tx1.Dispose();

var task16 = session.Query<Worker>()
    .Where(w => w.Date.Year == 2020)
    .ToList();

var task17 = session.Query<Worker>()
    .Where(w => w.Date.Month == 3)
    .ToList();

var task18 = session.Query<Worker>()
    .Where(w => w.Date.Day == 3)
    .ToList();

var task19 = session.Query<Worker>()
    .Where(w => w.Date.Month == 4 && w.Date.Day == 5)
    .ToList();
//task20
int[] days = {1, 7, 11, 12, 15, 19, 21, 29};
var task20 = session.Query<Worker>()
    .Where(w => days.Contains(w.Date.Day))
    .ToList();

var task21 = session.Query<Worker>()
    .Where(w => w.Date.Day < w.Date.Month)
    .ToList();

var task22 = session.Query<Worker>()
    .GroupBy(w => w.Age)
    .Select(g => new {Age = g.Key, Salary = g.Min(w => w.Salary)})
    .ToList();

var task23 = session.Query<Worker>()
    .GroupBy(w => w.Salary)
    .Select(g => new {Salary = g.Key, Age = g.Max(w => w.Age)})
    .ToList();

var task24 = session.Query<Worker>()
    .Where(w => w.Salary > session.Query<Worker>().Average(w1 => w1.Salary))
    .ToList();

var task25 = session.Query<Worker>()
    .Where(w => w.Age > session.Query<Worker>().Average(w1 => w1.Age) * 3 / 2)
    .ToList();

var task26 = session.Query<Worker>()
    .Where(w => w.Salary == session.Query<Worker>().Min(w1 => w1.Salary))
    .ToList();

var task27 = session.Query<Worker>()
    .Where(w => w.Salary == session.Query<Worker>().Max(w1 => w1.Salary))
    .ToList();

try
{
    var myTask = session.Query<Worker>()
        .Any(w => w.Name.Length > 3);
}
catch (Exception ex)
{
    Console.WriteLine("taskN: " + ex.Message);
}



    




