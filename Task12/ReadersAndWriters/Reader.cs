namespace Task12.ReadersAndWriters;

public class Reader
{
    private Database _db;

    public Reader(Database database)
    {
        _db = database;
    }

    public void Read()
    {
        for (int i = 0; i < 10; i += 1)
        {
            _db.ReadABook();
        }
    }
}