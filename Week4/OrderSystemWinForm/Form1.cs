using OrderSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderSystemWinForm
{
    public partial class Form1 : Form
    {
        OrderService zs = null;
        
        
        int OrderID_new;
        string Cname_new;
        string Pname_new;
        double Price_new;
        int count_new;
        public Form1()
        {
            InitializeComponent();//初始化所有控件
            zs = new OrderService();
            Order a = new Order(1, "Jack", "Apple", 3.5, 6);
            Order b = new Order(1, "Jack", "Banana", 4.7, 4);
            Order c = new Order(2, "Tim", "Orange", 5.1, 8);
            zs.AddOrder(a);
            zs.AddOrder(b);
            zs.AddOrder(c);
            orderBindingSource.DataSource = zs.GetOrders();
            dataGridView2.DataSource = orderBindingSource;
            dataGridView2.DataMember = "AllDetail";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //创建订单
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            Form2 MyForm = new Form2();
            MyForm.SendFromForm2 += new Form2.SendValue(NewOrderInfo);
            if (MyForm.ShowDialog() == DialogResult.OK)
            {
                Order tmp = new Order(OrderID_new, Cname_new, Pname_new, Price_new, count_new);
                zs.AddOrder(tmp);
                FlushList();
            }
        }
        //传递数据
        void NewOrderInfo(int ID, string Cname, string Pname, double Price, int count)
        {
            OrderID_new = ID;
            Cname_new = Cname;
            Pname_new = Pname;
            Price_new = Price;
            count_new = count;
        }
        //刷新所有的数据
        void FlushList()
        {
            orderBindingSource.DataSource = zs.GetOrders();
            orderBindingSource.ResetBindings(false);
        }
        //订单添加明细
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Order tmp = orderBindingSource.Current as Order;
            //MessageBox.Show(tmp.OrderID.ToString());
            if (tmp != null)
            {
                Form2 myForm = new Form2(tmp.OrderID,tmp.Client);
                myForm.SendFromForm2 += new Form2.SendValue(NewOrderInfo);
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    Order tmp2 = new Order(OrderID_new, Cname_new, Pname_new, Price_new, count_new);
                    zs.AddOrder(tmp2);
                    FlushList();
                }
            }
            else
                MessageBox.Show("请选定需要添加明细的订单");
        }
        //删除选定的订单
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            Order tmp = orderBindingSource.Current as Order;
            if (tmp != null)
            {
                zs.DeleteOrder(tmp.OrderID);
                FlushList();
            }
            else
                MessageBox.Show("请选定需要删除的订单");
        }
        //查找订单
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            //按照OrderID查找
            int OrderID_S = -1;
            if (textBoxID.Text!="" && int.TryParse(textBoxID.Text,out OrderID_S))
            {
                orderBindingSource.DataSource = zs.SearchByID(OrderID_S).ToList();
                orderBindingSource.ResetBindings(false);
                return;
            }
            
            //按照Client进行查找
            if(textBoxCname.Text!="")
            {
                orderBindingSource.DataSource = zs.searchByClient(textBoxCname.Text).ToList();
                orderBindingSource.ResetBindings(false);
                return;
            }

            //按照ProductName进行查找
            if (textBoxPname.Text != "")
            {
                orderBindingSource.DataSource = zs.searchByProduct(textBoxPname.Text).ToList();
                orderBindingSource.ResetBindings(false);
                return;
            }

            //按照价格
            double price_s = -1;
            if(textBoxPrice.Text != "" && double.TryParse(textBoxPrice.Text, out price_s))
            {
                orderBindingSource.DataSource = zs.searchByGreaterPrice(price_s,true).ToList();
                orderBindingSource.ResetBindings(false);
                return;
            }
            FlushList();
        }
        //对订单进行排序
        private void ButtonSort_Click(object sender, EventArgs e)
        {
            if(radioID.Checked==true)
            {
                zs.SortOrder("ID");
                FlushList();
                return;
            }
            if(radioPrice.Checked==true)
            {
                zs.SortOrder("TotalPrice");
                FlushList();
                return;
            }
            FlushList();
        }
        //保存为xml文件
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            //MessageBox.Show(saveFileDialog.FileName);
            zs.Export(saveFileDialog.FileName);
        }
        //载入保存的文件
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            zs.Import(openFileDialog.FileName);
            FlushList();
        }        
        //修改订单(双击订单明细即可)
        private void dataGridView2_CellDoubleClick(object sender, EventArgs e)
        {
            string pname = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            Order tmp = orderBindingSource.Current as Order;
            Form2 MyForm = new Form2(tmp.OrderID,tmp.Client,pname);
            MyForm.SendFromForm2 += new Form2.SendValue(NewOrderInfo);
            MyForm.ShowDialog();

            zs.DeleteOrder(tmp.OrderID);
            //更新订单明细
            tmp.DeleteDetail(pname);
            tmp.AddDetail(new OrderDetails(Pname_new, Price_new, count_new));

            zs.AddOrder(tmp);
            FlushList();
        }
    }
}
