namespace Task14;

public class SixteenthTask
{
    public static void Run()
    {
        //Parallel.For(0, 10, Root);
        
        Parallel.Invoke
        (
            () => Console.WriteLine($"Выполняется задача {Task.CurrentId}"),
            () =>
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(new Random().Next(500, 2000));
            },
          () => Root(9)
        );
    }

    private static void Root(int val)
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        //Thread.Sleep(new Random().Next(500, 2000));
        Console.WriteLine($"Результат работы {Task.CurrentId}: {Math.Sqrt(val)}");
    }
}