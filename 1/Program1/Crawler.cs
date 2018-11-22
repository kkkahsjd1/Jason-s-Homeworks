using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections;

namespace homework9
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            var myCrawler = new Crawler();

            var startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];

            myCrawler.urls.Add(startUrl, false); //加入初始页面

            new Thread(myCrawler.Crawl).Start(); //开始爬行

            Console.ReadKey();

        }
        private void Crawl()
        {
            Console.WriteLine("开始爬行了....");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)//找到没下载过的链接
                {
                    if ((bool)urls[url]) continue;//已下载过的不再下载
                    current = url;
                }
                if (current == null || count > 10) break;

                Console.WriteLine("爬行" + current + "页面！");

                string html = DownLoad(current);//下载

                urls[current] = true;
                count++;

                Parse(html);

            }
            Console.WriteLine("爬行结束");
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');

                    if (strRef.Length == 0) continue;

                if (urls[strRef] == null) urls[strRef] = false;
            }


        }
    }
}
