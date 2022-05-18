namespace Task14;

public class FourthTask
{
    public static void Run()
    {
        var t1 = new Task(() => Console.WriteLine("Task1"));
        t1.Start();
        var t2 = Task.Factory.StartNew(() => Console.WriteLine("Task2"));
        var t3 = Task.Run(() => Console.WriteLine("Task3"));

        t1.Wait();
        t2.Wait();
        t3.Wait();
        //Task.WaitAll();
    }
}