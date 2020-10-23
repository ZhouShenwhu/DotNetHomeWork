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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            orderBindingSource.DataSource = OrderService.GetOrders();
            SearchBox.SelectedIndex = 0;
        }
        //查询订单
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string Category = "";
            string Context = "";
            if (SearchBox.SelectedItem.ToString() == null || SearchtextBox.Text == "")
            {
                UpdateView();
                MessageBox.Show("请输入查询的相关信息");
            }
            else
            {
                Category = SearchBox.SelectedItem.ToString();
                Context = SearchtextBox.Text;
                switch (Category)
                {
                    case "订单号":
                        if (int.TryParse(Context, out int res))
                        {
                            orderBindingSource.DataSource =
                                OrderService.SearchByID(res);
                            orderBindingSource.ResetBindings(true);
                        }
                        break;
                    case "商品名":
                        orderBindingSource.DataSource =
                            OrderService.searchByProduct(Context);
                        orderBindingSource.ResetBindings(true);
                        break;
                    case "客户名":
                        orderBindingSource.DataSource =
                            OrderService.searchByClient(Context);
                        orderBindingSource.ResetBindings(true);
                        break;
                    case "总金额":
                        if (double.TryParse(Context, out double price))
                        {
                            orderBindingSource.DataSource =
                                OrderService.searchByGreaterPrice(price, false);
                            orderBindingSource.ResetBindings(true);
                        }
                        break;
                    default:
                        MessageBox.Show("请选择正确的类型");
                        break;
                }
            }
            
        }
        //添加订单
        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                OrderForm AddForm = new OrderForm();
                if (AddForm.ShowDialog() == DialogResult.OK)
                {
                    var newOrder = AddForm.currentOrder;
                    OrderService.AddOrder(newOrder);
                    UpdateView();
                }
            }
            catch(Exception error)
            {
                MessageBox.Show($"添加订单失败{error.Message}");
            }
        }
        
        //刷新DataGridView
        private void UpdateView()
        {
            orderBindingSource.DataSource = OrderService.GetOrders();
            orderBindingSource.ResetBindings(false);
        }
        //删除订单
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Order tmp = orderBindingSource.Current as Order;
                OrderService.DeleteOrder(tmp.OrderID);
                UpdateView();
            }
            catch(Exception error)
            {
                MessageBox.Show($"删除订单失败{error.Message}");
            }
        }
        //删除订单明细
        private void DeleteDetailButton_Click(object sender, EventArgs e)
        {
            try
            {
                OrderDetails tmp = detailsBindingSource.Current as OrderDetails;
                OrderService.DeleteOrderDetail(tmp.ProductName,tmp.OrderID);
                UpdateView();
            }catch(Exception a)
            {
                MessageBox.Show($"删除订单明细失败{a.Message}");
            }
        }
        //双击修改订单明细
        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Order cur = orderBindingSource.Current as Order;
                OrderForm tmp = new OrderForm(cur);
                if (tmp.ShowDialog() == DialogResult.OK)
                {
                    var newOrder = tmp.currentOrder;
                    OrderService.AddOrder(newOrder);
                    UpdateView();
                }
            }
            catch(Exception b)
            {
                MessageBox.Show($"修改订单明细失败{b.Message}");
            }
        }
        //输出为XML文件
        private void ExportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            //MessageBox.Show(saveFileDialog.FileName);
            OrderService.Export(saveFileDialog.FileName);
        }
        //导入文件
        private void ImportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            OrderService.Import(openFileDialog.FileName);
            UpdateView();
        }
    }
}
