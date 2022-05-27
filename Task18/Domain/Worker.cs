using System.Text;

namespace Task18.Domain;

public class Worker
{
    public virtual Int64 Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Login { get; set; }
    public virtual Int32 Age { get; set; }
    
    public virtual Int32 Salary { get; set; }
    public virtual DateTime Date { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"\t{Name} |\t {Login} |\t {Age} |\t {Date.ToShortDateString()} {Date.ToLongTimeString()}");
        return sb.ToString();
    }
}