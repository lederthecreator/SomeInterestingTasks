using FluentNHibernate.Mapping;

namespace Task21.Domain;

public class CarMap : ClassMap<Car>
{
    public CarMap()
    {
        Id(x => x.Id)
            .Column("id");
        Map(x => x.Number)
            .Column("number");
        Map(x => x.Speed)
            .Column("speed");
        Map(x => x.Color)
            .Column("color");
        Table("testdb.task21");
    }
}