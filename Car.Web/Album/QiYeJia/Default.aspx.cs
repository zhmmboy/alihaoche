using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//项目DLL
using Car.BLL;
using Car.Common;

namespace Car.Web.Album.QiYeJia
{
    public partial class Default : System.Web.UI.Page
    {
        public string pageStr = string.Empty;
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
            AlbumBLL _AlbumBLL = new AlbumBLL();

            //页码
            int pageIndex = Convert.ToInt32(this.Request.QueryString["pageIndex"] != null && this.Request.QueryString["pageIndex"] != "" ? this.Request.QueryString["pageIndex"] : "1");
            //关键词 标签
            string tag = this.Request.QueryString["tag"];
            //一周热门,一月热门
            string type = this.Request.QueryString["type"];
            //查询条件
            string where = "1=1";
            string sort = "aAddTime";
            string group = string.Empty;

            //判断是否有关键词
            if (!string.IsNullOrEmpty(tag))
            {
                where += " AND aTags like '%" + PageValidateHelper.Filter(tag) + "%'";
            }
            //判断查询类型
            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "week": where += " AND aAddTime>DATEADD(day,-10,GETDATE())"; sort = "aClicks"; break;
                    case "month": where += " AND aAddTime>DATEADD(day,-30,GETDATE())"; sort = "aClicks"; break;
                }
            }

            //正文
            int totalCount = 0;
            DataTable dt = _AlbumBLL.GetPaging(where,sort,group, 16, pageIndex, out totalCount);

            this.rptData.DataSource = dt;
            this.rptData.DataBind();

            if (totalCount > 0)
            {
                decimal pageCount = Math.Ceiling(Convert.ToDecimal(totalCount) / 16);
                if (pageCount > 1)
                {
                    if (pageIndex == 1)
                    {
                        pageStr = "<li class=\"prev-page\"><a>上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/album/page" + (pageIndex + 1) + ".html\">下一页</a></li>";
                    }
                    else if (pageIndex == 2)
                    {
                        if (pageIndex == pageCount)
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/album\">上一页</a></li><li class=\"prev-page\"><a>下一页</a></li>";
                        }
                        else
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/album\">上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/album/page" + (pageIndex + 1) + ".html\">下一页</a></li>";
                        }
                    }
                    else
                    {
                        if (pageIndex == pageCount)
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/album\">上一页</a></li><li class=\"prev-page\"><a>下一页</a></li>";
                        }
                        else
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/album/page" + (pageIndex - 1) + ".html\">上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/album/page" + (pageIndex + 1) + ".html\">下一页</a></li>";
                        }
                    }
                }
            }

            //7天热门
            //DataTable dtHot = new DataTable();
            //dtHot = _personBLL.GetBaseList(6, "classId='98d62719-bf35-4562-8301-731e4f91c19e' AND pAddTime>DATEADD(day,-10,GETDATE()) order by pClicks desc", true, "gongwuyuan_default_hot_" + pageIndex, 2);
            //this.rptHot.DataSource = dtHot;
            //this.rptHot.DataBind();

            ////标签
            //DataTable dtTag = new DataTable();

            //dtTag = new TagsBLL().GetList(10, "classId='98d62719-bf35-4562-8301-731e4f91c19e' order by tAddTime desc", false, "", 0);
            //this.rptTag.DataSource = dtTag;
            //this.rptTag.DataBind();

            ////推荐
            //DataTable dtRecommend = new DataTable();
            //dtRecommend = new BLL.NewsBLL().GetBaseList(6, "nTime>DATEADD(day,-30,GETDATE()) and nIsRecommand=1 order by nClicks desc", false, "", 0);
            //this.rptRecommend.DataSource = dtRecommend;
            //this.rptRecommend.DataBind();
        }
    }
}