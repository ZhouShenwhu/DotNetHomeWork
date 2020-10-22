using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystemEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Order a = new Order(1, "Jack", "Apple", 12, 2);
            Order b = new Order(1, "Jack", "Apple", 12, 3);
            Order c = new Order(2, "Tim", "Banana", 123, 2);
            Order d = new Order(2, "Tim", "Apple", 12, 2);
            Order e = new Order(3, "Lily", "Orange", 12, 2);
            Order f = new Order(3, "Lily", "Peach", 12, 2);
            //OrderService.DeleteOrder(a.OrderID);
            /*
            OrderService.AddOrder(a);
            OrderService.AddOrder(b);
            OrderService.AddOrder(c);
            OrderService.AddOrder(d);
            OrderService.AddOrder(e);
            OrderService.AddOrder(f);
            */
            OrderService.DeleteOrder(a.OrderID);
            OrderService.AddOrder(a);
            Console.ReadLine();
        }
    }
}
