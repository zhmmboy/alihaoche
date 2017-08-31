using Car.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.Blog
{
        public partial class Default : System.Web.UI.Page
        {
            public string pageStr = string.Empty;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    //生成静态页面
                    CreatePage();
                }
            }

            /// <summary>
            /// 生成静态页面
            /// </summary>
            private void CreatePage()
            {
                int pageIndex = Convert.ToInt32(this.Request.QueryString["pageIndex"] != null && this.Request.QueryString["pageIndex"] != "" ? this.Request.QueryString["pageIndex"] : "1");

                PersonBLL _personBLL = new PersonBLL();

                //正文
                int totalCount = 0;
                DataTable dt = _personBLL.GetPaging("classId='98d62719-bf35-4562-8301-731e4f91c19e'", 10, pageIndex, out totalCount);

                this.rptData.DataSource = dt;
                this.rptData.DataBind();

                if (totalCount > 0)
                {
                    if (pageIndex >= 1 && pageIndex < Math.Ceiling(Convert.ToDecimal(totalCount) / 10))
                    {
                        pageStr = "<li class=\"prev-page\"><a>上一页</a></li><li class=\"next-page\"><a href=\"http://juyoo.w222.mc-test.com/page/" + (pageIndex + 1) + ".html\">下一页</a></li>";
                    }
                    else if (pageIndex == totalCount / 10)
                    {
                        pageStr = "<li class=\"prev-page\"><a href=\"http://juyoo.w222.mc-test.com/page/" + (pageIndex - 1) + ".html\">上一页</a></li><li class=\"next-page\"><a>下一页</a></li>";
                    }
                }

                //7天热门
                DataTable dtHot = new DataTable();
                dtHot = _personBLL.GetBaseList(6, "classId='98d62719-bf35-4562-8301-731e4f91c19e' AND pAddTime>DATEADD(day,-10,GETDATE()) order by pClicks desc", true, "gongwuyuan_default_hot_" + pageIndex, 2);
                this.rptHot.DataSource = dtHot;
                this.rptHot.DataBind();

                //标签
                DataTable dtTag = new DataTable();

                dtTag = new TagsBLL().GetList(10, "classId='98d62719-bf35-4562-8301-731e4f91c19e' order by tAddTime desc", false, "", 0);
                this.rptTag.DataSource = dtTag;
                this.rptTag.DataBind();

                //推荐
                DataTable dtRecommend = new DataTable();
                dtRecommend = new BLL.NewsBLL().GetBaseList(6, "nTime>DATEADD(day,-30,GETDATE()) and nIsRecommand=1 order by nClicks desc", false, "", 0);
                this.rptRecommend.DataSource = dtRecommend;
                this.rptRecommend.DataBind();
            }
        }
}