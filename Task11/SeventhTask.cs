namespace Task11;

public static class Task7
{
    public static void Count(object? count)
    {
        for (int i = 0; i < (int)count!; i += 1)
        {
            Console.WriteLine($"Второй параметризированный поток: {Math.Pow(i, 2)}");
            Thread.Sleep(400);
        }
    }
    
}