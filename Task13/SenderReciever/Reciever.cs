namespace Task13.SenderReciever;

public class Reciever
{
    private List<int> _recievedData = new();
    private object _locker = new();
    public Reciever(){}
    public void Recieve(int data)
    {
        lock (_locker)
        {
            _recievedData.Add(data);
            Console.WriteLine($"Recieved {data}");
        }
    }

    public void ShowAllRecievedData()
    {
        while (_recievedData.Count != 50) Thread.Sleep(30);
        var str = string.Join(" ", _recievedData.OrderBy(x => x));
        Console.WriteLine(str);
    }
}