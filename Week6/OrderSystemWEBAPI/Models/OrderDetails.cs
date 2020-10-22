using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystemWEBAPI.Models
{
    public class OrderDetails
    {
        //商品名称-单价-数量
        [Key, Column(Order = 1)]
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        [Key, Column(Order = 2)]
        public int OrderID { get; set; }//自动识别为外键
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }
        public OrderDetails() { }
        public OrderDetails(string ProductName, double Price, int Count, int OrderID)
        {
            this.ProductName = ProductName;
            this.Price = Price;
            this.Count = Count;
            this.OrderID = OrderID;
        }
        //商品与价格是唯一对应的关系
        //同种类型的商品不同的价格对应不同的名字
        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   ProductName == details.ProductName &&
                   OrderID == details.OrderID;
        }
        public override int GetHashCode()
        {
            int hashCode = -1363627399;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
            hashCode = hashCode * -1521134295 + OrderID.GetHashCode();
            return hashCode;
        }
    }
}
