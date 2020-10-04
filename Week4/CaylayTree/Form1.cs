using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaylayTree
{
    public partial class Form1 : Form
    {
        public int N { get; set; }
        public int L { get; set; }
        public double Per1 { get; set; }
        public double Per2 { get; set; }
        public double th1 { get; set; }
        public double th2 { get; set; }
        public Pen pen { get; set; }
        private Graphics graphics;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            L = 100; N = 10; Per1 = 0.6; Per2 = 0.7;
            th1 = 30 * Math.PI / 180;
            th2 = 20 * Math.PI / 180;
            Pen[] pens = { Pens.Red, Pens.Gray, Pens.DarkGray, Pens.Silver, Pens.Green,Pens.Pink };
            pen = pens[0];
            PenColor.DataSource = pens;
            PenColor.DisplayMember = "Color";
            PenColor.DataBindings.Add("SelectedItem", this, "Pen");
            textBoxN.DataBindings.Add("Text", this, "N");
            textBoxL.DataBindings.Add("Text", this, "L");
            textBoxPer1.DataBindings.Add("Text", this, "Per1");
            textBoxPer2.DataBindings.Add("Text", this, "Per2");
            textBoxTh1.DataBindings.Add("Text", this, "th1");
            textBoxTh2.DataBindings.Add("Text", this, "th2");
            
        }
        void DrawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            DrawLine(x0, y0, x1, y1);

            DrawCayleyTree(n - 1, x1, y1, Per1 * leng, th + th1);
            DrawCayleyTree(n - 1, x1, y1, Per2 * leng, th - th2);
        }
        void DrawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(pen,(int)x0,(int)y0,(int)x1,(int)y1);
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            graphics = panel1.CreateGraphics();
            graphics.Clear(Color.White);
            DrawCayleyTree(N, panel1.Width/2, panel1.Height, L, -Math.PI / 2);
        }

    }
}
