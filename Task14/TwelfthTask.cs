namespace Task14;

public class TwelfthTask
{
    public static void Run()
    {
        int a = 5, b = 4;
        var sumTask = new Task<int>(() => Sum(a, b));
        sumTask.Start();
        
        //GetAwaiter.Result в чем отличие от Result
        var result = sumTask.Result;
        Console.WriteLine($"Result is {result}");
    }

    private static int Sum(int a, int b) => a + b;
}