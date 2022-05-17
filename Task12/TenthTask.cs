namespace Task12;

public class TenthTask
{
    public static int Count { get; set; }
    public static void Run()
    {
        int seconds = 10;
        var timerCallBack = new TimerCallback(GetWeather);
        var timer = new Timer(timerCallBack, null, 0, seconds * 1000);

        Console.ReadLine();
    }

    public static void GetWeather(object? obj)
    {
        var rnd = new Random();
        Action weatherAction = rnd.Next(0, 100) switch
        {
            <= 20 => IsSunny,
            >= 20 and <= 80 => IsWindy,
            >= 80 => IsCloudy
        };
        if(Count <= 5)
            weatherAction.Invoke();
        else
            Thread.CurrentThread.Interrupt();
    }

    private static void IsSunny()
    {
        Console.WriteLine("Is sunny");
        Count += 1;
    }

    private static void IsCloudy()
    {
        Console.WriteLine("Is cloudy");
        Count += 1;
    }

    private static void IsWindy()
    {
        Console.WriteLine("Is windy");
        Count += 1;
    }
}
