using Car.BLL;
using System;
using System.Data;

namespace Car.Web.Question
{
    public partial class List : System.Web.UI.Page
    {
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
            NewsBLL _newBll = new NewsBLL();

            Guid nclassId = new Guid(this.Request.QueryString["id"]);
            DataTable dtNews =CommonUtility.GetBaseListByCache(10, "nclass1='" + nclassId + "' order by ntime desc", "List_" + nclassId);
            this.rptData.DataSource = dtNews;
            this.rptData.DataBind();

            //7天热门
            DataTable dtHot = new DataTable();
            dtHot = CommonUtility.GetBaseListByCache(6, "nTime>DATEADD(day,-10,GETDATE()) order by nClicks desc", "List_" + nclassId + "_Hot");
            this.rptHot.DataSource = dtHot;
            this.rptHot.DataBind();

            //标签
            DataTable dtTag = new DataTable();
            dtTag = CommonUtility.GetDataByCache("select top 10 tId,tTitle from vw_Tags order by tAddTime desc", "default_tag");
            this.rptTag.DataSource = dtTag;
            this.rptTag.DataBind();

            //推荐
            DataTable dtRecommend = new DataTable();
            dtRecommend = CommonUtility.GetBaseListByCache(6, "nTime>DATEADD(day,-30,GETDATE()) and nIsRecommand=1 order by nClicks desc", "List_" + nclassId + "_Recommend");
            this.rptRecommend.DataSource = dtRecommend;
            this.rptRecommend.DataBind();
        }
    }
}