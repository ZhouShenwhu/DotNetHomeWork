using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    [Serializable]
    public class Order:IComparable
    {
        //订单号-客户-总价格
        public int OrderID { get; set; }
        public string Client { get; set; }
        public double TotalPrice { get; set; }
        //存储一个订单所有的订单明细
        public List<OrderDetails> Details = new List<OrderDetails>();

        //不同的构造函数
        public Order() { }
        public Order(int OrderID,string Client,string pname, double price, int count)
        {
            this.OrderID = OrderID;
            this.Client = Client;
            AddDetail(pname, price, count);
        }
        public Order(int OrderID,string Client,OrderDetails detail)
        {
            this.OrderID = OrderID;
            this.Client = Client;
            AddDetail(detail);
        }
        //添加订单明细(注意：添加之后要重新计算价格)
        public void AddDetail(OrderDetails Detail)
        {
            /*一个订单中每个商品拥有一条订单明细,如果商品名称相同则修改数量*/
            bool flag = false;
            foreach (OrderDetails i in Details)
            {
                if (i.Equals(Detail))
                {
                    i.Count += Detail.Count;
                    flag = true;
                }
            }
            if (flag == false) Details.Add(Detail);
            CalTotalPrice();
        }
        public void AddDetail(string pname, double price, int count)
        {
            bool flag = false;
            foreach(OrderDetails i in Details)
            {
                if(i.ProductName==pname)
                {
                    i.Count += count;
                    flag = true;
                }
            }
            if (flag == false)
            {
                OrderDetails tmp = new OrderDetails(pname, price, count);
                Details.Add(tmp);
            }
            CalTotalPrice();
        }
        //删除订单明细
        public void DeleteDetail(OrderDetails Detail)
        {
            bool flag = true;
            Details.ForEach(x =>
            {
                if (x.Equals(Detail))
                {
                    Details.Remove(Detail);
                    flag = false;
                }
            });
            if (flag == true) Console.WriteLine("订单明细不存在，请重新输入。");
        }
        public void DeleteDetail(string pname)
        {
            bool flag = true;
            Details.ForEach(x =>
            {
                if (x.ProductName == pname)
                {
                    Details.Remove(x);
                    flag = false;
                }
            });
            if (flag == true) Console.WriteLine("此商品不存在！");
        }
        //计算总价格
        public void CalTotalPrice()
        {
            //使用lambda表达式重新计算总价格
            this.TotalPrice = 0;
            Details.ForEach(x => this.TotalPrice += x.Price * x.Count);
        }
        //重写Equals函数与ToString函数
        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   OrderID == order.OrderID;
        }

        public override int GetHashCode()
        {
            return OrderID.GetHashCode();
        }

        public override string ToString()
        {
            return "订单号:" + OrderID + ",客户:" + Client + ",订单总价:" + TotalPrice;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Order))
                throw new System.ArgumentException();
            Order tmp = obj as Order;
            return TotalPrice.CompareTo(tmp.TotalPrice);
        }
    }
}
