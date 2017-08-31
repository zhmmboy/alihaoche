using Car.BLL;
using Car.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car.Web.Manage.Question
{
    public partial class AnswerAdd : System.Web.UI.Page
    {
        AnswerBLL _AnswerBLL = new AnswerBLL();
        QuestionBLL _QuestionBLL = new QuestionBLL();
        string Id = string.Empty;
        string aId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Id = this.Request.QueryString["Id"];
            aId = this.Request.QueryString["aId"];

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
            DataTable dtClass = new ClassBLL().GetList(0, "cLevel=1 ORDER BY cOrder");
            this.selClass.DataSource = dtClass;
            this.selClass.DataValueField = "cId";
            this.selClass.DataTextField = "cName";
            this.selClass.DataBind();

            DataTable dtPerson = new PersonBLL().GetBaseList(0, "");
            this.selPerson.DataSource = dtPerson;
            this.selPerson.DataValueField = "pId";
            this.selPerson.DataTextField = "pCnName";
            this.selPerson.DataBind();

            //
            Id = this.Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(Id))
            {
                DataTable dtData = _QuestionBLL.GetQuestionById(new Guid(Id));

                this.txtTitle.Value = dtData.Rows[0]["qTitle"].ToString();
                this.selPerson.Value = dtData.Rows[0]["personId"].ToString();
            }


            if (!string.IsNullOrEmpty(aId))
            {
                DataTable dt = _AnswerBLL.GetList(0, "aId='" + aId + "'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.txtAnswer.Value = dt.Rows[0]["aContent"].ToString();
                }
            }
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            C_Answer _P_Answer = new C_Answer();

            _P_Answer.aContent = this.txtAnswer.Value;
            _P_Answer.aNickName = string.Empty;
            _P_Answer.aEmail = string.Empty;
            _P_Answer.qId = new Guid(Id);
            _P_Answer.aAddTime = System.DateTime.Now;
            _P_Answer.aGood = 0;
            _P_Answer.aId = Guid.NewGuid();
            _P_Answer.aBad = 0;

            int count = 0;

            if (!string.IsNullOrEmpty(aId))
            {
                _P_Answer.aId = new Guid(aId);
                count = _AnswerBLL.Edit(_P_Answer);
            }
            else
            {
                count = _AnswerBLL.Add(_P_Answer);
            }

            //
            if (count > 0)
            {
                this.ClientScript.RegisterStartupScript(GetType(), "a", "alert('ok!')", true);
            }
        }
        
        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("AnswerManage.aspx");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBackAnswer_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("AnswerManage.aspx?Id="+Id);

        }
    }
}