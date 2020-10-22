using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderSystemWEBAPI.Models;

namespace OrderSystemWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderServiceController : ControllerBase
    {
        private OrderContext db;
        public OrderServiceController(OrderContext context)
        {
            db = context;
        }
        //查看所有的订单
        [HttpGet("List")]
        public IActionResult GetOrders()
        {
            return Ok(db.Orders.Include("Details").ToList());
        }
        //添加订单
        [HttpPost("AddOrder")]
        public IActionResult AddOrder(Order myOrder)
        {
            try
            {
                var tmpDetails = db.Details.Where(o => o.OrderID == myOrder.OrderID);
                //如果已经包含此订单号则进行订单明细的合并
                if (tmpDetails.Count() >= 1)
                {
                    tmpDetails.ForEachAsync(o => myOrder.AddDetail(o));
                    DeleteOrder(myOrder.OrderID);//删除原有的订单
                    db.Orders.Add(myOrder);//添加修改后的订单
                    db.SaveChanges();
                }
                else
                {
                    db.Orders.Add(myOrder);
                    db.SaveChanges();
                }
                return Ok("添加订单成功");
            }
            catch(Exception e)
            {
                return BadRequest("添加订单失败");
            }
            
        }
        //删除订单
        [HttpGet("DeleteOrder")]
        public IActionResult DeleteOrder(int OrderID)
        {
            try
            {
                var tmp = db.Orders.Include("Details").FirstOrDefault(o => o.OrderID == OrderID);
                db.Orders.Remove(tmp);
                db.SaveChanges();
                return Ok("删除订单成功");
            }
            catch(Exception e)
            {
                return BadRequest("删除订单失败");
            }
        }
        //查询订单
        [HttpGet("SearchByClient")]
        public IActionResult SearchByClient(string Client)
        {
            try
            {
                var res = db.Orders.Where(o => o.Client == Client).Include("Details");
                return Ok(res);
            }catch
            {
                return BadRequest("查询失败");
            }
        }
        [HttpGet("SearchByPrice")]
        public IActionResult SeachByPrice(double price)
        {
            try
            {
                var res = db.Orders.Where(o => o.TotalPrice >= price).Include("Details");
                return Ok(res);
            }
            catch(Exception e)
            {
                return BadRequest("查询失败");
            }
        }
        [HttpGet("SearchByOrderID")]
        public IActionResult SearchByOrderID(int OrderID)
        {
            try
            {
                var res = db.Orders.Where(o => o.OrderID == OrderID).Include("Details");
                return Ok(res);
            }catch
            {
                return BadRequest("查询失败");
            }
        }
        [HttpGet("SearchByProductName")]
        public IActionResult SearchByProductName(string ProductName)
        {
            try
            {
                var OrderID = db.Details.Where(o => o.ProductName == ProductName).Select(o => o.OrderID).ToList();
                if(OrderID.Count!=0)
                {
                    var res = db.Orders.Where(x => OrderID.Contains(x.OrderID)).Include("Details");
                    return Ok(res);
                }
                return BadRequest("无包含此商品的订单");
            }catch
            {
                return BadRequest("查询失败");
            }
        }

    }
}
