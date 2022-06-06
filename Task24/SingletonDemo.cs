namespace Task24;

public class SingletonDemo : ISingletonDemo
{
    public Guid ObjectId { get; }

    public SingletonDemo()
    {
        ObjectId = Guid.NewGuid();
    }
}