namespace Task11;

public static class EleventhTask
{
    private static int _x =0;
    private static object locker = new();
    public static void Run()
    {
        for (int i = 0; i < 5; i++)
        {
            Thread myThread = new Thread(Count);
            myThread.Name = "Поток " + i;
            myThread.Start();
        }
        Console.ReadLine();
    }
    private static void Count()
    {
        lock (locker)
        {
            _x = 1;
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine("{0}: {1}",
                    Thread.CurrentThread.Name, _x);
                _x++;
                Thread.Sleep(100);
            }
        }
    }
}
