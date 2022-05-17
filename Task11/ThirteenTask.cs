namespace Task11;

public static class ThirteenTask
{
    public static void Run(int size)
    {
        var thread = new Thread(() =>
        {
            var data = new CommonData(size);
            var shower = new ShowField(data);
            var worker1 = new Worker(WorkerType.UpperLeftCorner, data);
            var worker2 = new Worker(WorkerType.BottomRightCorner, data);
            shower.Run();

            worker1.Run();
            worker2.Run();
        });
        thread.Priority = ThreadPriority.Highest;
        thread.IsBackground = false;
        thread.Start();
    }
}