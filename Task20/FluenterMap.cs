using FluentNHibernate.Mapping;

namespace Task20;

public class FluenterMap : ClassMap<Fluenter>
{
    public FluenterMap()
    {
        Id(x => x.Id);
        Map(x => x.FirstName);
        Map(x => x.LastName);
        Table("Fluents");
    }
}