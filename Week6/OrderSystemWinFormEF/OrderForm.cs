using OrderSystemEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderSystemWinFormEF
{
    public partial class OrderForm : Form
    {
        public Order currentOrder;

        public OrderForm()
        {
            InitializeComponent();
        }
        public OrderForm(Order myOrder)
        {
            InitializeComponent();
            textBoxID.Text = myOrder.OrderID.ToString();
            textBoxID.Enabled = false;
            textBoxCname.Text = myOrder.Client;
            textBoxCname.Enabled = false;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(textBoxID.Text,out int OrderID))
            {
                MessageBox.Show("ID只能由数字组成");
                return;
            }
            string Client = textBoxCname.Text;
            string ProductName = textBoxPname.Text;
            if(!Double.TryParse(textBoxPrice.Text,out double Price))
            {
                MessageBox.Show("金额只能由数字组成");
                return;
            }
            if(!int.TryParse(textBoxCount.Text,out int Count))
            {
                MessageBox.Show("数量只能由数字组成");
                return;
            }
            //如果订单号已存在且用户名不匹配则拒绝
            var tmp = OrderService.SearchByID(OrderID);
            if(tmp!=null && tmp.Client!=Client)
            {
                MessageBox.Show("ID与用户名不匹配");
                return;
            }
            currentOrder = new Order(OrderID, Client, ProductName, Price, Count);
        }
    }
}
