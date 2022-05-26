using Task17.Domain;

namespace Task17.Domain;

public class Order
{
    public virtual Int32 Id { get; set; } 
    public virtual DateTime Ordered { get; set; } 
    public virtual DateTime? Shipped { get; set; }
    public virtual Location ShipTo { get; set; } 
    public virtual Customer Customer { get; set; }

    public override string ToString()
    {
        return string.Format("Order Id: {0}", Id);
    }
}