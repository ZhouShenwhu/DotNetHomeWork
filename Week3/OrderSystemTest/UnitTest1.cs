using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OrderSystem;
using System.Security.Cryptography.X509Certificates;

namespace OrderSystemTest
{
    [TestClass]
    public class UnitTest1
    {
        OrderService ZS;

        Order a = new Order(1, "Bob", "apple", 5, 15);
        Order b = new Order(2, "Jack", "Orange", 1, 15);
        Order c = new Order(1, "Bob", "apple", 5, 17);

        Order c_a = new Order(1, "Bob", "apple", 5, 32);

        [TestInitialize]
        public void InitOrder()
        {
            ZS = new OrderService();
            ZS.AddOrder(a);
            ZS.AddOrder(b);
            ZS.AddOrder(c);
        }
        [TestMethod]
        public void TestAdd()
        {
            var res = new List<Order> { c_a, b };
            CollectionAssert.AreEqual(ZS.orders, res);
        }
        [TestMethod]
        public void TestDelete()
        {
            ZS.DeleteOrder(1);
            
            var res = new List<Order> { b };
            CollectionAssert.AreEqual(ZS.orders, res);
            ZS.AddOrder(c_a);
        }
        [TestMethod]
        public void TestSortOrder()
        {
            ZS.SortOrder("ID");
            var res1 = new List<Order> { c_a, b };
            CollectionAssert.AreEqual(ZS.orders, res1);

            ZS.SortOrder("TotalPrice");
            var res2 = new List<Order> { b, c_a };
            //ZS.orders.ForEach(x => Console.WriteLine(x));
            CollectionAssert.AreEqual(ZS.orders, res2);
        }
        [TestMethod]
        public void TestXML()
        {
            ZS.Export();
            List<Order> res = ZS.orders;
            ZS.Import();
            CollectionAssert.Equals(ZS.orders, ZS);
        }
        [TestMethod]
        public void TestSearch()
        {
            var res1 = ZS.SearchByID(2);
            foreach (var i in res1)
            {
                Console.WriteLine(i);
            }

            var res2 = ZS.searchByClient("Bob");
            foreach (var i in res2)
            {
                Console.WriteLine(i);
            }

            var res3 = ZS.searchByProduct("Orange");
            foreach (var i in res3)
            {
                Console.WriteLine(i);
            }
        }

    }
}
