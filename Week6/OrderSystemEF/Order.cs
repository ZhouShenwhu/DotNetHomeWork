using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderSystemEF
{
    [Serializable]
    public class Order : IComparable
    {
        //订单号-客户-总价格
        [Key]
        //取消OrderID自增
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }
        public string Client { get; set; }
        [XmlIgnore]
        public double TotalPrice
        {
            get => Details.Sum(o => o.Price * o.Count);
            set { }
        }
        //存储一个订单所有的订单明细
        public List<OrderDetails> Details { get; set; }
        //不同的构造函数
        public Order() { Details = new List<OrderDetails>(); }
        public Order(int OrderID, string Client)
        {
            this.OrderID = OrderID;
            this.Client = Client;
            Details = new List<OrderDetails>();
        }
        public Order(int OrderID, string Client, string pname, double price, int count)
        {
            Details = new List<OrderDetails>();
            this.OrderID = OrderID;
            this.Client = Client;
            AddDetail(pname, price, count,OrderID);
        }
        public Order(int OrderID, string Client, OrderDetails detail)
        {
            Details = new List<OrderDetails>();
            this.OrderID = OrderID;
            this.Client = Client;
            AddDetail(detail);
        }

        //添加订单明细(注意：添加之后要重新计算价格以及同种商品要进行订单明细的合并)
        public void AddDetail(OrderDetails Detail)
        {
            /*一个订单中每个商品拥有一条订单明细,如果商品名称相同则修改数量*/
            if (!Details.Contains(Detail))
                Details.Add(Detail);
            else
                Details.ForEach(x =>
                {
                    if (x.ProductName == Detail.ProductName)
                        x.Count += Detail.Count;
                });
            //CalTotalPrice();
        }
        public void AddDetail(string pname, double price, int count,int OrderID)
        {
            bool flag = false;
            foreach (OrderDetails i in Details)
            {
                if (i.ProductName == pname)
                {
                    i.Count += count;
                    flag = true;
                }
            }
            if (flag == false)
            {
                OrderDetails tmp = new OrderDetails(pname, price, count,OrderID);
                Details.Add(tmp);
            }
            //CalTotalPrice();
        }
        //删除订单明细
        public void DeleteDetail(OrderDetails Detail)
        {
            if (Details.Contains(Detail))
                Details.RemoveAll(x => x.Equals(Detail));
            else
                Console.WriteLine("订单明细不存在，请重新输入。");
        }
        public void DeleteDetail(string pname)
        {
            var ItemToRemove = Details.Single(r => r.ProductName == pname);
            if (ItemToRemove != null)
                Details.Remove(ItemToRemove);
            else
                Console.WriteLine("此商品不存在！");
        }
        
        //重写Equals函数
        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   OrderID == order.OrderID;
        }
        public override int GetHashCode()
        {
            return OrderID.GetHashCode();
        }
        //重写ToString函数
        public override string ToString()
        {
            return "订单号:" + OrderID + ",客户:" + Client + ",订单总价:" + TotalPrice;
        }
        //默认排序按照总价格进行升序排序
        public int CompareTo(object obj)
        {
            if (!(obj is Order))
                throw new System.ArgumentException();
            Order tmp = obj as Order;
            return TotalPrice.CompareTo(tmp.TotalPrice);
        }
    }
}
