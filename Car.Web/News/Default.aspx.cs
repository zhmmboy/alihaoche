using Car.BLL;
using Car.Common;
using Car.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.News
{
    public partial class Default : System.Web.UI.Page
    {
        public string pageStr = string.Empty; 
        public int totalCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            //页码
            int pageIndex = Convert.ToInt32(this.Request.QueryString["pageIndex"] != null && this.Request.QueryString["pageIndex"] != "" ? this.Request.QueryString["pageIndex"] : "1");
            //关键词 标签
            string tag = this.Request.QueryString["tag"];
            //一周热门,一月热门
            string type = this.Request.QueryString["type"];
            //查询条件
            string where = "1=1";
            string sort = "nAddTime";
            //判断是否有关键词
            if (!string.IsNullOrEmpty(tag))
            {
                where += " AND nTags like '%" + PageValidateHelper.Filter(tag) + "%'";
            }
            //判断查询类型
            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "week": where += " AND nAddTime>DATEADD(day,-10,GETDATE()) "; sort = "nClicks"; break;
                    case "month": where += " AND nAddTime>DATEADD(day,-30,GETDATE()) "; sort = "nClicks"; break;
                    case "zan": where += " AND nAddTime>DATEADD(day,-90,GETDATE()) "; sort = "nGood"; break;
                }
            }

            //正文
            DataTable dt = new NewsBLL().GetPaging(where,sort,"",20, pageIndex, out totalCount);
            //绑定数据
            this.rptData.DataSource = dt;
            this.rptData.DataBind();

            if (totalCount > 0)
            {
                decimal pageCount = Math.Ceiling(Convert.ToDecimal(totalCount) / 20);
                if (pageCount > 1)
                {
                    if (pageIndex == 1)
                    {
                        pageStr = "<li class=\"prev-page\"><a>上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/page" + (pageIndex + 1) + "\">下一页</a></li>";
                    }
                    else if (pageIndex == 2)
                    {
                        if (pageIndex == pageCount)
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/news\">上一页</a></li><li class=\"prev-page\"><a>下一页</a></li>";
                        }
                        else
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/news\">上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/page" + (pageIndex + 1) + "\">下一页</a></li>";
                        }
                    }
                    else
                    {
                        if (pageIndex == pageCount)
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/news\">上一页</a></li><li class=\"prev-page\"><a>下一页</a></li>";
                        }
                        else
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/page" + (pageIndex - 1) + "\">上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/page" + (pageIndex + 1) + "\">下一页</a></li>";
                        }
                    }
                }
               
            }

            string nclassId = "";

            //7天热门
            DataTable dtHot = new DataTable();
            dtHot = CommonUtility.GetBaseListByCache(10, "nAddTime>DATEADD(day,-10,GETDATE()) order by nClicks desc", "news_default_hot");
            this.rptHot.DataSource = dtHot;
            this.rptHot.DataBind();

            //标签
            DataTable dtTag = new DataTable();
            dtTag = new TagsBLL().GetList(20, "  TType=2 AND tAddTime>DATEADD(day,-30,GETDATE()) order by tAddTime desc", true, "news_default_tag", 0);
            this.rptTag.DataSource = dtTag;
            this.rptTag.DataBind();

            //推荐
            DataTable dtRecommend = new DataTable();
            dtRecommend = CommonUtility.GetBaseListByCache(10, "nAddTime>DATEADD(day,-90,GETDATE()) and nIsRecommand=1 order by nClicks desc", "news_default_Recommend");
            this.rptRecommend.DataSource = dtRecommend;
            this.rptRecommend.DataBind();
        }
    }
}