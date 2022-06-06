namespace Task24;

public class CompositionRoot : ICompositionRoot
{
    private IConsoleWriter _consoleWriter;
    private ISingletonDemo _singletonDemo;
    public CompositionRoot(IConsoleWriter consoleWriter, ISingletonDemo singletonDemo)
    {
        _consoleWriter = consoleWriter;
        _singletonDemo = singletonDemo;
        _consoleWriter.LogMessage("Constructor CompositionRoot");
    }
    public void LogMessage(string message)
    {
        Console.WriteLine($"CompositionRoot.LogMessage\nMessage is: {message}, objectId = {_singletonDemo.ObjectId}");
    }
}

public class PropertyInjection : ICompositionRoot
{
    public IConsoleWriter ConsoleWriter { get; set; }
    public ISingletonDemo SingletonDemo { get; set; }
    
    public PropertyInjection(){}
    public void LogMessage(string message)
    {
        ConsoleWriter.LogMessage($"PropertyInjection.LogMessage\nMessage from property {message}, objectId={SingletonDemo.ObjectId}");
    }
}