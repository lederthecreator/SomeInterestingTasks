namespace Task13.SenderReciever;

public class Sender
{
    private Reciever _reciever;

    public Sender(Reciever reciever)
    {
        _reciever = reciever;
    }

    public void Run()
    {
        for (int i = 0; i < 50; i += 1)
        {
            var thread = new Thread(Send);
            thread.Start(i);
        } 
    }
    private void Send(object data)
    {
        var val = (int)data;
        Console.WriteLine($"Send {val} ");
        _reciever.Recieve(val);
    }
}