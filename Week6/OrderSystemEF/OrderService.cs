using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderSystemEF
{
    public class OrderService
    {
        public OrderService() { }
        //返回所有的订单
        public static List<Order> GetOrders()
        {
            using(var db = new OrderContext())
            {
                return db.Orders.Include("Details").ToList();
            }
        }
        //添加订单
        public static void AddOrder(Order myOrder)
        {
            using(var db = new OrderContext())
            {
                var tmpDetails = db.Details.Where(o => o.OrderID == myOrder.OrderID);
                //如果已经包含此订单号则进行订单明细的合并
                if (tmpDetails.Count()>=1)
                {
                    tmpDetails.ForEachAsync(o => myOrder.AddDetail(o));
                    db.Details.RemoveRange(tmpDetails);
                    db.Details.AddRange(myOrder.Details);
                    db.SaveChanges();
                }
                else
                {
                    db.Orders.Add(myOrder);
                    db.SaveChanges();
                }
                
            }
        }
        //删除订单
        public static void DeleteOrder(int ID)
        {
            using (var db = new OrderContext())
            {
                var tmp = db.Orders.Include("Details").FirstOrDefault(o => o.OrderID == ID);
                db.Orders.Remove(tmp);
                db.SaveChanges();
            }
        }
        //删除订单明细
        public static void DeleteOrderDetail(string ProductName,int OrderID)
        {
            using(var db = new OrderContext())
            {
                var res = db.Details
                    .FirstOrDefault(x => x.OrderID == OrderID && x.ProductName == ProductName);
                db.Details.Remove(res);
                db.SaveChanges();
            }
        }
        //修改订单
        public static void UpdateOrder(Order newOrder)
        {
            DeleteOrder(newOrder.OrderID);
            AddOrder(newOrder);
        }
        //使用订单号进行查询（订单号是唯一的）
        public static Order SearchByID(int ID)
        {
            using(var db = new OrderContext())
            {
                var res = db.Orders.Include(o=>o.Details).FirstOrDefault(x => x.OrderID == ID);
                return res;
            }
        }
        //按照订单的价格进行查询(0:>,1:<)
        public static List<Order> searchByGreaterPrice(double price, bool flag)
        {
            using(var db = new OrderContext())
            {
                if(!flag)
                {
                    var res = db.Orders.Include("Details").Where(o => o.TotalPrice >= price).ToList();
                    return res;
                }
                else
                {
                    var res = db.Orders.Include("Details").Where(o => o.TotalPrice <= price).ToList();
                    return res;
                }
            }
        }
        //使用客户名进行查询
        public static List<Order> searchByClient(string Client)
        {
            using(var db = new OrderContext())
            {
                var res = db.Orders.Include("Details").Where(o => o.Client == Client);
                return res.ToList();
            }
        }
        //按照商品名查询
        public static List<Order> searchByProduct(string pname)
        {
            using(var db = new OrderContext())
            {
                List<int> IDList = db.Details.Where(o => o.ProductName == pname).Select(o => o.OrderID).ToList();
                var res = db.Orders.Include("Details").Where(o => IDList.Contains(o.OrderID));
                return res.ToList();
            }
        }
        //将订单序列化为XML文件,以及反序列化加载到程序中
        public static void Export(string filename)
        {
            try
            {
                if (Path.GetExtension(filename) != ".xml")
                    throw new Exception("输出文件的格式必须是xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, GetOrders());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Import(string path)
        {
            try
            {
                if (Path.GetExtension(path) != ".xml")
                    throw new Exception("文件不存在或格式不规范！");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    var tmp = (List<Order>)xmlSerializer.Deserialize(fs);
                    tmp.ForEach(o => AddOrder(o));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
