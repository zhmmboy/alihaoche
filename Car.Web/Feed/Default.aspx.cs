using System;
using System.Data;
using System.Text;
using System.IO;
using Car.BLL;

namespace Car.Web.Feed
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //2011.10.1 今天看到了网站的第一个注册用户，很兴奋
                //网站订阅功能

                StringBuilder _strBuf = new StringBuilder();
                _strBuf.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                _strBuf.Append("<rss version=\"2.0\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\" xmlns:trackback=\"http://madskills.com/public/xml/rss/module/trackback/\" xmlns:wfw=\"http://wellformedweb.org/CommentAPI/\" xmlns:slash=\"http://purl.org/rss/1.0/modules/slash/\" xmlns:atom=\"http://www.w3.org/2005/Atom\">");
                _strBuf.Append("<channel>");
                _strBuf.Append("<title><![CDATA[阿里好车]]></title>");
                _strBuf.Append("<link>http://www.alihaoche.com</link>");
                _strBuf.Append("<description><![CDATA[阿里好车 - 一个专业分享汽车资讯的网站，一个分享买车心得、用车经验的网站！]]></description>");
                _strBuf.Append("<language>zh-cn</language>");
                _strBuf.Append("<copyright><![CDATA[Copyright 2015-2025 www.alihaoche.com]]></copyright>");
                _strBuf.Append("<webMaster><![CDATA[mingrenku@yeah.net (阿里好车)]]></webMaster>");
                _strBuf.Append("<generator>www.alihaoche.com</generator> ");
                _strBuf.Append("<image>");
                _strBuf.Append("<title>阿里好车</title> ");
                _strBuf.Append("<url>http://www.alihaoche.com/res/image/logo.jpg</url> ");
                _strBuf.Append("<link>http://www.alihaoche.com</link> ");
                _strBuf.Append("<description>阿里好车</description> ");
                _strBuf.Append("</image>");

                PersonBLL _PersonBLL = new PersonBLL();
                DataTable _dtRss = _PersonBLL.GetDataBySql("SELECT TOP 50 pId,pCnName,pEnName,pAddTime,pIntroduce,cName,cEnName FROM v_GetPersonList ORDER BY pIndex Desc");

                if (_dtRss != null)
                {
                    //for (int i = 0; i < _dtRss.Rows.Count; i++)
                    //{
                    //    _strBuf.Append("<item>");
                    //    _strBuf.Append("<title>" + _dtRss.Rows[i]["pCnName"].ToString() + "</title>");
                    //    _strBuf.Append("<author>mingrenku@yeah.net ( 阿里好车 )</author>");
                    //    _strBuf.Append("<category><![CDATA[" + _dtRss.Rows[i]["CName"] + "·资料·档案]]></category>");
                    //    _strBuf.Append("<link><![CDATA[http://www.alihaoche.com/person/" + _dtRss.Rows[i]["pid"] + ".html]]></link>");
                    //    _strBuf.Append("<guid><![CDATA[http://www.alihaoche.com/person/" + _dtRss.Rows[i]["pid"] + ".html]]></guid>");
                    //    _strBuf.Append("<description><![CDATA[" + _dtRss.Rows[i]["pIntroduce"].ToString().Replace("|page|", "") + "<p>本文原始链接：<a href=\"http://www.alihaoche.com/person/" + _dtRss.Rows[i]["pid"] + ".html\" target=\"_blank\">http://www.alihaoche.com/person/" + _dtRss.Rows[i]["pid"] + ".html</a></p>");
                    //    _strBuf.Append("<p>欢迎大家访问：<a href=\"http://www.alihaoche.com\" target=\"_blank\"><strong>阿里好车 www.alihaoche.com - 一个分享企业家、明星、社会名人、网络红人、草根达人、模特、校花资料的网站！</strong></a></p><p>&nbsp;</p>]]></description>");
                    //    _strBuf.Append("</item>");
                    //}
                }

                //资讯
                NewsBLL _NewsBLL = new NewsBLL();
                _dtRss = _NewsBLL.GetDataBySql("SELECT TOP 50 nid,ntitle,nauthor,ncontent,cbName,cbEnName FROM v_Car_GetNews ORDER BY nIndex Desc");

                if (_dtRss != null)
                {
                    for (int i = 0; i < _dtRss.Rows.Count; i++)
                    {
                        _strBuf.Append("<item>");
                        _strBuf.Append("<title>" + _dtRss.Rows[i]["ntitle"].ToString() + "</title>");
                        _strBuf.Append("<author>mingrenku@yeah.net ( 阿里好车 )</author>");
                        _strBuf.Append("<category><![CDATA[" + _dtRss.Rows[i]["cbName"] + "·热点·资讯]]></category>");
                        _strBuf.Append("<link><![CDATA[http://www.alihaoche.com/news/" + _dtRss.Rows[i]["nid"] + "]]></link>");
                        _strBuf.Append("<guid><![CDATA[http://www.alihaoche.com/news/" + _dtRss.Rows[i]["nid"] + "]]></guid>");
                        _strBuf.Append("<description><![CDATA[" + _dtRss.Rows[i]["ncontent"].ToString().Replace("|page|", "") + "<p>本文原始链接：<a href=\"http://www.alihaoche.com/news/" + _dtRss.Rows[i]["nid"] + "\" target=\"_blank\">http://www.alihaoche.com/news/" + _dtRss.Rows[i]["nid"] + "</a></p>");
                        _strBuf.Append("<p>欢迎大家访问：<a href=\"http://www.alihaoche.com\" target=\"_blank\"><strong>阿里好车 www.alihaoche.com - 一个专业分享汽车资讯的网站，一个分享买车心得、用车经验的网站！</strong></a></p><p>&nbsp;</p>]]></description>");
                        _strBuf.Append("</item>");
                    }
                }

                //资讯
                QuestionBLL _QuestionBLL = new QuestionBLL();
                _dtRss = _QuestionBLL.GetDataBySql("SELECT TOP 50 qid,qtitle,qasker,qIntro,cName,cEnName FROM v_GetQuestionList ORDER BY qIndex Desc");

                if (_dtRss != null)
                {
                    //for (int i = 0; i < _dtRss.Rows.Count; i++)
                    //{
                    //    _strBuf.Append("<item>");
                    //    _strBuf.Append("<title>" + _dtRss.Rows[i]["qtitle"].ToString() + "</title>");
                    //    _strBuf.Append("<author>mingrenku@yeah.net ( 阿里好车 )</author>");
                    //    _strBuf.Append("<category><![CDATA[" + _dtRss.Rows[i]["cName"] + "·互动·问答]]></category>");
                    //    _strBuf.Append("<link><![CDATA[http://www.alihaoche.com/question/" + _dtRss.Rows[i]["qid"] + ".html]]></link>");
                    //    _strBuf.Append("<guid><![CDATA[http://www.alihaoche.com/question/" + _dtRss.Rows[i]["qid"] + ".html]]></guid>");
                    //    _strBuf.Append("<description><![CDATA[" + _dtRss.Rows[i]["qIntro"].ToString().Replace("|page|", "") + "<p>本文原始链接：<a href=\"http://www.alihaoche.com/question/" + _dtRss.Rows[i]["qid"] + ".html\" target=\"_blank\">http://www.alihaoche.com/question/" + _dtRss.Rows[i]["qid"] + ".html</a></p>");
                    //    _strBuf.Append("<p>欢迎大家访问：<a href=\"http://www.alihaoche.com\" target=\"_blank\"><strong>阿里好车 www.alihaoche.com - 一个分享企业家、明星、社会名人、网络红人、草根达人、模特、校花资料的网站！</strong></a></p><p>&nbsp;</p>]]></description>");
                    //    _strBuf.Append("</item>");
                    //}
                }

                _strBuf.Append("</channel>");
                _strBuf.Append("</rss>");

                #region 生成RSS页

                //写入静态文件
                StringWriter stringW = new StringWriter();
                //HtmlTextWriter htmltw = new HtmlTextWriter(stringW);
                //Page.RenderControl(htmltw);
                StreamWriter streamw = new StreamWriter(Server.MapPath("Default.xml"), false, Encoding.UTF8);
                streamw.WriteLine(_strBuf.ToString());
                streamw.Dispose();
                streamw.Close();
                this.Response.Redirect("Default.xml",true);
                #endregion
            }
        }
    }
}
