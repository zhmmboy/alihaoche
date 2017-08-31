using Car.Common;
using Car.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Car.Spider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.TextBox1.Text = "http://www.toutiao.com/ch/car_new_arrival/";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //设置路径
            this.webBrowser1.Navigate(this.TextBox1.Text);
            this.webBrowser1.ScrollBarsEnabled = true;

            //开始定时器
            this.timer1.Start();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(Do));
            t1.Start();
            
            this.TextBox2.Text = this.webBrowser1.Document.Body.OuterHtml;
        }

        private void Do()
        {
            FindLink(this.TextBox2.Text);
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.TextBox1.Text = this.webBrowser1.Document.Body.OuterHtml;
        }

        private string getHTMLbyWebRequest(string strUrl)
        {
            string content = string.Empty;

            Encoding encoding = System.Text.Encoding.Default;
            WebRequest request = WebRequest.Create(strUrl);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusDescription.ToUpper() == "OK")
            {
                switch (response.CharacterSet.ToLower())
                {
                    case "gbk":
                        encoding = Encoding.GetEncoding("GBK");//貌似用GB2312就可以
                        break;
                    case "gb2312":
                        encoding = Encoding.GetEncoding("GB2312");
                        break;
                    case "utf-8":
                        encoding = Encoding.UTF8;
                        break;
                    case "big5":
                        encoding = Encoding.GetEncoding("Big5");
                        break;
                    case "iso-8859-1":
                        encoding = Encoding.UTF8;//ISO-8859-1的编码用UTF-8处理，致少优酷的是这种方法没有乱码
                        break;
                    default:
                        encoding = Encoding.UTF8;//如果分析不出来就用的UTF-8
                        break;
                }
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream, encoding);
                content = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();
            }
            else
            {
                //this.TextBox2.Text = "Error";
            }
            return content;
        }

        private void FindLink(string html)
        {
            //this.TextBox3.Text = "";
            List<string> hrefList = new List<string>();//链接
            List<string> nameList = new List<string>();//链接名称
            List<string> contentList = new List<string>();//链接名称

            string pattern = @"<a\s*class=(""|')link\s*title("" | ')\s*href=(""|')(?<href>[\s\S.]*?)(""|').*?>\s*(?<name>[\s\S.]*?)</a>";
            MatchCollection mc = Regex.Matches(html, pattern);
            foreach (Match m in mc)
            {
                if (m.Success)
                {
                    //加入集合数组
                    string href = m.Groups["href"].Value;
                    if (m.Groups["href"].Value.IndexOf("toutiao.com") < 0)
                    {
                        href = "http://www.toutiao.com/" + href;
                    }

                    hrefList.Add(href);
                    nameList.Add(m.Groups["name"].Value);
                }
            }
            int total = 0;
            for (int i = 0; i < hrefList.Count; i++)
            {
                //获取详情页内容
                string content = getHTMLbyWebRequest(hrefList[i]);
                contentList.Add(content);

                //提取内容
                pattern = @"<a\s*class=(""|')link\s*title("" | ')\s*href=(""|')(?<href>[\s\S.]*?)(""|').*?>\s*(?<name>[\s\S.]*?)</a>";
                string pattern2 = @"<div\s*class=(""|')article-content(""|')>\s*(?<content>[\s\S.]*?)</div>";
                MatchCollection mc2 = Regex.Matches(content, pattern2);
                foreach (Match m in mc2)
                {
                    if (m.Success)
                    {
                        WebClient wc = new WebClient();
                        string nContent = m.Groups["content"].Value;
                        string[] arrImg = FileHelper.GetImgTag(nContent);
                        string titlePic = string.Empty;

                        //新的图片存储路径
                        string[] arrImgNew = new string[arrImg.Length];

                        foreach (string img in arrImg)
                        {
                            //string serverUrl = "http://192.168.1.248:808/UpFile/News/1.jpg";
                            string localUrl = Application.StartupPath + "\\" + Guid.NewGuid().ToString() + ".jpg";
                            //将图片下载到本地
                            string dic = "D:/Car/Img/" + DateTime.Now.ToString("yyyyMMdd");
                            //创建目录
                            FileHelper.CreateDir(dic);
                            //文件后缀                           
                            string fileName = dic + "/" + Guid.NewGuid().ToString() + ".jpg";

                            wc.DownloadFile(img, fileName);
                            wc.UploadFile("http://www.alihaoche.com/handler/UpFile.ashx", fileName);

                            //新的图片路径
                            string newImg = fileName.Replace("D:/Car/Img/", "/UpFile/News/");
                            nContent = nContent.Replace(img, newImg);
                            if (string.IsNullOrEmpty(titlePic))
                            {
                                titlePic = newImg;
                            }
                        }

                        C_News _P_News = new C_News();
                        _P_News.nTitle = nameList[i];
                        _P_News.nTitleSeo = nameList[i];
                        _P_News.nTips = nameList[i];
                        _P_News.nTitlepic = titlePic;
                        _P_News.nAuthor = "阿里好车";
                        _P_News.nForm = "阿里好车 ";
                        _P_News.nFormurl = "www.alihaoche.com";
                        _P_News.nclass1 = 1;
                        _P_News.nClass2 = 0;
                        _P_News.carId = 0;
                        _P_News.nIsRecommand = false;
                        _P_News.nLevel = 0;
                        _P_News.nContent = nContent;
                        _P_News.nTags = string.Empty;
                        _P_News.nIsPage = false;
                        _P_News.nStatus = 0;
                        _P_News.uId = 0;
                        _P_News.nClicks = 0;
                        _P_News.nTalks = 0;
                        _P_News.nGood = 0;
                        _P_News.nBad = 0;
                        _P_News.nIndex = 0;
                        _P_News.nLinkurl = string.Empty;

                        var msg = new BLL.NewsBLL().AddNewsTemp(_P_News);
                        total += 1;
                    }
                }
            }

            MessageBox.Show("此次一共成功提取 " + total + " 条记录！");
        }

        public string ClearHtml(string text)//过滤html,js,css代码
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            text = Regex.Replace(text, "<head[^>]*>(?:.|[\r\n])*?</head>", "");
            text = Regex.Replace(text, "<script[^>]*>(?:.|[\r\n])*?</script>", "");
            text = Regex.Replace(text, "<style[^>]*>(?:.|[\r\n])*?</style>", "");

            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", ""); //<br> 
            text = Regex.Replace(text, "\\&[a-zA-Z]{1,10};", "");
            text = Regex.Replace(text, "<[^>]*>", "");

            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", ""); //&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty); //其它任何标记
            text = Regex.Replace(text, "[\\s]{2,}", " "); //两个或多个空格替换为一个

            text = text.Replace("'", "''");
            text = text.Replace("\r\n", "");
            text = text.Replace("  ", "");
            text = text.Replace("\t", "");
            return text.Trim();
        }

        private void IPAddresses(string url)
        {
            url = url.Substring(url.IndexOf("//") + 2);
            if (url.IndexOf("/") != -1)
            {
                url = url.Remove(url.IndexOf("/"));
            }
            this.Literal1.Text += "<br>" + url;
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
                IPHostEntry ipHostEntry = Dns.GetHostEntry(url);
                System.Net.IPAddress[] ipaddress = ipHostEntry.AddressList;
                foreach (IPAddress item in ipaddress)
                {
                    this.Literal1.Text += "<br>IP:" + item;
                }
            }
            catch { }
        }

        public static int height = 500;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.webBrowser1.Document.Window.ScrollTo(0, height);
            height += 500;
        }
    }
}
