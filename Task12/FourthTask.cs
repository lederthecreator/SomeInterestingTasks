namespace Task12;
public class FourthTask
{
    public static void EventRun()
    {
        for (int i = 0; i < 2; i += 1)
        {
            var thread = new Thread(() =>
            {
                Task7.EventCount(5);
            });
            thread.Name = $"Thread{i}";
            thread.Start();
        }
    }
    public static void MutexRun()
    {
        for (int i = 0; i < 2; i += 1)
        {
            var thread = new Thread(() =>
            {
                Task7.MutexCount(5);
            });
            thread.Name = $"Thread{i}";
            thread.Start();
        }
    }
}