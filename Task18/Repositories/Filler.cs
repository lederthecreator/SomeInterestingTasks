using Task18.Domain;
using Task18.Repositories;

namespace Task18.Repositories;

public class Filler
{
    private static IWorkerRepository _repository = new WorkerRepository();
    private static List<string> _names = "Дмитрий,Матвей,Альберт,Алина,Александр,Егор,Михаил,Алексей,Фёдор,Леонид,Платон,Тигран,Илья,Марк,Артем,Яков,Даниил,Никита,Сергей,Виктория,Роман,Игорь,Павел,Максим,Лев,Елисей,Арсен,Андрей,Евгений,Роберт,Константин,Захар,Даниэль,Денис,Тихон,Борис,Мирон,Святослав,Кирилл,Эмиль,Владимир,Артур,Иван,Григорий,Олег,Станислав,Семён,Герман,Всеволод,Богдан".Split(",").ToList();
    private static List<string> _logins = new() { "user", "admin", "login1" };

    public static void Fill()
    {
        var rnd = new Random();
        for (int i = 1; i <= 47; i += 1) 
            _logins.Add($"user{i}");
        foreach (var name in _names)
        {
            var date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            var worker = new Worker
                { 
                    Name = name, 
                    Login = _logins[rnd.Next(0, 50)], 
                    Age = rnd.Next(18, 60), 
                    Salary = rnd.Next(10000, 30000),
                    Date = date
                };
            _repository.Add(worker);
        }

    }
}