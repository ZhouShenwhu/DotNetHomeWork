using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace OrderSystem
{
    public class OrderService
    {
        private List<Order> orders;
        
        public OrderService()
        {
            orders = new List<Order>();
        }
        //返回订单号
        public List<Order> GetOrders()
        {
            return orders;
        }
        //添加订单（需要检查订单号是否重复）
        public void AddOrder(Order myOrder)
        {
            /*如果订单号已经存在则合并订单*/
            bool flag = false;
            orders.ForEach(x =>
            {
                if (x.Equals(myOrder))
                {
                    //AddDetail函数=>防止商品名称重复
                    myOrder.AllDetail.ForEach(m => x.AddDetail(m));
                    flag = true;
                }
            });
            if (flag == false) orders.Add(myOrder);
        }
        //删除订单
        public void DeleteOrder(int ID)
        {
            orders.RemoveAll(x => x.OrderID == ID);
            //bool flag = false;
            //Order tmp = null;
            //orders.ForEach(x =>
            //{
            //    if (x.OrderID == ID)
            //    {
            //        tmp = x;
            //        flag = true;
            //    }
            //});
            //if (flag == false)
            //    Console.WriteLine("未找到此订单号，请重新输入");
            //else
            //    orders.Remove(tmp);
        }
        //使用lambda表达式按照订单号进行排序
        public void SortOrder(string type)
        {
            switch (type)
            {
                case "ID": orders.Sort((a, b) => a.OrderID - b.OrderID); break;
                case "TotalPrice":
                    //利用ICompare实现的接口进行排序
                    orders.Sort(); break;
                default: break;
            }
        }
        /*使用Linq语句进行查询，查询结果使用OrderBy按照TotalPrice升序排列*/
        //使用订单号进行查询
        public IEnumerable<Order> SearchByID(int ID)
        {
            var res = from s in orders
                      where s.OrderID == ID
                      orderby s.TotalPrice
                      select s;
            return res;
        }
        //按照订单的价格进行查询(0:>,1:<)
        public IEnumerable<Order> searchByGreaterPrice(double price, bool flag)
        {
            if (flag == false)
            {
                var res = from s in orders
                          where s.TotalPrice >= price
                          select s;
                return res;
            }
            else
            {
                var res = from s in orders
                          where s.TotalPrice <= price
                          select s;
                return res;
            }
        }
        //使用客户名进行查询
        public IEnumerable<Order> searchByClient(string Client)
        {
            var res = from s in orders
                      where s.Client == Client
                      orderby s.TotalPrice
                      select s;
            return res;
        }
        //按照商品名查询
        public IEnumerable<Order> searchByProduct(string pname)
        {
            var res = from s in orders
                      where isProductInOrder(pname, s)
                      orderby s.TotalPrice
                      select s;
            return res;
        }
        //判断订单中是否包含某件商品
        public bool isProductInOrder(string pname, Order Jorder)
        {
            bool flag = false;
            Jorder.AllDetail.ForEach(x =>
            {
                if (x.ProductName == pname) flag = true;
            });
            return flag;
        }
        //将订单序列化为XML文件,以及反序列化加载到程序中
        public void Export(string filename)
        {
            try
            {
                if (Path.GetExtension(filename) != ".xml")
                    throw new Exception("输出文件的格式必须是xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, orders);
                }
            }
            catch
            {
                throw new Exception("Serialize Failed!");
            }
        }
        public void Import(string path)
        {
            try
            {
                if (Path.GetExtension(path) != ".xml")
                    throw new Exception("文件不存在或格式不规范！");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    orders = (List<Order>)xmlSerializer.Deserialize(fs);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
