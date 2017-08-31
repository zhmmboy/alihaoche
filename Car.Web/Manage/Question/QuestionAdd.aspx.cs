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

namespace Car.Web.Manage.Question
{
    public partial class QuestionAdd : System.Web.UI.Page
    {
        QuestionBLL _QuestionBLL = new QuestionBLL();
        string Id = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                this.txtNTags.Value = dtData.Rows[0]["qTags"].ToString();
                this.txtAsker.Value = dtData.Rows[0]["qAsker"].ToString();
                this.txtIntro.Value = dtData.Rows[0]["qIntro"].ToString();
                this.selPerson.Value = dtData.Rows[0]["personId"].ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExists_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            C_Question _P_Question = new C_Question();

            _P_Question.qTitle = this.txtTitle.Value;
            _P_Question.qAsker = this.txtAsker.Value;
            _P_Question.qTags = this.txtNTags.Value;
            _P_Question.qIntro = this.txtIntro.Value;
            _P_Question.personId = new Guid(this.selPerson.Value);
            _P_Question.classId = new Guid(this.selClass.Value);
            _P_Question.qBad = 0;
            _P_Question.qGood = 0;
            _P_Question.qClicks = 0;
            _P_Question.qAddTime = System.DateTime.Now;

            //文件目录
            string Folder = Common.SystemVar.UpLoadImgForAlbum;

            _P_Question.qClicks = 0;
            _P_Question.qAddTime = System.DateTime.Now;

            //
            if (!string.IsNullOrEmpty(this.Request.QueryString["Id"]))
            {
                string Id = this.Request.QueryString["Id"].ToString();
                _P_Question.qId = new Guid(Id);
                _QuestionBLL.Edit(_P_Question);
            }
            else
            {
                _P_Question.qId = Guid.NewGuid();
                _QuestionBLL.Add(_P_Question);
            }

            //把该信息的tag保存到p_Tag表
            if (!string.IsNullOrEmpty(this.txtNTags.Value))
            {
                //new TagsBLL().Add(this.txtNTags.Value, _P_Question.qId, _P_Question.classId, Convert.ToInt32(SystemVar.EnumTagType.Question));
            }

            this.ClientScript.RegisterStartupScript(this.GetType(), "a", "alert('提交成功！');window.location.href='QuestionManage.aspx'", true);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("QuestionManage.aspx");
        }
    }
}