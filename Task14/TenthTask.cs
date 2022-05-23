namespace Task14;

public class TenthTask
{
    public static void Run()
    {
        Task[] tasks = new Task[3]
        {
            new Task(Print),
            new Task(Print),
            new Task(Print),
        };
        foreach (var task in tasks)
        {
            task.Start();
        }
        Console.WriteLine("Run ended");
        Task.WaitAny(tasks);
    }

    private static void Print()
    {
        Console.WriteLine($"Task{Task.CurrentId}");
    }
}