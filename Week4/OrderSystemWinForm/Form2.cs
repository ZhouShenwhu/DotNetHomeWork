using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderSystemWinForm
{
    public partial class Form2 : Form
    {
        //定义委托
        public delegate void SendValue(int ID,string Cname,string Pname,double Price,int count);
        //创建事件
        public event SendValue SendFromForm2;
        int OrderID;
        string Cname;
        string Pname;
        double Price;
        int count;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(int OrderID,string cname)
        {
            this.OrderID = OrderID;
            this.Cname = cname;
            this.Pname = "";
            this.Price = 0;
            this.count = 0;
            InitializeComponent();
            this.textBoxID.Text = this.OrderID.ToString();
            this.textBoxCname.Text = this.Cname;
        }
        public Form2(int OrderID, string cname,string Pname)
        {
            this.OrderID = OrderID;
            this.Cname = cname;
            this.Pname = Pname;
            this.Price = 0;
            this.count = 0;
            InitializeComponent();
            this.textBoxID.Text = this.OrderID.ToString();
            this.textBoxCname.Text = this.Cname;
            this.textBoxPname.Text = this.Pname;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        //点击完成按钮发生的时间(新建订单或者添加订单明细)
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag1 = (textBoxID.Text != "" && int.TryParse(textBoxID.Text, out OrderID));
            bool flag2 = (textBoxPrice.Text != "" && double.TryParse(textBoxPrice.Text, out Price));
            bool flag3 = (textBoxCount.Text != "" && int.TryParse(textBoxCount.Text, out count));
            this.Cname = textBoxCname.Text;
            this.Pname = textBoxPname.Text;
            if (!(flag1 && flag2 && flag3))
                MessageBox.Show("请正确输入");
            else
            {
                //准备相关的数据
                SendFromForm2(OrderID, Cname, Pname, Price, count);
                Close();
            }
        }
    }
}
