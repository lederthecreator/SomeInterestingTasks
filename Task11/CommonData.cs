namespace Task11;

public class CommonData
{
    private int[,] _field;
    private readonly int _size;
    public int Size => _size;
    public WorkerType[] EndWorkers { get; set; }

    public CommonData(int size)
    {
        _size = size;
        _field = new int[size, size];
        EndWorkers = new WorkerType[2];
        for (var i = 0; i < size; i += 1)
        {
            for (var j = 0; j < size; j += 1)
            {
                _field[i, j] = 0;
            }
        }
    }
    public void PutData(WorkerType workerType)
    {
        lock (_field)
        {
            (int i, int j)? pos;
            switch (workerType)
            {
                case WorkerType.UpperLeftCorner:
                    pos = FindFirstZeroElement(workerType);
                    if (pos.HasValue)
                    {
                        _field[pos.Value.i, pos.Value.j] = 1;
                        Monitor.PulseAll(_field);
                    }
                    else
                        EndWorkers[0] = workerType;
                    break;
                case WorkerType.BottomRightCorner:
                    pos = FindFirstZeroElement(workerType);
                    if (pos.HasValue)
                        _field[pos.Value.i, pos.Value.j] = 2;
                    else
                        EndWorkers[1] = workerType;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(workerType), workerType, null);
            }
        }
    }

    public int[,] GetData()
    {
        var res = new int[Size, Size];
        lock(_field)
        {
            while (FindZeroElement()) Monitor.Wait(_field);
            res = CopyArr();
            Monitor.PulseAll(_field);
            int[,] CopyArr()
            {
                var result = new int[Size, Size];
                for (int i = 0; i < Size; i += 1)
                {
                    for (int j = 0; j < Size; j += 1)
                    {
                        result[i, j] = _field[i, j];
                    }
                }

                return result;
            }
        }
        return res;
    }

    private (int i, int j)? FindFirstZeroElement(WorkerType workerType)
    {
        switch (workerType)
        {
            case WorkerType.UpperLeftCorner:
                for (int i = 0; i < Size; i += 1)
                {
                    for (int j = 0; j < Size; j += 1)
                    {
                        if (_field[i, j] == 0) return (i, j);
                    }
                }
                break;
            case WorkerType.BottomRightCorner:
                for (int i = Size - 1; i >= 0; i -= 1)
                {
                    for (int j = Size - 1; j >= 0; j -= 1)
                    {
                        if (_field[i, j] == 0) return (i, j);
                    }
                }
                break;
        }
        return null;
    }

    private bool FindZeroElement()
    {
        foreach (var value in _field)
        {
            if (value == 0) return true;
        }
        return false;
    }


}