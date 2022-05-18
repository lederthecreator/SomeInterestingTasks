namespace Task12.ReadersAndWriters;

public class Database
{
    private AutoResetEvent readerHandler = new AutoResetEvent(false);
    private AutoResetEvent writerHandler = new AutoResetEvent(true);
    private int _readersCount = 0;
    private List<string> books = new();
    public Database() {}
    public void ReadABook()
    {
        while(books.Count == 0) Thread.Sleep(30);
        //readerHandler.WaitOne();
        _readersCount += 1;
        var rnd = new Random();
        Console.WriteLine($"Читатель{Thread.CurrentThread.Name} заходит в базу данных");
        var readingBook = books[rnd.Next(0, books.Count)];
        Console.WriteLine($"Читатель{Thread.CurrentThread.Name} читает книгу{readingBook}");
        Thread.Sleep(rnd.Next(100));
        Console.WriteLine($"Читатель{Thread.CurrentThread.Name} выходит из базы данных");
        _readersCount -= 1;
        writerHandler.Set();
    }

    public void WriteABook()
    {
        writerHandler.WaitOne();
        while (_readersCount > 0) Thread.Sleep(30);
        var rnd = new Random();
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine($"Писатель заходит в базу данных");
        var addingBook = rnd.Next(0, 20).ToString();
        Console.WriteLine("Писатель написал книгу");
        books.Add(addingBook);
        Thread.Sleep(rnd.Next(100, 300));
        Console.WriteLine($"Писатель добавил книгу{addingBook}");
        Console.ResetColor();
        readerHandler.Set();
    }
}