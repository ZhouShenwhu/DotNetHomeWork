using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    [Serializable]
    public class OrderDetails
    {
        //商品名称-单价-数量
        public string ProductName { get; }
        public double Price { get; }
        public int Count { get; set; }
        public OrderDetails() { }
        public OrderDetails(string ProductName,double Price,int Count)
        {
            this.ProductName = ProductName;
            this.Price = Price;
            this.Count = Count;
        }
        
        public override string ToString()
        {
            return "商品名称:" + ProductName + ",数量:" + Count + ",价格:" + Price;
        }
        //商品与价格是唯一对应的关系
        //同种类型的商品不同的价格对应不同的名字
        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   ProductName == details.ProductName;
        }

        public override int GetHashCode()
        {
            return EqualityComparer<string>.Default.GetHashCode(ProductName);
        }
    }
}
