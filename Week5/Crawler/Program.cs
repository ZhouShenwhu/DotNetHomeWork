using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            string startUrl = "https://www.cnblogs.com";
            //string FileRef = @"/(\.(\w+)\?)|(\.(\w+)$)/";
            //Console.WriteLine(Regex.Match(startUrl, FileRef));
            if (args.Length >= 1) startUrl = args[0];
            ZSCrawler myCrawler = new ZSCrawler(startUrl,20);
            //new Thread(myCrawler.Crawl).Start();
            //myCrawler.Crawl();
            //Console.WriteLine(myCrawler.news);
            Thread th1 = new Thread(() =>
            {
                myCrawler.ParallCrawl();
            });
            th1.Start();
        }
    }
}
