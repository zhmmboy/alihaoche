using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Car.BLL;

namespace Car.Web.Manage.Tag
{
    public partial class TagManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDrop();
                LoadData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadDrop()
        {
            DataTable dtClass = new ClassBLL().GetList(0, "cLevel=1 ORDER BY cOrder");
            this.ddlClass.DataSource = dtClass;
            this.ddlClass.DataValueField = "cId";
            this.ddlClass.DataTextField = "cName";
            this.ddlClass.DataBind();
            this.ddlClass.Items.Insert(0, new ListItem("请选择", ""));
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            TagsBLL _TagsBLL = new TagsBLL();
            string tClass = this.ddlClass.SelectedItem.Value;
            string tName = this.txtName.Text;
            string sDate = this.txtRegStartDate.Text;
            string eDate = this.txtRegEndDate.Text;

            string where = "1=1";
            if (tClass != "")
            {
                where += " AND cId='" + tClass + "'";
            } if (tName != "")
            {
                where += " AND (tName like '%" + tName + "%')";
            } if (!string.IsNullOrEmpty(sDate))
            {
                where += " AND tAddTime>='" + sDate + "'";
            } if (!string.IsNullOrEmpty(eDate))
            {
                where += " AND tAddTime<='" + eDate + "'";
            }

            int totalCount = 0;
            DataTable dt = _TagsBLL.GetPaging(where, "tAddTime","",pager.PageSize, pager.CurrentPageIndex, out totalCount);

            this.pager.RecordCount = totalCount;
            this.gvList.DataSource = dt;
            this.gvList.DataBind();
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}