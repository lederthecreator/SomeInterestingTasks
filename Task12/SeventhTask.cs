namespace Task12;

public static class Task7
{
    public static AutoResetEvent waitHandler = new AutoResetEvent(true);

    public static Mutex mutex = new Mutex();
    public static void EventCount(object? count)
    {
        waitHandler.WaitOne();
        for (int i = 0; i < (int)count!; i += 1)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} : {Math.Pow(i, 2)}");
            Thread.Sleep(400);
        }
        waitHandler.Set();
    }

    public static void MutexCount(int count)
    {
        mutex.WaitOne();
        for (int i = 0; i < (int)count!; i += 1)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} : {Math.Pow(i, 2)}");
            Thread.Sleep(400);
        }
        mutex.ReleaseMutex();
    }
    
}