namespace Task12;

public class Reader
{
    private int _id;
    private Library _library;
    public Reader(int id, Library library)
    {
        _id = id;
        _library = library;
    }

    public void Read()
    {
        var thread = new Thread(() =>
        {
            for (int i = 0; i < 3; i += 1)
            {
                _library.ReadABook();
            }
        });
        thread.Name = $"Читатель{_id}";
        thread.Start();
    }
}