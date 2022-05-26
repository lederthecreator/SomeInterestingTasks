namespace Task16.Domain;

public class Car
{
    public virtual Int64 Id { get; set; }
    public virtual string ModelName { get; set; }
    public virtual Int32 Year { get; set; }
    
    public virtual Class ModelClass { get; set; }

    public virtual Person Owner { get; set; }
}

public enum Class
{
    Cheap,
    Average, 
    Luxury
}