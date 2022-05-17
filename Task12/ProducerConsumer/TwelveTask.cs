namespace Task12.ProducerConsumer;

public class TwelveTask
{
    public static void Run()
    {
        var data = new CommonData();

        var consumer = new Consumer(data);
        consumer.Run();

        var redProd = new Producer(data, ProdType.RedColor);
        var greenProd = new Producer(data, ProdType.GreenColor);
        var blueProd = new Producer(data, ProdType.BlueColor);
        
        redProd.Run();
        greenProd.Run();
        blueProd.Run();
    }
}