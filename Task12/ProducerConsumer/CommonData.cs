namespace Task12.ProducerConsumer;

public class CommonData
{
    private Queue<byte>[] _data = { new(), new(), new() };
    private int _maximumQueueLength = 3;

    public void PutData(ProdType prodType, byte value)
    {
        lock (_data)
        {
            while (_data[(int)prodType].Count >= _maximumQueueLength)
                Monitor.Wait(_data);
            _data[(int)prodType].Enqueue(value);
            Monitor.PulseAll(_data);
        }
    }
    // Блокировать конкретную очередь, а не всю дату
    public byte[] GetData()
    {
        byte[] res = new byte[3];
        lock (_data)
        {
            foreach (var queue in _data)
            {
                while (queue.Count == 0) Monitor.Wait(_data);
            }
            for (int i = 0; i < res.Length; i += 1)
            {
                res[i] = _data[i].Dequeue();
            }
            
            Monitor.PulseAll(_data);
        }

        return res;
    }
}