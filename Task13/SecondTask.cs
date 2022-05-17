namespace Task13;

public class SecondTask
{
    private int[] _array;
    private object _locker = new();

    private int _arraySize;
    private int _threadCount;
    private int _chunkLength;
    
    public int Sum { get; set; }

    public SecondTask(int size, int threadCount)
    {
        _arraySize = size;
        _threadCount = threadCount;
        _array = new int[_arraySize];
        _chunkLength = _arraySize / _threadCount;
    }

    public void Run()
    {
        FillArray();
        for (int i = 0; i < _arraySize; i += _chunkLength)
        {
            var res = GetChunk(i);
            var thread = new Thread(() =>
            {
                CalculateSum(res);
                Console.WriteLine($"{Thread.CurrentThread.Name} ended calculations, sum is {Sum}");
            });
            thread.Name = $"Thread{i / _chunkLength}";
            thread.Start();
        }
    }
    
    private int[] GetChunk(int currPos)
    {
        var res = new int[_chunkLength];
        for (int i = 0; i < res.Length; i += 1, currPos +=1)
        {
            res[i] = _array[currPos];
        }
        return res;
    }

    private void CalculateSum(int[] arr)
    {
        lock (_locker)
        {
            var sum = 0;
            for (int i = 0; i < arr.Length; i += 1)
            {
                sum += arr[i];
                Sum += arr[i];
            }
            Console.WriteLine(sum);
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