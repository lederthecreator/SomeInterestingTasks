namespace Task12.ReadersAndWriters;

public class Database
{
    private AutoResetEvent writerHandler = new AutoResetEvent(true);
    
    private object _writerLocker = new();
    private List<string> _books = new();

    public Database()
    {
        for (int i = 0; i < 100; i += 1)
            _books.Add(i.ToString());
    }
    
    /*public void ReadABook()
    {
        //while (_writersCount > 0) Monitor.Wait(_readerLocker);
        Interlocked.Increment(ref _readersCount);
        //_readersCount += 1;
        var rnd = new Random();
        Console.WriteLine($"+++{Thread.CurrentThread.Name} заходит в базу данных");
        var readingBook = _books[rnd.Next(0, _books.Count)];
        Console.WriteLine($"==={Thread.CurrentThread.Name} читает книгу{readingBook}");
        Thread.Sleep(rnd.Next(200));
        Console.WriteLine($"---{Thread.CurrentThread.Name} выходит из базы данных");
        //_readersCount -= 1;
        Interlocked.Decrement(ref _readersCount);
        if(_readersCount == 0) Monitor.Pulse(_writerLocker);
    }*/

    /*public void WriteABook()
    {
        // Monitor.Enter(_writerLocker);
        // Monitor.Enter(_readerLocker);
        // while (_readersCount > 0 || _writersCount > 0) Monitor.Wait(_writerLocker);
        _readerMutex.WaitOne();
        _writerMutex.WaitOne();
        Interlocked.Increment(ref _writersCount);
        //_writersCount += 1;
        var rnd = new Random();
        //Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine($"###{Thread.CurrentThread.Name} заходит в базу данных");
        var addingBook = rnd.Next(0, 100).ToString();
        _books.Add(addingBook);
        Console.WriteLine($"###{Thread.CurrentThread.Name} добавил книгу{addingBook}. Выходит");
        //Console.ResetColor();
        Thread.Sleep(rnd.Next(200));
        Interlocked.Decrement(ref _writersCount);
        //_writersCount -= 1;
        _readerMutex.ReleaseMutex();
        _writerMutex.ReleaseMutex();
    }*/

    public void Read()
    {
        ReadWriteController.RequestRead();
        Console.WriteLine($"{Thread.CurrentThread.Name} заходит в БД");
        var bookToRead = new Random().Next(0, _books.Count);
        Console.WriteLine($"{Thread.CurrentThread.Name} читает книгу{_books[bookToRead]}");
        Console.WriteLine($"{Thread.CurrentThread.Name} выходит из БД");
        ReadWriteController.ReleaseRead();
    }

    public void Write()
    {
        ReadWriteController.RequestWrite();
        Console.WriteLine($"{Thread.CurrentThread.Name} заходит в БД");
        var bookToAdd = new Random().Next(100, 1000);
        lock (_writerLocker)
        {
            _books.Add(bookToAdd.ToString());
        }
        Console.WriteLine($"{Thread.CurrentThread.Name} добавил книгу {bookToAdd}");
        Thread.Sleep(200);
        Console.WriteLine($"{Thread.CurrentThread.Name} выходит из БД");
        ReadWriteController.ReleaseWrite();
    }
}