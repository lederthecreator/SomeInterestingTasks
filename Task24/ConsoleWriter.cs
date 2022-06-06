namespace Task24;

public class ConsoleWriter : IConsoleWriter
{
    private readonly ISingletonDemo _singletonDemo;

    public ConsoleWriter(ISingletonDemo singletonDemo)
    {
        _singletonDemo = singletonDemo;
    }
    public void LogMessage(string message)
    {
        Console.WriteLine($"ConsoleWriter.LogMessage Message is: {message}");
        Console.WriteLine($"singletonDemo.objectId = {_singletonDemo.ObjectId}");
    }
}