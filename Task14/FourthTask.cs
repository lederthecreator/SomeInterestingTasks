namespace Task14;

public class FourthTask
{
    public static void Run()
    {
        var t1 = new Task(() => Console.WriteLine($"Task1 CurrentID: {Task.CurrentId}"));
        t1.Start();
        var t2 = Task.Factory.StartNew(() => Console.WriteLine($"Task2, CurrentID: {Task.CurrentId}"));
        var t3 = Task.Run(() => Console.WriteLine($"Task3, CurrentID: {Task.CurrentId}"));
        
        t1.Wait();
        Console.WriteLine(t1.IsCompleted);
        Console.WriteLine(t1.IsCompletedSuccessfully);
        t2.Wait();
        t3.Wait();
    }
}