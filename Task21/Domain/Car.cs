namespace Task21.Domain;

public class Car
{
    public virtual int Id { get; set; }
    public virtual string Number { get; set; }
    public virtual int Speed { get; set; }
    public virtual string Color { get; set; }
    
    //public virtual Person Owner { get; set; }
}