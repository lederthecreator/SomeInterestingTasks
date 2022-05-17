using System.Text;

namespace Task11;

public class ShowField
{
    private CommonData _data;
    private Thread? _thread;

    public ShowField(CommonData data)
    {
        _data = data;
    }

    public void Run()
    {
        _thread = new Thread(() =>
        {
            var result = _data.GetData();
            var sb = new StringBuilder();
            for (int i = 0; i < result.GetLength(0); i += 1)
            {
                sb.Append("[ ");
                for (int j = 0; j < result.GetLength(1); j += 1)
                {
                    sb.Append($" {result[i, j]} ");
                }

                sb.Append(" ]\n");
            }
            Console.WriteLine(sb.ToString());
        });
        _thread.IsBackground = false;
        _thread.Start();
    }
}