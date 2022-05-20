namespace Task12.ReadersAndWriters;

public class Reader : IPerson
{
    private readonly Database _db;

    public Reader(Database database)
    {
        _db = database;
    }

    public void GoToDatabase(string threadName)
    {
        var t = new Thread(Read)
        {
            Priority = ThreadPriority.BelowNormal
        };
        t.Name = $"Reader{threadName}";
        t.Start();
    }
    public void Read()
    {
        // Создавать поток здесь
        for (var i = 0; i < 10; i += 1)
        {
            _db.Read();
            Thread.Sleep(200);
        }
    }
}