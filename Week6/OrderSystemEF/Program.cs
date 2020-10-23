using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
            Order UpdateOrder = new Order(1, "Jack", "Apple", 12, 6);

            //OrderService.DeleteOrder(a.OrderID);
            /*增加订单测试通过
            OrderService.AddOrder(a);
            OrderService.AddOrder(b);
            OrderService.AddOrder(c);
            OrderService.AddOrder(d);
            OrderService.AddOrder(e);
            OrderService.AddOrder(f);
            */
            var res = OrderService.GetOrders();
            foreach(var i in res)
            {
                Console.WriteLine(i);
            }
            //OrderService.DeleteOrder(a.OrderID);删除订单测试通过
            /*更新订单测试通过
            OrderService.AddOrder(a);
            OrderService.UpdateOrder(UpdateOrder);
            */
            //Console.WriteLine(OrderService.SearchByID(1));
            /*
            var res = OrderService.searchByProduct("Apple");
            foreach(var i in res)
            {
                Console.WriteLine(i);
            }*/
            Console.ReadLine();
        }
    }
}
