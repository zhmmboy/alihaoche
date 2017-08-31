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

namespace Car.Web.Album
{
    public partial class Info : System.Web.UI.Page
    {
        public string TitleStr = string.Empty;
        public string KeyStr = string.Empty;
        public string DescStr = string.Empty;
        public string ContentStr = string.Empty;
        public string TagsStr = string.Empty;
        public string PrevNextArticleStr = string.Empty;                            //上一篇/下一篇文章
        public string PrevNextForOneStr = string.Empty;                             //一篇文章/上一页/下一页
        public string NextForRightStr = string.Empty;                               //最右侧，下一篇文章
        public int PageIndex = CommonUtility.GetQueryInt("pageIndex", 1);
        public string aId = string.Empty;
        public string aName = string.Empty;
        public string cName = string.Empty;
        public string cEnName = string.Empty;
        public string aiAddTime = string.Empty;
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
            NewsBLL _newBll = new BLL.NewsBLL();
            PersonBLL _PersonBLL = new PersonBLL();
            AlbumBLL _AlbumBLL = new AlbumBLL();

            Guid Id = new Guid(this.Request.QueryString["Id"]);
            string PersonId = string.Empty;
            string ClassId = string.Empty;
            int OrderIndex = 0;

            DataTable dt = _AlbumBLL.GetAlbumInfoById(Id);

            //如果有数据
            if (dt != null && dt.Rows.Count > 0)
            {
                TitleStr = dt.Rows[0]["aName"].ToString();
                KeyStr = dt.Rows[0]["aTags"].ToString();
                DescStr = dt.Rows[0]["aIntro"].ToString();
                PersonId = dt.Rows[0]["personId"].ToString();
                ClassId = dt.Rows[0]["cId"].ToString();
                TotalZan = dt.Rows[0]["aClicks"].ToString(); 
                aId = dt.Rows[0]["aId"].ToString();
                aName = dt.Rows[0]["aName"].ToString();
                cName = dt.Rows[0]["cName"].ToString();
                cEnName = dt.Rows[0]["cEnName"].ToString();
                aiAddTime = Convert.ToDateTime(dt.Rows[0]["aiAddTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                OrderIndex = Convert.ToInt32(dt.Rows[0]["aIndex"]);

                #region 上一篇/下一篇


                //获取该资讯的上一篇/下一篇文章记录
                DataTable dtPrevNext = _AlbumBLL.GetList(2, "aIndex in(" + (OrderIndex - 1) + "," + (OrderIndex + 1) + ") order by aIndex");

                //说明只有一篇文章
                if (dtPrevNext != null)
                {
                    if (dtPrevNext.Rows.Count == 1)
                    {
                        int currentOrderIndex = Convert.ToInt32(dtPrevNext.Rows[0]["aIndex"]);
                        //显示下一篇
                        if (currentOrderIndex > OrderIndex)
                        {
                            PrevNextArticleStr = "<span class=\"article-nav-prev\">上一篇<br>这是第一篇文章，没有上一篇！</span>"
                                        + "<span class=\"article-nav-next\">下一篇<br>"
                                        + "<a href=\"http://www.alihaoche.com/album/" + dtPrevNext.Rows[0]["cEnName"].ToString() + "/" + dtPrevNext.Rows[0]["aId"].ToString() + ".html\" rel=\"next\">" + dtPrevNext.Rows[0]["aName"].ToString() + "</a></span>";

                            NextForRightStr = "<a class=\"pagebar pagebar-next\" title=\"\" href=\"http://www.alihaoche.com/album/" + dtPrevNext.Rows[0]["cEnName"].ToString() + "/" + dtPrevNext.Rows[0]["aId"].ToString() + ".html\" data-original-title=\"下一篇：&lt;br&gt;" + dtPrevNext.Rows[0]["aName"].ToString() + "\"><span class=\"glyphicon glyphicon-chevron-right\"></span><i class=\"glyphicon glyphicon-chevron-right\"></i></a>";
                        }
                        else
                        {
                            //显示上一篇
                            PrevNextArticleStr = "<span class=\"article-nav-prev\">上一篇<br>"
                                        + "<a href=\"http://www.alihaoche.com/album/" + dtPrevNext.Rows[0]["cEnName"].ToString() + "/" + dtPrevNext.Rows[0]["aId"].ToString() + ".html\" rel=\"prev\">" + dtPrevNext.Rows[0]["aName"].ToString() + "</a></span>"
                                        + "<span class=\"article-nav-next\">下一篇<br>这是最后一篇文章，没有下一篇！";
                        }
                    }
                    else if (dtPrevNext.Rows.Count == 2)
                    {
                        PrevNextArticleStr = "<span class=\"article-nav-prev\">上一篇<br>"
                                         + "<a href=\"http://www.alihaoche.com/album/" + dtPrevNext.Rows[0]["cEnName"].ToString() + "/" + dtPrevNext.Rows[0]["aId"].ToString() + ".html\" rel=\"prev\">" + dtPrevNext.Rows[0]["aName"].ToString() + "</a></span>"
                                         + "<span class=\"article-nav-next\">下一篇<br>"
                                         + "<a href=\"http://www.alihaoche.com/album/" + dtPrevNext.Rows[1]["cEnName"].ToString() + "/" + dtPrevNext.Rows[1]["aId"].ToString() + ".html\" rel=\"next\">" + dtPrevNext.Rows[1]["aName"].ToString() + "</a></span>";

                        NextForRightStr = "<a class=\"pagebar pagebar-next\" title=\"\" href=\"http://www.alihaoche.com/album/" + dtPrevNext.Rows[1]["cEnName"].ToString() + "/" + dtPrevNext.Rows[1]["aId"].ToString() + ".html\" data-original-title=\"下一篇：&lt;br&gt;" + dtPrevNext.Rows[1]["aName"].ToString() + "\"><span class=\"glyphicon glyphicon-chevron-right\"></span><i class=\"glyphicon glyphicon-chevron-right\"></i></a>";

                    }

                #endregion

                    //标签
                    string[] tags = dt.Rows[0]["aTags"].ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (tags.Length > 0)
                    {
                        for (int i = 0; i < tags.Length; i++)
                            TagsStr += "<a target=\"_blank\" href=\"http://www.alihaoche.com/album/tag/" + Server.UrlEncode(tags[i]) + "\" title=\"“" + tags[i] + "”相关文章\">" + tags[i] + "</a>";
                    }


                    //相册分页：将照片累加成a|page|b|page|c格式，则用通用分页格式进行分页
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ContentStr += "<img src=\"http://www.alihaoche.com/" + dt.Rows[i]["aiUrl"].ToString().Replace("../","") + "\" title=\"" + dt.Rows[i]["aiDesc"].ToString() + "\" alt=\"" + dt.Rows[i]["aiDesc"].ToString() + "\"><br/>" + dt.Rows[i]["aiDesc"].ToString() + "|page|";
                    }

                    //分页
                    if (!string.IsNullOrEmpty(ContentStr))
                    {
                        string[] strContent = ContentStr.Split(new string[] { "|page|" }, StringSplitOptions.RemoveEmptyEntries);

                        if (strContent.Length > 1)
                        {
                            if (PageIndex == 1)
                            {
                                PrevNextForOneStr = "<li class=\"prev-page\"><a>上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/album/" + dt.Rows[0]["cEnName"].ToString() + "/" + dt.Rows[0]["aId"].ToString() + "_page" + (PageIndex + 1) + ".html\">下一页</a></li>";
                            }
                            else if (PageIndex == 2)
                            {
                                if (PageIndex == strContent.Length)
                                {
                                    PrevNextForOneStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/album/" + dt.Rows[0]["cEnName"].ToString() + "/" + dt.Rows[0]["aId"].ToString() + ".html\">上一页</a></li><li class=\"prev-page\"><a>下一页</a></li>";
                                }
                                else
                                {
                                    PrevNextForOneStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/album/" + dt.Rows[0]["cEnName"].ToString() + "/" + dt.Rows[0]["aId"].ToString() + ".html\">上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/album/" + dt.Rows[0]["cEnName"].ToString() + "/" + dt.Rows[0]["aId"].ToString() + "_page" + (PageIndex + 1) + ".html\">下一页</a></li>";
                                }
                            }
                            else
                            {
                                if (PageIndex == strContent.Length)
                                {
                                    PrevNextForOneStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/album/" + dt.Rows[0]["cEnName"].ToString() + "/" + dt.Rows[0]["aId"].ToString() + "_page" + (PageIndex - 1) + ".html\">上一页</a></li><li class=\"prev-page\"><a>下一页</a></li>";
                                }
                                else
                                {
                                    PrevNextForOneStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/album/" + dt.Rows[0]["cEnName"].ToString() + "/" + dt.Rows[0]["aId"].ToString() + "_page" + (PageIndex - 1) + ".html\">上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/album/" + dt.Rows[0]["cEnName"].ToString() + "/" + dt.Rows[0]["aId"].ToString() + "_page" + (PageIndex + 1) + ".html\">下一页</a></li>";
                                }
                            }
                        }
                    }
                }

                //7天热门
                DataTable dtHot = new DataTable();
                dtHot = _PersonBLL.GetBaseList(6, "pAddTime>DATEADD(day,-30,GETDATE()) order by pClicks desc", true, "Album_Info_Hot", 120);

                this.rptHot.DataSource = dtHot;
                this.rptHot.DataBind();

                //标签
                DataTable dtTag = new DataTable();
                dtTag = new TagsBLL().GetList(10, "classId='" + ClassId + "'  AND TType=3 order by tAddTime desc", true, "Album_Info_Tag", 120);
                this.rptTag.DataSource = dtTag;
                this.rptTag.DataBind();

                //相关相册
                DataTable dtAlbum = new DataTable();
                dtAlbum = _AlbumBLL.GetList(8, "personId='" + PersonId + "' AND aAddTime>DATEADD(day,-30,GETDATE()) order by aClicks desc");

                this.rptAlbum.DataSource = dtAlbum;
                this.rptAlbum.DataBind();

                //推荐
                DataTable dtRecommend = new DataTable();
                dtRecommend = CommonUtility.GetBaseListByCache(6, "nTime>DATEADD(day,-30,GETDATE()) and nIsRecommand=1 order by nClicks desc", "Album_Info_Recommend");

                this.rptRecommend.DataSource = dtRecommend;
                this.rptRecommend.DataBind();
            }
        }
    }
}