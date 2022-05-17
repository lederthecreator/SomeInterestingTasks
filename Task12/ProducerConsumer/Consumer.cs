using System.Drawing;

namespace Task12.ProducerConsumer;

public class Consumer
{
    private CommonData _data;

    public Consumer(CommonData data)
    {
        _data = data;
    }

    public void Run()
    {
        var thread = new Thread(() =>
        {
            do
            {
                var res = _data.GetData();
                var color = Color.FromArgb(res[0], res[1], res[2]);
                Console.WriteLine("Result color R:{0} G:{1} B:{2}", color.R, color.G, color.B);
            } while (1 == 1);
        });
        thread.Start();
    }
}
