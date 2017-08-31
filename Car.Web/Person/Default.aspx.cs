﻿using Car.BLL;
using Car.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.Person
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
                CreatePage();
            }
        }

        /// <summary>
        /// 生成静态页面
        /// </summary>
        private void CreatePage()
        {
            PersonBLL _personBLL = new PersonBLL();
            //页码
            int pageIndex = Convert.ToInt32(this.Request.QueryString["pageIndex"] != null && this.Request.QueryString["pageIndex"] != "" ? this.Request.QueryString["pageIndex"] : "1");
            //关键词 标签
            string tag = this.Request.QueryString["tag"];
            //查询条件
            string where = "1=1";
            //一周热门,一月热门
            string type = this.Request.QueryString["type"];

            //判断是否有关键词
            if (!string.IsNullOrEmpty(tag))
            {
                where += " AND pTags like '%" + PageValidateHelper.Filter(tag) + "%'";
            }
            //判断查询类型
            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "week": where += " AND pAddTime>DATEADD(day,-10,GETDATE())  ORDER BY pClicks DESC"; break;
                    case "month": where += " AND pAddTime>DATEADD(day,-30,GETDATE())  ORDER BY pClicks DESC"; break;
                    case "zan": where += " AND pAddTime>DATEADD(day,-90,GETDATE()) ORDER BY pFans DESC "; break;
                }
            }

            //正文
            DataTable dt = _personBLL.GetPaging(where,"pAddTime","", 10, pageIndex, out totalCount);

            this.rptData.DataSource = dt;
            this.rptData.DataBind();

            if (totalCount > 0)
            {
                decimal pageCount = Math.Ceiling(Convert.ToDecimal(totalCount) / 10);
                if (pageCount > 1)
                {
                    if (pageIndex == 1)
                    {
                        pageStr = "<li class=\"prev-page\"><a>上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/person/page" + (pageIndex + 1) + ".html\">下一页</a></li>";
                    }
                    else if (pageIndex == 2)
                    {
                        if (pageIndex == pageCount)
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/person\">上一页</a></li><li class=\"prev-page\"><a>下一页</a></li>";
                        }
                        else
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/person\">上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/person/page" + (pageIndex + 1) + ".html\">下一页</a></li>";
                        }
                    }
                    else
                    {
                        if (pageIndex == pageCount)
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/person\">上一页</a></li><li class=\"prev-page\"><a>下一页</a></li>";
                        }
                        else
                        {
                            pageStr = "<li class=\"next-page\"><a href=\"http://www.alihaoche.com/person/page" + (pageIndex - 1) + ".html\">上一页</a></li><li class=\"next-page\"><a href=\"http://www.alihaoche.com/person/page" + (pageIndex + 1) + ".html\">下一页</a></li>";
                        }
                    }
                }
            }

            //7天热门资讯
            DataTable dtHot = new DataTable();
            dtHot = _personBLL.GetBaseList(6, "pAddTime>DATEADD(day,-30,GETDATE()) order by pClicks desc", true, "person_default_hot",120);
            this.rptHot.DataSource = dtHot;
            this.rptHot.DataBind();

            //标签
            DataTable dtTag = new DataTable();
            dtTag = new TagsBLL().GetList(10, "TType=1 order by tAddTime desc", true, "person_default_tag",120);
            this.rptTag.DataSource = dtTag;
            this.rptTag.DataBind();

            //网友提问
            DataTable dtQuestion = new DataTable();
            dtQuestion = new BLL.QuestionBLL().GetBaseList(6, "qAddTime>DATEADD(day,-90,GETDATE()) order by qClicks desc", true, "person_default_recommand",120);
            this.rptQuestion.DataSource = dtQuestion;
            this.rptQuestion.DataBind();
        }
    }
}