namespace Task14;

public class ThirteenthTask
{
    public static void Run()
    {
        var task1 = new Task(() =>
        {
            Console.WriteLine($"Task{Task.CurrentId} started");
            Thread.Sleep(2000);
            Console.WriteLine($"Task{Task.CurrentId} ended");
        });

        var task2 = task1.ContinueWith((t) =>
        {
            Console.WriteLine($"Task{Task.CurrentId} started");
            Console.WriteLine($"Previous task : Task{t.Id}");
            Thread.Sleep(2000);
            Console.WriteLine($"Task{Task.CurrentId} ended");
        });
        
        task1.Start();
        task2.Wait();
        Console.WriteLine("Run is ended");
    }
}