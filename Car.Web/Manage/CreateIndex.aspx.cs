using Car.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.Manage
{
    public partial class CreateIndex : BasePage
    {
        public string pageStr = string.Empty;
        public int totalCount = 0;

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
            NewsBLL _newsBLL = new NewsBLL();

            //正文
            DataTable dt = _newsBLL.GetPaging("1=1", "nAddTime DESC","",20, 1, out totalCount);

            this.rptData.DataSource = dt;
            this.rptData.DataBind();

            pageStr = "<li class=\"prev-page\"><a>上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/page" + (pageIndex + 1) + "\">下一页</a></li>";

            //7天热门
            DataTable dtHot = new DataTable();
            dtHot = _newsBLL.GetBaseList(10, "nAddTime>DATEADD(day,-10,GETDATE()) order by nClicks desc", false, "", 0);
            this.rptHot.DataSource = dtHot;
            this.rptHot.DataBind();

            //标签
            DataTable dtTag = new DataTable();
            dtTag = new TagsBLL().GetList(40, "1=1 order by tAddTime desc", false, "", 0);
            this.rptTag.DataSource = dtTag;
            this.rptTag.DataBind();

            //推荐
            DataTable dtRecommend = new DataTable();
            dtRecommend = new BLL.NewsBLL().GetBaseList(10, "nAddTime>DATEADD(day,-30,GETDATE()) and nIsRecommand=1 order by nClicks desc", false, "", 0);
            this.rptRecommend.DataSource = dtRecommend;
            this.rptRecommend.DataBind();

            #region 生成静态首页

            //写入静态文件
            StringWriter stringW = new StringWriter();
            HtmlTextWriter htmltw = new HtmlTextWriter(stringW);
            Page.RenderControl(htmltw);
            StreamWriter streamw = new StreamWriter(Server.MapPath("../index.html"), false, Encoding.UTF8);
            streamw.WriteLine(stringW.ToString());
            streamw.Dispose();
            streamw.Close();
            this.Response.Redirect("../index.html");
            #endregion
        }
    }
}