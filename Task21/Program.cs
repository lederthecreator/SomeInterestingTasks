using Task21;
using Task21.Domain;

using var session = NHibernateHelper.OpenSession();
using var tx = session.BeginTransaction();
var rnd = new Random();

for (var i = 0; i < 100; i += 1)
{
    var car = new Car()
    {
        Color = GetColor(),
        Number = $"Car{i + 1}",
        Speed = rnd.Next(20, 200),
    };
    CarRepository.Add(car);
}

var getCar = session.Get<Car>(3);
Console.WriteLine($"getCar Number: {getCar.Number}, Speed {getCar.Speed}, Color {getCar.Color}");

string GetColor()
{
    var color = rnd.Next(100) switch
    {
        < 33 => "red",
        >= 33 and < 66 => "green",
        >= 66 => "blue"
    };
    return color;
}