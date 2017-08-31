using Car.BLL;
using Car.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.Manage.News
{
    public partial class NewsManage : BasePage
    {
        NewsBLL _NewsBLL = new NewsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadClass();
                LoadData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadClass()
        {
            DataTable dtClass = new ClassBLL().GetList(0, "cLevel=1 ORDER BY cOrder");
            this.ddlClass.DataSource = dtClass;
            this.ddlClass.DataValueField = "cbId";
            this.ddlClass.DataTextField = "cbName";
            this.ddlClass.DataBind();
            this.ddlClass.Items.Insert(0, new ListItem("请选择", ""));

            this.selClass.DataSource = dtClass;
            this.selClass.DataValueField = "cbId";
            this.selClass.DataTextField = "cbName";
            this.selClass.DataBind();
            this.selClass.Items.Insert(0, new ListItem("请选择", ""));
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadData()
        {
            string ClassId = this.ddlClass.SelectedItem.Value;
            string Status = this.ddlStatus.SelectedItem.Value;
            string Title = this.txtTitle.Text;
            string sDate = this.txtRegStartDate.Text;
            string eDate = this.txtRegEndDate.Text;

            string where = "1=1";
            if (ClassId != "")
            {
                where += " AND nclass1='" + ClassId + "'";
            } if (Status != "")
            {
                where += " AND nStatus=" + Status + "";
            } if (Title != "")
            {
                where += " AND nTitle like '%" + Title + "%'";
            }

            int totalCount = 0;
            DataTable dt = _NewsBLL.GetPaging(where,"nAddTime","", pager.PageSize, pager.CurrentPageIndex, out totalCount);

            this.pager.RecordCount = totalCount;
            this.gvList.DataSource = dt;
            this.gvList.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSet_Click(object sender, EventArgs e)
        {
            C_News _P_News;
            string Id = this.hidId.Value;

            if (!string.IsNullOrEmpty(Id))
            {
                string[] Ids = Id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < Ids.Length; i++)
                {
                    _P_News = new C_News();
                    _P_News.nStatus = Convert.ToByte(this.selStatus.Value);
                    _P_News.nId = Convert.ToInt32(Ids[i]);
                    _NewsBLL.UpdateStatus(_P_News);
                }
                LoadData();
                this.ClientScript.RegisterStartupScript(GetType(), "a", "alert('提交成功！')", true);
            }
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_Click(object sender, EventArgs e)
        {
            C_News _P_News;
            string Id = this.hidId.Value;

            if (!string.IsNullOrEmpty(Id))
            {
                string[] Ids = Id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < Ids.Length; i++)
                {
                    _P_News = new C_News();
                    _P_News.nStatus = Convert.ToByte(this.selStatus.Value);
                    _P_News.nId = Convert.ToInt32(Ids[i]);
                    _NewsBLL.Delete(_P_News);
                }
                LoadData();
                this.ClientScript.RegisterStartupScript(GetType(), "a", "alert('提交成功！')", true);
            }
        }

        /// <summary>
        /// 修改分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            C_News _P_News;
            string Id = this.hidId.Value;

            if (!string.IsNullOrEmpty(Id))
            {
                string[] Ids = Id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < Ids.Length; i++)
                {
                    _P_News = new C_News();
                    _P_News.nclass1 = Convert.ToInt32(this.selClass.Value);
                    _P_News.nId = Convert.ToInt32(Ids[i]);
                    _NewsBLL.ChangeClass(_P_News);
                }
                LoadData();
                this.ClientScript.RegisterStartupScript(GetType(), "a", "alert('提交成功！')", true);
            }
        }
    }
}