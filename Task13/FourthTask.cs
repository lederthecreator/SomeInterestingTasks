using Task13.SenderReciever;

namespace Task13;

public class FourthTask
{
    public void Run()
    {
        var reciever = new Reciever();
        var sender = new Sender(reciever);
        
        sender.Run();
        reciever.ShowAllRecievedData();
    }
}