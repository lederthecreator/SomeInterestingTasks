namespace Task12.ProducerConsumer;

public class Producer
{
    private CommonData _data;
    private ProdType _prodType;

    public Producer(CommonData data, ProdType prodType)
    {
        _data = data;
        _prodType = prodType;
    }

    public void Run()
    {
        // Увеличить количество потоков на чтение и запись (генератор потоков)
        var thread = new Thread(() =>
        {
            var i = 0;
            do
            {
                var rnd = new Random();
                byte value = (byte)rnd.Next(0, byte.MaxValue);
                Console.WriteLine($"Consumer{_prodType} generate {value}");
                _data.PutData(_prodType, value);
                i += 1;
            } while (i < 10);
        });

        thread.Start();
    }
    
}