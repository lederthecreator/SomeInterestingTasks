namespace Task11;

public class Worker
{
    private CommonData _data;
    private Thread? _thread;
    private (int i, int j) _currPosition;
    private (int i, int j) _endPosition;
    
    public WorkerType Type { get; set; }
    public bool IsAlive => _thread?.IsAlive ?? false;

    public Worker(WorkerType type, CommonData data)
    {
        _data = data;
        Type = type;
        SetStartEndPosition();
    }

    public void SetStartEndPosition()
    {
        switch (Type)
        {
            case WorkerType.UpperLeftCorner:
                _currPosition = (0, 0);
                _endPosition = (_data.Size - 1, _data.Size - 1);
                break;
            case WorkerType.BottomRightCorner:
                _currPosition = (_data.Size - 1, _data.Size - 1);
                _endPosition = (0, 0);
                break;
        }
    }

    public void Run()
    {
        _thread = new(() =>
        {
            do
            {
                if (_data.EndWorkers.Contains(Type)) break;
                _data.PutData(Type);
            } while (1 == 1);
        });
        _thread.IsBackground = true;
        _thread.Start();
    }


}