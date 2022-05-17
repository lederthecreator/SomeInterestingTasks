namespace Task12.ReadersAndWriters;

public class Writer
{
    private Database _db;

    public Writer(Database db)
    {
        _db = db;
    }

    public void Write()
    {
        for (int i = 0; i < 10; i += 1)
        {
            _db.WriteABook();
        }
    }
}