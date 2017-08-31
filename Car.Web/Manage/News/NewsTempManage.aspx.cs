using Car.BLL;
using Car.Common;
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
    public partial class NewsTempManage : BasePage
    {
        NewsBLL _NewsBLL = new NewsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCarBrand();
                LoadData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadCarBrand()
        {
            DataTable dtCarBrand = new CarBrandBLL().GetList(0, "(cbParentId=0 OR cbParentId is null) ORDER BY cbOrderIndex");

            this.ddlCarBrand.DataSource = dtCarBrand;
            this.ddlCarBrand.DataValueField = "cbId";
            this.ddlCarBrand.DataTextField = "cbName";
            this.ddlCarBrand.DataBind();
            this.ddlCarBrand.Items.Insert(0, new ListItem("请选择", ""));

            this.selClass.DataSource = dtCarBrand;
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
            string ClassId = this.ddlCarBrand.SelectedItem.Value;
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
            DataTable dt = _NewsBLL.GetTempPaging(where, "nStatus", "", pager.PageSize, pager.CurrentPageIndex, out totalCount);

            this.pager.RecordCount = totalCount;
            this.gvList.DataSource = dt;
            this.gvList.DataBind();
        }

        /// <summary>
        /// 批量审核
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
                    _P_News.nStatus = Convert.ToByte(SystemVar.NewsStatus.Checked);
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
                    _P_News.nStatus = Convert.ToByte(SystemVar.NewsStatus.UnChecked);
                    _P_News.nId = Convert.ToInt32(Ids[i]);
                    _NewsBLL.DeleteTemp(_P_News);
                }
                LoadData();
                this.ClientScript.RegisterStartupScript(GetType(), "a", "alert('提交成功！')", true);
            }
        }

        /// <summary>
        /// 
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