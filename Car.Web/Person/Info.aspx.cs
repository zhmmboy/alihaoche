using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Car.BLL;
using Car.Entity;
using Car.Web;

namespace Car.Web.Person
{
    public partial class Info : System.Web.UI.Page
    {
        public string TitleStr = string.Empty;
        public string KeyStr = string.Empty;
        public string DescStr = string.Empty;
        public string ContentStr = string.Empty;
        public string PrevNextArticleStr = string.Empty;               //上一篇/下一篇
        public string NextForRightStr = string.Empty;               //最右侧导航/下一页
        public string TagsStr = string.Empty;
        public string TotalZan = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadData()
        {
            PersonBLL _personBLL = new PersonBLL();

            Guid pId = new Guid(this.Request.QueryString["Id"]);
            DataTable dt = _personBLL.GetPersonById(pId);

            string ClassId = string.Empty;      //资讯分类
            int OrderIndex = 0;                 //资讯在表中的索引

            //如果有数据
            if (dt != null)
            {
                TitleStr = dt.Rows[0]["pCnName"].ToString() + (dt.Rows[0]["pJob"].ToString().Trim()!=""?"（" + dt.Rows[0]["pJob"].ToString() + "）":"");
                KeyStr = dt.Rows[0]["pTags"].ToString();
                DescStr = dt.Rows[0]["pTips"].ToString();
                ContentStr = dt.Rows[0]["pIntroduce"].ToString();
                ClassId = dt.Rows[0]["classId"].ToString();
                OrderIndex = Convert.ToInt32(dt.Rows[0]["pIndex"]);
                TotalZan = dt.Rows[0]["pFans"].ToString();
                string cEnName = dt.Rows[0]["cEnName"].ToString();

                //获取该资讯的上一篇/下一篇文章记录
                DataTable dtPrevNext = _personBLL.GetList(2, "pId,pIndex,pCnName,pEnName,pJob,cName,cEnName", "pIndex in(" + (OrderIndex - 1) + "," + (OrderIndex + 1) + ") order by pIndex");

                //说明只有一篇文章
                if (dtPrevNext != null)
                {
                    if (dtPrevNext.Rows.Count == 1)
                    {
                        int currentOrderIndex = Convert.ToInt32(dtPrevNext.Rows[0]["pIndex"]);
                        //显示下一篇
                        if (currentOrderIndex > OrderIndex)
                        {
                            PrevNextArticleStr = "<span class=\"article-nav-prev\">上一篇<br>这是第一篇文章，没有上一篇！</span>"
                                        + "<span class=\"article-nav-next\">下一篇<br>"
                                        + "<a href=\"http://www.alihaoche.com/person/" + dtPrevNext.Rows[0]["cEnName"].ToString() + "/" + dtPrevNext.Rows[0]["pId"].ToString() + ".html\" rel=\"next\">" + dtPrevNext.Rows[0]["pCnName"].ToString() + ":" + dtPrevNext.Rows[0]["pJob"].ToString() + "</a></span>";

                            NextForRightStr = "<a class=\"pagebar pagebar-next\" title=\"\" href=\"http://www.alihaoche.com/person/" + dtPrevNext.Rows[0]["cEnName"].ToString() + "/" + dtPrevNext.Rows[0]["pId"].ToString() + ".html\" data-original-title=\"下一篇：&lt;br&gt;" + dtPrevNext.Rows[0]["pCnName"].ToString() + ":" + dtPrevNext.Rows[0]["pJob"].ToString() + "\"><span class=\"glyphicon glyphicon-chevron-right\"></span><i class=\"glyphicon glyphicon-chevron-right\"></i></a>";
                        }
                        else
                        {
                            //显示上一篇
                            PrevNextArticleStr = "<span class=\"article-nav-prev\">上一篇<br>"
                                        + "<a href=\"http://www.alihaoche.com/person/" + dtPrevNext.Rows[0]["cEnName"].ToString() + "/" + dtPrevNext.Rows[0]["pId"].ToString() + ".html\" rel=\"prev\">" + dtPrevNext.Rows[0]["pCnName"].ToString() + ":" + dtPrevNext.Rows[0]["pJob"].ToString() + "</a></span>"
                                        + "<span class=\"article-nav-next\">下一篇<br>这是最后一篇文章，没有下一篇！";
                        }
                    }
                    else if (dtPrevNext.Rows.Count == 2)
                    {
                        PrevNextArticleStr = "<span class=\"article-nav-prev\">上一篇<br>"
                                         + "<a href=\"http://www.alihaoche.com/person/" + dtPrevNext.Rows[0]["cEnName"].ToString() + "/" + dtPrevNext.Rows[0]["pId"].ToString() + ".html\" rel=\"prev\">" + dtPrevNext.Rows[0]["pCnName"].ToString() + ":" + dtPrevNext.Rows[0]["pJob"].ToString() + "</a></span>"
                                         + "<span class=\"article-nav-next\">下一篇<br>"
                                         + "<a href=\"http://www.alihaoche.com/person/" + dtPrevNext.Rows[1]["cEnName"].ToString() + "/" + dtPrevNext.Rows[1]["pId"].ToString() + ".html\" rel=\"next\">" + dtPrevNext.Rows[1]["pCnName"].ToString() + ":" + dtPrevNext.Rows[1]["pJob"].ToString() + "</a></span>";

                        NextForRightStr = "<a class=\"pagebar pagebar-next\" title=\"\" href=\"http://www.alihaoche.com/person/" + dtPrevNext.Rows[1]["cEnName"].ToString() + "/" + dtPrevNext.Rows[1]["pId"].ToString() + ".html\" data-original-title=\"下一篇：&lt;br&gt;" + dtPrevNext.Rows[1]["pCnName"].ToString() + ":" + dtPrevNext.Rows[1]["pJob"].ToString() + "\"><span class=\"glyphicon glyphicon-chevron-right\"></span><i class=\"glyphicon glyphicon-chevron-right\"></i></a>";

                    }
                }
                //标签
                string[] tags = dt.Rows[0]["pTags"].ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (tags.Length > 0)
                {
                    for (int i = 0; i < tags.Length; i++)
                        TagsStr += "<a target=\"_blank\" href=\"http://www.alihaoche.com/tag/" + Server.UrlEncode(tags[i]) + "\" title=\"“" + tags[i] + "”相关文章\">" + tags[i] + "</a>";
                }
            }

            this.rptData.DataSource = dt;
            this.rptData.DataBind();

            _personBLL.Clicks(pId);

            //7天热门
            DataTable dtHot = new DataTable();
            dtHot = CommonUtility.GetBaseListByCache(6, "nTime>DATEADD(day,-10,GETDATE()) order by nClicks desc","person_" + ClassId + "_Hot");

            this.rptHot.DataSource = dtHot;
            this.rptHot.DataBind();

            //标签
            DataTable dtTag = new DataTable();
            dtTag = new TagsBLL().GetList(10, "classId='" + ClassId + "' AND TType=1 order by tAddTime desc", true, "person_" + ClassId + "_tag", 120);
            this.rptTag.DataSource = dtTag;
            this.rptTag.DataBind();

            //相关推荐
            DataTable dtAround = new DataTable();
            dtAround = _personBLL.GetList(6, "pId,pCnName,pPhoto,pJob,cName,cEnName", "classId='" + ClassId + "' AND pAddTime>DATEADD(day,-30,GETDATE()) Order By pClicks DESC");

            this.rptAround.DataSource = dtAround;
            this.rptAround.DataBind();



            //推荐
            DataTable dtRecommend = new DataTable();
            dtRecommend = CommonUtility.GetBaseListByCache(8, "nTime>DATEADD(day,-30,GETDATE()) and nIsRecommand=1", "person_" + ClassId + "_Recommand");

            this.rptRecommend.DataSource = dtRecommend;
            this.rptRecommend.DataBind();
        }
    }
}