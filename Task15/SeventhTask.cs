using System.Diagnostics;
using System.Reflection;

namespace Task15;

public class SeventhTask
{
    private static CancellationTokenSource cts = new CancellationTokenSource();
    public static async Task Run()
    {
        FactorialVoidAsync(10);
        FactorialTaskAsync(10);
        var res1 = await FactorialTaskIntAsync(10);
        var res2 = await FactorialTaskLongAsync(10, cts);
        
        Console.WriteLine($"FactorialTaskIntAsync result is {res1}");
        Console.WriteLine($"FactorialTaskLongAsync result is {res2}");
    }

    private static async void FactorialVoidAsync(int val)
    {
        ulong result = 1;
        await Task.Run(() =>
        {
            for (int i = 1; i < val; i += 1)
            {
                result *= (ulong)i;
            }
        });
        Console.WriteLine($"FactorialVoidAsync result {result}");
    }

    public static async Task FactorialTaskAsync(int val)
    {
        var result = 1;
        await Task.Run(() =>
        {
            for (int i = 1; i < val; i += 1)
            {
                result *= i;
            }
        });
        Console.WriteLine($"FactorialTaskAsync result {result}");
    }

    private static async Task<int> FactorialTaskIntAsync(int val)
    {
        var result = 1;
        await Task.Run(() =>
        {
            for (int i = 1; i < val; i += 1)
            {
                result *= i;
            }
        });
        return result;
    }

    public static async Task<ulong> FactorialTaskLongAsync(int val, CancellationTokenSource cancellationTokenSource)
    {
        if (val < 0)
            throw new ArgumentException("value less than zero");
        ulong result = 1;
        await Task.Run(() =>
        {
            for (int i = 1; i < val; i += 1)
            {
                result *= (ulong)i;
            }
        });
        return result;
    }
    
}