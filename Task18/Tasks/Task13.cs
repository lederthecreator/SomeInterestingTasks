using Task18.Domain;
using Task18.Repositories;

namespace Task18.Tasks;

public class Task13
{
    public static void Run()
    {
        var repo = new WorkerRepository();
        var date =  DateTime.Now;
        var worker = new Worker
        {
            Name = "SampleName",
            Login = "qwerty123",
            Age = 21,
            Date = date,
            Salary = 20000
        };
        
        //repo.Add(worker);

        worker.Name = "SampleName3";
        worker.Login = "agsdassdg";
        worker.Age = 33;
        worker.Date = date.Date;
        worker.Salary = 3012;
        
        repo.Add(worker);
    }
}