using System;
using System.Data;
using Car.BLL;

namespace Car.Web.Question
{
    public partial class Info : System.Web.UI.Page
    {
        public string TitleStr = string.Empty;
        public string KeyStr = string.Empty;
        public string DescStr = string.Empty;
        public string ContentStr = string.Empty;
        public string PrevNextNewsStr = string.Empty;
        public string NextNewsStr = string.Empty;
        public string TagsStr = string.Empty;
        string classId = string.Empty;                           //分类Id
        public int Answers = 0;                //评论数量
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
            QuestionBLL _QuestionBLL = new BLL.QuestionBLL();

            string Id = this.Request.QueryString["Id"];
            Guid GuId = new Guid(Id);
            DataTable dt = _QuestionBLL.GetQuestionById(GuId);
            int orderIndex = 0;   //资讯在表中的索引

            //如果有数据
            if (dt != null && dt.Rows.Count > 0)
            {
                TitleStr = dt.Rows[0]["qTitle"].ToString();
                KeyStr = dt.Rows[0]["qTags"].ToString();
                DescStr = dt.Rows[0]["qTitle"].ToString();
                ContentStr = dt.Rows[0]["qIntro"].ToString();
                orderIndex = Convert.ToInt32(dt.Rows[0]["qIndex"]);
                classId = dt.Rows[0]["cId"].ToString();
                TotalZan = dt.Rows[0]["qGood"].ToString();
            }

            //获取该资讯的上一篇/下一篇文章记录
            DataTable dtPrevNext = _QuestionBLL.GetList(2, "qId,qTitle,qIndex,cName,cEnName", "qIndex in(" + (orderIndex - 1) + "," + (orderIndex + 1) + ") order by qIndex");

            //说明只有一篇文章
            if (dtPrevNext != null && dtPrevNext.Rows.Count > 0)
            {
                if (dtPrevNext.Rows.Count == 1)
                {
                    int currentOrderIndex = Convert.ToInt32(dtPrevNext.Rows[0]["qIndex"]);
                    //显示下一篇
                    if (currentOrderIndex > orderIndex)
                    {
                        PrevNextNewsStr = "<span class=\"article-nav-prev\">上一篇<br>这是第一篇文章，没有上一篇！</span>"
                                    + "<span class=\"article-nav-next\">下一篇<br>"
                                    + "<a href=\"http://www.alihaoche.com/question/" + dtPrevNext.Rows[0]["cEnName"].ToString() + "/" + dtPrevNext.Rows[0]["qId"].ToString() + ".html\" rel=\"next\">" + dtPrevNext.Rows[0]["qTitle"].ToString() + "</a></span>";

                        NextNewsStr = "<a class=\"pagebar pagebar-next\" title=\"\" href=\"http://www.alihaoche.com/question/" + dtPrevNext.Rows[0]["cEnName"].ToString() + "/" + dtPrevNext.Rows[0]["qId"].ToString() + ".html\" data-original-title=\"下一篇：&lt;br&gt;" + dtPrevNext.Rows[0]["qTitle"].ToString() + "\"><span class=\"glyphicon glyphicon-chevron-right\"></span><i class=\"glyphicon glyphicon-chevron-right\"></i></a>";
                    }
                    else
                    {
                        //显示上一篇
                        PrevNextNewsStr = "<span class=\"article-nav-prev\">上一篇<br>"
                                    + "<a href=\"http://www.alihaoche.com/question/" + dtPrevNext.Rows[0]["cEnName"].ToString() + "/" + dtPrevNext.Rows[0]["qId"].ToString() + ".html\" rel=\"prev\">" + dtPrevNext.Rows[0]["qTitle"].ToString() + "</a></span>"
                                    + "<span class=\"article-nav-next\">下一篇<br>这是最后一篇文章，没有下一篇！";
                    }
                }
                else if (dtPrevNext.Rows.Count == 2)
                {
                    PrevNextNewsStr = "<span class=\"article-nav-prev\">上一篇<br>"
                                     + "<a href=\"http://www.alihaoche.com/question/" + dtPrevNext.Rows[0]["cEnName"].ToString() + "/" + dtPrevNext.Rows[0]["qId"].ToString() + ".html\" rel=\"prev\">" + dtPrevNext.Rows[0]["qTitle"].ToString() + "</a></span>"
                                     + "<span class=\"article-nav-next\">下一篇<br>"
                                     + "<a href=\"http://www.alihaoche.com/question/" + dtPrevNext.Rows[1]["cEnName"].ToString() + "/" + dtPrevNext.Rows[1]["qId"].ToString() + ".html\" rel=\"next\">" + dtPrevNext.Rows[1]["qTitle"].ToString() + "</a></span>";

                    NextNewsStr = "<a class=\"pagebar pagebar-next\" title=\"\" href=\"http://www.alihaoche.com/question/" + dtPrevNext.Rows[1]["cEnName"].ToString() + "/" + dtPrevNext.Rows[1]["qId"].ToString() + ".html\" data-original-title=\"下一篇：&lt;br&gt;" + dtPrevNext.Rows[1]["qTitle"].ToString() + "\"><span class=\"glyphicon glyphicon-chevron-right\"></span><i class=\"glyphicon glyphicon-chevron-right\"></i></a>";

                }

            }
            //标签
            string[] tags = dt.Rows[0]["qTags"].ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (tags.Length > 0)
            {
                for (int i = 0; i < tags.Length; i++)
                    TagsStr += "<a target=\"_blank\" href=\"http://www.alihaoche.com/tag/" + Server.UrlEncode(tags[i]) + "\" title=\"“" + tags[i] + "”相关文章\">" + tags[i] + "</a>";
            }
            //阅读数+1
            _QuestionBLL.Clicks(new Guid(Id));

            this.rptData.DataSource = dt;
            this.rptData.DataBind();

            //7天热门
            DataTable dtHot = new DataTable();
            dtHot = _QuestionBLL.GetBaseList(6, " cId='" + classId + "' AND qAddTime>DATEADD(day,-30,GETDATE()) order by qClicks desc", true, "question_Info_Hot_" + classId, 120);

            this.rptHot.DataSource = dtHot;
            this.rptHot.DataBind();

            //标签
            DataTable dtTag = new DataTable();
            dtTag = new TagsBLL().GetList(10, " classId='" + classId + "' AND TType=4 order by tAddTime desc", true, "question_info_tag_" + classId, 120);
            this.rptTag.DataSource = dtTag;
            this.rptTag.DataBind();

            //相关推荐
            DataTable dtAround = new DataTable();
            dtAround = _QuestionBLL.GetBaseList(8, " cId='" + classId + "' AND qAddTime>DATEADD(day,-30,GETDATE())", true, "question_Info_Around_" + classId, 120);
            this.rptAround.DataSource = dtAround;
            this.rptAround.DataBind();

            //新闻推荐
            DataTable dtRecommend = new DataTable();
            dtRecommend = CommonUtility.GetBaseListByCache(8, " nclass1='" + classId + "' AND nTime>DATEADD(day,-30,GETDATE()) and nIsRecommand=1 order by nClicks desc", "question_info_recommand_" + classId);

            this.rptRecommend.DataSource = dtRecommend;
            this.rptRecommend.DataBind();

            //加载评论
            DataTable dtAnswer = new AnswerBLL().GetList(20, "qId='" + Id + "'");
            Answers = dt.Rows.Count;
            this.rptAnswers.DataSource = dtAnswer;
            this.rptAnswers.DataBind();
        }
    }
}