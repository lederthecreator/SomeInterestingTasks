namespace Task24;

public class ConsoleWriter : IConsoleWriter
{
    public void LogMessage(string message)
    {
        Console.WriteLine($"Message is: {message}");
    }
}