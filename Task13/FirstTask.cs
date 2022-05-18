namespace Task13;

public class FirstTask
{
    private int[] _array;
    private object _locker = new();
    public int Sum { get; set; }

    public FirstTask()
    {
        _array = new int[10000];
    }
    
    public void Run()
    {
        var firstThread = new Thread(() =>
        {
            FillArray();
            Console.WriteLine("End of fill array");
        });
        var secondThread = new Thread(() =>
        {
            CalculateSum(0, _array.Length / 2);
            Console.WriteLine($"First Thread Ended, Sum is {Sum}");
        });
        var thirdThread = new Thread(() =>
        {
            CalculateSum(_array.Length / 2, _array.Length);
            Console.WriteLine($"Second Thread Ended, Sum is {Sum}");
        });
        
        firstThread.Start();
        secondThread.Start();
        thirdThread.Start();
    }

    private void FillArray()
    {
        lock (_locker)
        {
            var rnd = new Random();
            for (int i = 0; i < _array.Length; i += 1)
            {
                var value = rnd.Next(1, 100);
                _array[i] = value;
                Monitor.PulseAll(_locker);
            }
        }
    }

    private void CalculateSum(int leftIndex, int rightIndex)
    {
        // LOCK и Monitor перекрывают функционал друг друга
        // Разделить массив на рандомные части
        // Глупость: массив массивов и каждый поток считает сумму столбца 
        lock (_locker)
        {
            for(int i = leftIndex; i < rightIndex; i+=1)
            {
                while (_array[i] == 0) Monitor.Wait(_locker);
                Sum += _array[i];
            }
        }
        
    }
}