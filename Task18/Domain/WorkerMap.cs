using FluentNHibernate.Mapping;

namespace Task18.Domain;

public class WorkerMap : ClassMap<Worker>
{
    public WorkerMap()
    {
        Id(x => x.Id)
            .Column("id");
        Map(x => x.Name)
            .Column("name");
        Map(x => x.Login)
            .Column("login");
        Map(x => x.Age)
            .Column("age");
        Map(x => x.Salary)
            .Column("salary");
        Map(x => x.Date)
            .Column("date");
        Table("testdb.workers");
    }
}