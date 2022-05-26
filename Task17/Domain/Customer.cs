using Iesi.Collections.Generic;
using System;
using System.Text;
using System.Collections.Generic;

namespace Task17.Domain;

public class Customer
{
    public Customer()
    {
        MemberSince = DateTime.UtcNow;
        Orders = new HashSet<Order>();
    }

    public virtual Int32 Id { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual double AverageRating { get; set; }
    public virtual int Points { get; set; }

    public virtual bool HasGoldStatus { get; set; }
    public virtual DateTime MemberSince { get; set; }
    public virtual CustomerCreditRating CreditRating { get; set; }
    public virtual Location Address { get; set; }

    public virtual ISet<Order> Orders { get; set; }

    public virtual void AddOrder(Order order)
    {
        Orders.Add(order);
        order.Customer = this;
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append($"{FirstName} {LastName} {Id} \n");
        result.Append($"Points {Points} \n");
        result.Append($"Has gold status: {HasGoldStatus} \n");
        result.Append($"Member since {MemberSince.ToLongDateString()} \n");
        result.Append($"Credit rating: {CreditRating} \n");
        result.Append($"Average rating: {AverageRating} \n");

        return result.ToString();
    }

}

public class Location { 
        public virtual string Street { get; set; } 
        public virtual string City { get; set; } 
        public virtual string Province { get; set; } 
        public virtual string Country { get; set; } 
    }
   
    public enum CustomerCreditRating { 
        Excellent,
        VeryVeryGood, 
        VeryGood, 
        Good, 
        Neutral, 
        Poor, 
        Terrible 
    } 