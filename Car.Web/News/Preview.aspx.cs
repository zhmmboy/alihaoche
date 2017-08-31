using System;
using System.Data;
using Car.BLL;

namespace Car.Web.News
{
    public partial class Preview : System.Web.UI.Page
    {
        public string TitleStr = string.Empty;
        public string KeyStr = string.Empty;
        public string DescStr = string.Empty;
        public string ContentStr = string.Empty;
        public string PrevNextArticleStr = string.Empty;                //上一篇/下一篇文章
        public string PrevNextForOneStr = string.Empty;                 //文章的上一页/下一页
        public string NextForRightStr = string.Empty;                   //最右侧，下一篇文章
        public string TagsStr = string.Empty;
        public int PageIndex = CommonUtility.GetQueryInt("pageIndex", 1);
        public int nId;
        public string TotalZan = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Request.QueryString["Id"]))
            {
                nId = Convert.ToInt32(this.Request.QueryString["Id"]);
            }
            if (!IsPostBack)
            {
                if (nId > 0)
                {
                    LoadData();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadData()
        {
            NewsBLL _newBll = new BLL.NewsBLL();
            DataTable dt = _newBll.GetNewTempById(nId);

            string ClassId = string.Empty;      //资讯分类
            int OrderIndex = 0;                 //资讯在表中的索引

            //如果有数据
            if (dt != null)
            {
                TitleStr = dt.Rows[0]["ntitle"].ToString();
                KeyStr = dt.Rows[0]["nTags"].ToString();
                DescStr = dt.Rows[0]["nTips"].ToString();
                ContentStr = dt.Rows[0]["nContent"].ToString();
                ClassId = dt.Rows[0]["nclass1"].ToString();
                OrderIndex = Convert.ToInt32(dt.Rows[0]["nIndex"]);
                TotalZan = dt.Rows[0]["nGood"].ToString();
                //分页处理
                if (!string.IsNullOrEmpty(ContentStr))
                {
                    string[] strContent = ContentStr.Split(new string[] { "|page|" }, StringSplitOptions.RemoveEmptyEntries);

                    if (strContent.Length > 1)
                    {
                        if (PageIndex == 1)
                        {
                            PrevNextForOneStr = "<li class=\"prev-page\"><a>上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/" + dt.Rows[0]["nId"].ToString() + "_page" + (PageIndex + 1) + ".html\">下一页</a></li>";
                        }
                        else if (PageIndex == 2)
                        {
                            if (PageIndex == strContent.Length)
                            {
                                PrevNextForOneStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/" + dt.Rows[0]["nId"].ToString() + ".html\">上一页</a></li><li class=\"prev-page\"><a>下一页</a></li>";
                            }
                            else
                            {
                                PrevNextForOneStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/" + dt.Rows[0]["nId"].ToString() + ".html\">上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/" + dt.Rows[0]["nId"].ToString() + "_page" + (PageIndex + 1) + ".html\">下一页</a></li>";
                            }
                        }
                        else
                        {
                            if (PageIndex == strContent.Length)
                            {
                                PrevNextForOneStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/" + dt.Rows[0]["nId"].ToString() + "_page" + (PageIndex - 1) + ".html\">上一页</a></li><li class=\"prev-page\"><a>下一页</a></li>";
                            }
                            else
                            {
                                PrevNextForOneStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/" + dt.Rows[0]["nId"].ToString() + "_page" + (PageIndex - 1) + ".html\">上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/news/" + dt.Rows[0]["nId"].ToString() + "_page" + (PageIndex + 1) + ".html\">下一页</a></li>";
                            }
                        }
                    }
                }

                //获取该资讯的上一篇/下一篇文章记录
                DataTable dtPrevNext = _newBll.GetList(2, "nid,nIndex,ntitle,cbName", "nIndex in(" + (OrderIndex - 1) + "," + (OrderIndex + 1) + ") order by nIndex");

                //说明只有一篇文章
                if (dtPrevNext != null)
                {
                    if (dtPrevNext.Rows.Count == 1)
                    {
                        int currentOrderIndex = Convert.ToInt32(dtPrevNext.Rows[0]["nIndex"]);
                        //显示下一篇
                        if (currentOrderIndex > OrderIndex)
                        {
                            PrevNextArticleStr = "<span class=\"article-nav-prev\">上一篇<br>这是第一篇文章，没有上一篇！</span>"
                                        + "<span class=\"article-nav-next\">下一篇<br>"
                                        + "<a href=\"http://www.alihaoche.com/news/" + dtPrevNext.Rows[0]["nId"].ToString() + ".html\" rel=\"next\">" + dtPrevNext.Rows[0]["nTitle"].ToString() + "</a></span>";

                            NextForRightStr = "<a class=\"pagebar pagebar-next\" title=\"\" href=\"http://www.alihaoche.com/person/" + dtPrevNext.Rows[0]["nId"].ToString() + ".html\" data-original-title=\"下一篇：&lt;br&gt;" + dtPrevNext.Rows[0]["nTitle"].ToString() + "\"><span class=\"glyphicon glyphicon-chevron-right\"></span><i class=\"glyphicon glyphicon-chevron-right\"></i></a>";

                        }
                        else
                        {
                            //显示上一篇
                            PrevNextArticleStr = "<span class=\"article-nav-prev\">上一篇<br>"
                                        + "<a href=\"http://www.alihaoche.com/news/" + dtPrevNext.Rows[0]["nId"].ToString() + ".html\" rel=\"prev\">" + dtPrevNext.Rows[0]["nTitle"].ToString() + "</a></span>"
                                        + "<span class=\"article-nav-next\">下一篇<br>这是最后一篇文章，没有下一篇！";
                        }
                    }
                    else if (dtPrevNext.Rows.Count == 2)
                    {
                        PrevNextArticleStr = "<span class=\"article-nav-prev\">上一篇<br>"
                                         + "<a href=\"http://www.alihaoche.com/news/" + dtPrevNext.Rows[0]["nId"].ToString() + ".html\" rel=\"prev\">" + dtPrevNext.Rows[0]["nTitle"].ToString() + "</a></span>"
                                         + "<span class=\"article-nav-next\">下一篇<br>"
                                         + "<a href=\"http://www.alihaoche.com/news/" + dtPrevNext.Rows[1]["cEnName"].ToString() + "/" + dtPrevNext.Rows[1]["nId"].ToString() + ".html\" rel=\"next\">" + dtPrevNext.Rows[1]["nTitle"].ToString() + "</a></span>";

                        NextForRightStr = "<a class=\"pagebar pagebar-next\" title=\"\" href=\"http://www.alihaoche.com/person/" + dtPrevNext.Rows[0]["nId"].ToString() + ".html\" data-original-title=\"下一篇：&lt;br&gt;" + dtPrevNext.Rows[0]["nTitle"].ToString() + "\"><span class=\"glyphicon glyphicon-chevron-right\"></span><i class=\"glyphicon glyphicon-chevron-right\"></i></a>";

                    }
                }

                //标签
                string[] tags = dt.Rows[0]["nTags"].ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (tags.Length > 0)
                {
                    for (int i = 0; i < tags.Length; i++)
                        TagsStr += "<a target=\"_blank\" href=\"http://www.alihaoche.com/tag/" + Server.UrlEncode(tags[i]) + "\" title=\"“" + tags[i] + "”相关文章\">" + tags[i] + "</a>";
                }
            }

            //点击数+1
            //_newBll.Clicks(nId);

            //Guid Id = dt.Rows[0]["nId"].ToString();
            //DataTable dtNews = _newBll.GetList(1, "nid,ntitle,nauthor,nclicks,cbName,ncontent,ntags,nAddTime","nId=" + Id);

            this.rptData.DataSource = dt;
            this.rptData.DataBind();

            //7天热门资讯
            DataTable dtHot = new DataTable();
            dtHot = CommonUtility.GetBaseListByCache(6, "nAddTime>DATEADD(day,-10,GETDATE()) order by nClicks desc", "news_" + ClassId + "_hot");

            //this.rptHot.DataSource = dtHot;
            //this.rptHot.DataBind();

            //标签
            DataTable dtTag = new DataTable();
            dtTag = new TagsBLL().GetList(10, "classId='" + ClassId + "'  AND TType=2 order by tAddTime desc", true, "news_" + ClassId + "_tag", 120);
            //this.rptTag.DataSource = dtTag;
            //this.rptTag.DataBind();

            //热门相册
            //DataTable dtAlbum = new DataTable();
            //AlbumBLL _AlbumBLL = new AlbumBLL();
            //dtAlbum = _AlbumBLL.GetList(6, "aAddTime>DATEADD(day,-30,GETDATE()) order by aClicks desc");

            //this.rptAlbum.DataSource = dtAlbum;
            //this.rptAlbum.DataBind();

            //相关推荐 
            DataTable dtRecommend = new DataTable();
            dtRecommend = CommonUtility.GetBaseListByCache(8, "nclass1='" + ClassId + "' AND nAddTime>DATEADD(day,-30,GETDATE()) and nIsRecommand=1", "news_" + ClassId + "_recommend");

            //this.rptRecommend.DataSource = dtRecommend;
            //this.rptRecommend.DataBind();
        }
    }
}