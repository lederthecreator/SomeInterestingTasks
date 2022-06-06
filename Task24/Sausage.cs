namespace Task24;

public class Sausage : IIngredient
{
    public void Put()
    {
        Console.WriteLine($"{GetType().Name} добавлен в блюдо");
    }

    public void Cook()
    {
        Console.WriteLine($"{GetType().Name} готовится...");
        Thread.Sleep(2000);
        Console.WriteLine($"{GetType().Name } приготовился");
    }

    public void Eat()
    {
        Console.WriteLine($"{GetType().Name} кушаеца");
        Thread.Sleep(1000);
        Console.WriteLine($"{GetType().Name} Скушан");
    }
}