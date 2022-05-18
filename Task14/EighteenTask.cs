using System.Numerics;
using System.Text;

namespace Task14;

public class EighteenTask
{
    private double[,] _m1;
    private double[,] _m2;
    private double[,] _result;
    private object _locker = new();
    public EighteenTask()
    {
        _m1 = new double[4, 4];
        _m2 = new double[4, 4];
        _result = new double[4, 4];
        var rnd = new Random();
        for (int i = 0; i < _m1.GetLength(0); i += 1)
        {
            for (int j = 0; j < _m1.GetLength(1); j += 1)
            {
                _m1[i, j] = rnd.Next(-10, 10);
                _m2[i, j] = rnd.Next(-10, 10);
            }
        }
    }

    public void Run()
    {
        ShowMatrix(_m1);
        ShowMatrix(_m2);
        Multiply();
        ShowMatrix(_result);
    }

    private void Multiply()
    {
        var m1rows = _m1.GetLength(0);
        var m1cols = _m1.GetLength(1);
        var m2cols = _m2.GetLength(1);

        Parallel.For(0, m1rows, i =>
        {
            for (int j = 0; j < m2cols; j += 1)
            {
                var computedValue = 0.0;
                for (int k = 0; k < m1cols; k += 1)
                {
                    computedValue += _m1[i, k] * _m2[k, j];
                }

                _result[i, j] = computedValue;
            }
        });
    }

    private void ShowMatrix(double[,] matrix)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < matrix.GetLength(0); i += 1)
        {
            sb.Append("[ ");
            for (int j = 0; j < matrix.GetLength(1); j += 1)
            {
                sb.Append($" {matrix[i, j]} ");
            }

            sb.Append(" ]\n");
        }
        Console.WriteLine(sb.ToString());
    }
}