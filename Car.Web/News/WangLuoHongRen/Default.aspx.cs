using Car.BLL;
using Car.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.News.WangLuoHongRen
{
    public partial class Default : System.Web.UI.Page
    {
        public string pageStr = string.Empty;
        public int totalCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //生成静态页面
                LoadData();
            }
        }

        /// <summary>
        /// 生成静态页面
        /// </summary>
        private void LoadData()
        {
            PersonBLL _personBLL = new PersonBLL();
            NewsBLL _NewsBLL = new NewsBLL();

            //页码
            int pageIndex = Convert.ToInt32(this.Request.QueryString["pageIndex"] != null && this.Request.QueryString["pageIndex"] != "" ? this.Request.QueryString["pageIndex"] : "1");
            //关键词 标签
            string tag = this.Request.QueryString["tag"];
            //查询条件
            string where = "nclass1='" + SystemVar.ClassId_WangLuoHongRen + "'";
            //判断是否有关键词
            if (!string.IsNullOrEmpty(tag))
            {
                where += " AND nTags like '%" + PageValidateHelper.Filter(tag) + "%'";
            }

            //正文
            DataTable dt = _NewsBLL.GetPaging(where, "nTime", "", 10, pageIndex, out totalCount);

            this.rptData.DataSource = dt;
            this.rptData.DataBind();

            if (totalCount > 0)
            {
                decimal pageCount = Math.Ceiling(Convert.ToDecimal(totalCount) / 10);
                if (pageCount > 1)
                {
                    if (pageIndex == 1)
                    {
                        pageStr = "<li class=\"prev-page\"><a>上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/wangluohongren/page" + (pageIndex + 1) + ".html\">下一页</a></li>";
                    }
                    else if (pageIndex == 2)
                    {
                        if (pageIndex == pageCount)
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/wangluohongren\">上一页</a></li><li class=\"prev-page\"><a>下一页</a></li>";
                        }
                        else
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/wangluohongren\">上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/wangluohongren/page" + (pageIndex + 1) + ".html\">下一页</a></li>";
                        }
                    }
                    else
                    {
                        if (pageIndex == pageCount)
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/wangluohongren\">上一页</a></li><li class=\"prev-page\"><a>下一页</a></li>";
                        }
                        else
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/wangluohongren/page" + (pageIndex - 1) + ".html\">上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/wangluohongren/page" + (pageIndex + 1) + ".html\">下一页</a></li>";
                        }
                    }
                }
            }

            //7天热门
            DataTable dtHot = new DataTable();
            dtHot = _NewsBLL.GetBaseList(6, "nclass1='" + SystemVar.ClassId_WangLuoHongRen + "' AND nTime>DATEADD(day,-10,GETDATE()) order by nClicks desc", true, "news_wangluohongren_default_hot", 2);
            this.rptHot.DataSource = dtHot;
            this.rptHot.DataBind();

            //标签
            DataTable dtTag = new DataTable();
            dtTag = new TagsBLL().GetList(10, "classId='" + SystemVar.ClassId_WangLuoHongRen + "'  AND TType=2 AND tAddTime>DATEADD(day,-30,GETDATE()) order by tAddTime desc", true, "news_wangluohongren_tag", 0);
            this.rptTag.DataSource = dtTag;
            this.rptTag.DataBind();

            //推荐
            DataTable dtRecommend = new DataTable();
            dtRecommend = _personBLL.GetBaseList(6, "classId='" + SystemVar.ClassId_WangLuoHongRen + "' AND pAddTime>DATEADD(day,-30,GETDATE()) order by pClicks desc", true, "news_wangluohongren_recommand", 120);
            this.rptRecommend.DataSource = dtRecommend;
            this.rptRecommend.DataBind();
        }
    }
}