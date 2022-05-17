namespace Task12;

public class Library
{
    private static Semaphore _semaphore;
    public Library()
    {
        _semaphore = new Semaphore(3, 3);
    }
    public void ReadABook()
    {
        _semaphore.WaitOne();
        Console.WriteLine($"{Thread.CurrentThread.Name} заходит в библиотеку");
        Thread.Sleep(20);
        Console.WriteLine($"{Thread.CurrentThread.Name} читает книгу");
        Thread.Sleep(new Random().Next(50, 200));
        Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");
        _semaphore.Release();
    }
}