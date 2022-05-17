namespace Task13;

public class ThirdTask
{
    private int[] _array;
    private object _locker = new();
    private int _arraySize;
    private Thread t1, t2;
    
    public int Sum { get; set; }

    public ThirdTask(int arraySize)
    {
        _arraySize = arraySize;
        _array = new int[_arraySize];
        t1 = new Thread(Calculate);
        t2 = new Thread(Calculate);
    }

    public void Run()
    {
        FillArray();
        t1.Start();
        t2.Start();
        while (t1.ThreadState == ThreadState.Running || t2.ThreadState == ThreadState.Running)
            Thread.Sleep(30);
        Console.WriteLine($"Calculations ended, sum is {Sum}");
    }

    private void Calculate()
    {
        lock (_locker)
        {
            var sum = 0;
            for (int i = 0; i < _arraySize; i+=1)
            {
                sum += _array[i];
                Sum = sum;
            }
        }
    }
    
    private void FillArray()
    {
        lock (_locker)
        {
            var rnd = new Random();
            for (int i = 0; i < _arraySize; i += 1)
            {
                var value = rnd.Next(1, 100);
                _array[i] = value;
            }
        }
    }
}