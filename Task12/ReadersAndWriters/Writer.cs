namespace Task12.ReadersAndWriters;

public class Writer : IPerson
{
    private readonly Database _db;

    public Writer(Database db)
    {
        _db = db;
    }

    public void GoToDatabase(string threadName)
    {
        var t = new Thread(Write)
        {
            Priority = ThreadPriority.AboveNormal
        };
        t.Name = $"Writer{threadName}";
        t.Start();
    }

    public void Write()
    {
        for (var i = 0; i < 10; i += 1)
        {
            _db.Write();
        }
    }
}