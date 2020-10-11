using Crawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CrawlerWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = zSCrawlerBindingSource;
            dataGridView1.DataMember = "URLS";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string startUrl = richTextBoxUrl.Text;
            TextBoxOutput.Text = $"准备开始爬行\r\n";
            string news = null;
            List<Urlstatus> Urls = null;
            ZSCrawler mycrawler = new ZSCrawler(startUrl, 5);
            Thread th1 = new Thread(() =>
            {
                if (mycrawler.ParallCrawl())
                {
                    //MessageBox.Show(mycrawler.news);
                    news = mycrawler.news;

                }
            });
            th1.Start();//开启线程
            th1.Join();//等待th1线程结束
            TextBoxOutput.Text += news;
            TextBoxOutput.Text += $"爬行结束\r\n";
            zSCrawlerBindingSource.DataSource = mycrawler.GetUrls();
            zSCrawlerBindingSource.ResetBindings(false);
        }
    }
}
