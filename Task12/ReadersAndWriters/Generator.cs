namespace Task12.ReadersAndWriters;

public class Generator
{
    private readonly Database _db;

    public Generator(Database db)
    {
        _db = db;
    }

    public void Start()
    {
        var rnd = new Random();
        for (var i = 0; i < 100; i += 1)
        {
            var newPerson = GetPerson(rnd.Next(0, 100));
            newPerson.GoToDatabase(i.ToString());
        }
    }

    private IPerson GetPerson(int choose)
    {
        return choose switch
        {
            < 50 => new Reader(_db),
            >= 50 => new Writer(_db)
        };
    }
}