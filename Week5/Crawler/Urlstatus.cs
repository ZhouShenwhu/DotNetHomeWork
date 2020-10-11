using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class Urlstatus
    {
        public string url { get; set; }
        public string status { get; set; }
        public string reason { get; set; }
        public bool isTry;
        public Urlstatus(string url)
        {
            this.url = url;
            status = "success";
            isTry = false;
            reason = "accessed";//初始化url都认为是可行的
        }
        public void SetStatus()
        {
            isTry = true;
        }

        public override bool Equals(object obj)
        {
            return obj is Urlstatus urlstatus &&
                   url == urlstatus.url;
        }

        public override int GetHashCode()
        {
            return 1227826894 + EqualityComparer<string>.Default.GetHashCode(url);
        }
    }
}
