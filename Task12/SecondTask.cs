namespace Task12;

public class SecondTask
{
    private int x;
    private object locker = new();
    public SecondTask(){}
    
    public void Run()
    {
        for (int i = 0; i < 5; i += 1)
        {
            var thread = new Thread(Print);
            thread.Name = $"Thread{i}";
            thread.IsBackground = false;
            thread.Start();
        }
    }

    private void Print()
    {
        Monitor.Enter(locker);
        var val = x;
        for (int i = 0; i < 5; i += 1)
        {
            val += 1;
            Console.WriteLine($"{Thread.CurrentThread.Name} x: {val}");
            Thread.Sleep(100);
        }
        x = val;
        Monitor.Exit(locker);
    }
}