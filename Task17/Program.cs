using Task17;
using Task17.Domain;

int id;

using var session = NHibernateHelper.GetSession();
using var transaction = session.BeginTransaction();
var newCustomer = CreateCustomer();
Console.WriteLine("new customer:");
Console.WriteLine(newCustomer);
session.Save(newCustomer);
foreach (var order in newCustomer.Orders)
{
    session.Save(order);
}

id = newCustomer.Id;
transaction.Commit();
transaction.Dispose();

var loaded = session.Load<Customer>(id);
Console.WriteLine("orders were ordered by");
foreach (var order in loaded.Orders)
{
    Console.WriteLine(order.Customer);
}
transaction.Commit();


Customer CreateCustomer() { 
		
    var customer = new Customer { 
        FirstName = "John", 
        LastName = "Doe", 
        Points = 100, 
        HasGoldStatus = true, 
        MemberSince = new DateTime(2012, 1, 1), 
        CreditRating = CustomerCreditRating.Good, 
        AverageRating = 42.42424242, 
        Address = CreateLocation() 
    }; 
         
    var order1 = new Order { 
        Ordered = DateTime.Now
    }; 
         
    customer.AddOrder(order1); 
			
    var order2 = new Order { 
        Ordered = DateTime.Now.AddDays(-1), 
        Shipped = DateTime.Now, 
        ShipTo = CreateLocation() 
    }; 
         
    customer.AddOrder(order2); 
    return customer; 
} 
      
Location CreateLocation() { 
		
    return new Location { 
        Street = "123 Somewhere Avenue", 
        City = "Nowhere", 
        Province = "Alberta", 
        Country = "Canada" 
    }; 
} 