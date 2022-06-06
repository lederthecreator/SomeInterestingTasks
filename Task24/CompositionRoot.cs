namespace Task24;

public class CompositionRoot : ICompositionRoot
{
    private IConsoleWriter _consoleWriter;

    public CompositionRoot(IConsoleWriter consoleWriter)
    {
        _consoleWriter = consoleWriter;
        _consoleWriter.LogMessage("Constructor CompositionRoot");
    }
    public void LogMessage(string message)
    {
        Console.WriteLine($"Message is: {message}");
    }
}