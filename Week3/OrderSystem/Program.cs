using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //int OrderID,string Client,string pname, double price, int count
            Order a = new Order(1, "Bob", "apple", 5, 15);
            Order b = new Order(2, "Jack", "Orange", 5, 15);
            Order c = new Order(1, "Bob", "apple", 5, 17);
            Order d = new Order(3, "Bob", "banana", 5, 20);
            Order e = new Order(4, "Bob", "apple", 5, 26);
            Order f = new Order(5, "Bob", "apple", 5, 10);



            OrderService ZS = new OrderService();
            ZS.AddOrder(a);
            ZS.AddOrder(b);
            ZS.AddOrder(c);
            ZS.AddOrder(d);
            ZS.AddOrder(e);
            ZS.AddOrder(f);
            ZS.DeleteOrder(2);
            ZS.SortOrder("TotalPrice");
            //ZS.orders.ForEach(x => Console.WriteLine(x));

            ZS.SortOrder("ID");
            //ZS.orders.ForEach(x => Console.WriteLine(x));
            var res1 = ZS.SearchByID(2);
            foreach(var i in res1)
            {
                Console.WriteLine(i);
            }
            ZS.Export();
            ZS.Import();
            var res2 = ZS.searchByClient("Bob");
            foreach (var i in res2)
            {
                Console.WriteLine(i);
            }
            var res3 = ZS.searchByProduct("banana");
            foreach (var i in res3)
            {
                
                Console.WriteLine(i);
            }
        }
    }
}
