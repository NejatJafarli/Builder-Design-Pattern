using System;

namespace Prototype
{
    interface IProtoType
    {
        IProtoType Clone();
    }

    class Order:IProtoType
    {
        public string Name { get; set; }
        public double Price {  get; set; }
        public DateTime Date {  get; set; }
        public Order(Order other)
        {
            Name = other.Name;
            Price = other.Price;
            Date = other.Date;
        }

        public Order(string name, double price, DateTime date)
        {
            Name = name;
            Price = price;
            Date = date;
        }

        public IProtoType Clone()=>new Order(this);

        public override string ToString()
        {
            return $"   Name:{Name}\n   Price:{Price}\n   Date:{Date.ToShortDateString()}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Order order= new Order("Kola",1.6,new DateTime(2021,10,5));



            Order newOrder = order.Clone() as Order;

            order.Name = "Pepsi";

            Console.WriteLine(order);
            Console.WriteLine();
            Console.WriteLine(newOrder);
        }
    }
}
