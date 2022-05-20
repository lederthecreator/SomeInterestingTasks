namespace Task15;

/*Написать с помощью async/await асинхронный метод FactorialAsync,
вычисляющую факториал от заданного числа. Рассказать подробно что
происходит.
 */
public class FourthTask
{
    public static void Run()
    {
        Console.WriteLine("Enter value");
        var val = Console.ReadLine();
        if (int.TryParse(val, out int result))
        {
            var computed = FactorialAsync(result);
            
            Console.WriteLine($"Main still running");
            for (int i = 0; i < 10; i += 1)
            {
                Console.Write($" {i} ");
            }
            
            Console.WriteLine($"Result is {computed.Result}");
        }
        
    }

    private static async Task<long> FactorialAsync(int value)
    {
        long result = 1;
        await Task.Run(() =>
        {
            for (int i = 1; i < value; i += 1)
            {
                result *= i;
            }
            Thread.Sleep(3000);
        });
        return result;
    } 
}