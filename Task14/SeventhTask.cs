namespace Task14;

public class SeventhTask
{
    public static void Run()
    {
        Console.WriteLine("Start of Run");
        var outerTask = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Outer task started");
            var innerTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Inner task started");
                Thread.Sleep(2000);
                Console.WriteLine("Inner task ended");
            }, TaskCreationOptions.AttachedToParent); // Чтобы выполнялась как и родительская, необходимо добавить Options
            innerTask.Wait();
            Console.WriteLine("Outer task ended");
        });
        outerTask.Wait();
        Console.WriteLine("End of Run");
    }
}