using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Car.Entity;
using Car.BLL;
using Car.Common;

namespace Car.Web.Manage.Person
{
    public partial class PersonAdd : BasePage
    {
        PersonBLL _PersonBLL = new PersonBLL();
        string pId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            pId = this.Request.QueryString["Id"];
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

            if (!string.IsNullOrEmpty(pId))
            {
                DataTable dtData = _PersonBLL.GetPersonById(new Guid(pId));

                this.hidimgurl.Value = dtData.Rows[0]["pPhoto"].ToString();
                this.imgPhoto.Src = dtData.Rows[0]["pPhoto"].ToString();
                this.txtFirstChar.Value = dtData.Rows[0]["pFirstChar"].ToString();
                this.txtName.Value = dtData.Rows[0]["pCnName"].ToString();
                if (this.txtName.Value.Trim() != "")
                {
                    //this.txtName.Attributes["readonly"] = "readonly";
                }
                this.txtEnName.Value = dtData.Rows[0]["pEnName"].ToString();
                this.txtPenName.Value = dtData.Rows[0]["pPenName"].ToString();
                this.txtZodiac.Value = dtData.Rows[0]["pZodiac"].ToString();                    //生肖  
                this.txtConstellation.Value = dtData.Rows[0]["pConstellation"].ToString();      //星座
                this.rdoSex.Checked = Convert.ToBoolean(dtData.Rows[0]["pSex"]);                //男
                this.rodSex2.Checked = !Convert.ToBoolean(dtData.Rows[0]["pSex"]);              //女
                this.selNationality.Value = dtData.Rows[0]["pNationality"].ToString();
                this.selNation.Value = dtData.Rows[0]["pNation"].ToString();
                this.hidNation.Value = dtData.Rows[0]["pNation"].ToString();
                this.txtBirthday.Value = dtData.Rows[0]["pBirthday"].ToString();
                this.txtHeight.Value = dtData.Rows[0]["pHeight"].ToString().Trim() == "" ? "0" : dtData.Rows[0]["pHeight"].ToString();
                this.txtWeight.Value = dtData.Rows[0]["pWeight"].ToString().Trim() == "" ? "0" : dtData.Rows[0]["pWeight"].ToString();
                this.txtBWH.Value = dtData.Rows[0]["pBWH"].ToString();
                this.txtUniversity.Value = dtData.Rows[0]["pUniversity"].ToString();
                this.txtHomePlace.Value = dtData.Rows[0]["pHomeArea"].ToString();
                this.txtNowPlace.Value = dtData.Rows[0]["pNowPlace"].ToString();
                this.txtJob.Value = dtData.Rows[0]["pJob"].ToString();
                this.selBloodType.Value = dtData.Rows[0]["pBloodType"].ToString();              //血型
                this.txtSinaBlog.Value = dtData.Rows[0]["pSinaBlog"].ToString();
                this.txtTencentBlog.Value = dtData.Rows[0]["pTencentBlog"].ToString();
                this.txtHomePage.Value = dtData.Rows[0]["pHomePage"].ToString();
                this.selClass.Value = dtData.Rows[0]["ClassId"].ToString();
                this.txtSpeak.Value = dtData.Rows[0]["pSpeak"].ToString();
                this.txtTips.Value = dtData.Rows[0]["pTips"].ToString();
                this.txtContent.Text = dtData.Rows[0]["pIntroduce"].ToString();
                this.txtTags.Value = dtData.Rows[0]["pTags"].ToString();
                if (this.txtTags.Value.Trim() != "")
                {
                    //this.txtTags.Attributes["readonly"] = "readonly";
                }
            }
        }

        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            C_Person _P_Person = new C_Person();
            _P_Person.pFirstChar = this.txtFirstChar.Value;         //首字母
            _P_Person.pCnName = this.txtName.Value;
            _P_Person.pEnName = this.txtEnName.Value;
            _P_Person.pPenName = this.txtPenName.Value;
            _P_Person.pSex = this.rdoSex.Checked;
            _P_Person.pZodiac = this.txtZodiac.Value;               //生肖
            _P_Person.pConstellation = this.txtConstellation.Value;      //星座
            _P_Person.pNationality = this.selNationality.Value;
            _P_Person.pNation = this.hidNation.Value;
            _P_Person.pBirthday = Convert.ToDateTime(this.txtBirthday.Value);
            _P_Person.pHeight = Convert.ToDecimal(this.txtHeight.Value != "" ? this.txtHeight.Value : "0");
            _P_Person.pWeight = Convert.ToDecimal(this.txtWeight.Value != "" ? this.txtWeight.Value : "0");
            _P_Person.pNationality = this.selNationality.Value;
            _P_Person.pBWH = this.txtBWH.Value;
            _P_Person.pUniversity = this.txtUniversity.Value;
            _P_Person.pHomeProvince = string.Empty;
            _P_Person.pHomeCity = string.Empty;
            _P_Person.pHomeArea = this.txtHomePlace.Value;
            _P_Person.pNowPlace = this.txtNowPlace.Value;
            _P_Person.pNowProvice = string.Empty;
            _P_Person.pNowCity = string.Empty;
            _P_Person.pNowArea = string.Empty;
            _P_Person.pJob = this.txtJob.Value;
            _P_Person.pBloodType = this.selBloodType.Value;         //血型
            _P_Person.pSinaBlog = this.txtSinaBlog.Value;
            _P_Person.pTencentBlog = this.txtTencentBlog.Value;
            _P_Person.pHomePage = this.txtHomePage.Value;
            _P_Person.ClassId = new Guid(this.selClass.Value);
            _P_Person.pSpeak = this.txtSpeak.Value;
            _P_Person.pTips = this.txtTips.Value;
            _P_Person.pIntroduce = this.txtContent.Text;
            _P_Person.pTags = this.txtTags.Value;

            //文件目录
            string Folder = SystemVar.UpLoadImgForHead;
            //创建目录
            if (!Directory.Exists(Server.MapPath(Folder)))
            {
                Directory.CreateDirectory(Server.MapPath(Folder));
            }

            //判断是否有图片上传
            if (this.fUpImgTitle.FileContent.Length > 0)
            {
                //存储图片的文件夹 页面加载的时候判断该目录 以月份为单位生产图片文件夹
                Folder = Folder + "/" + DateTime.Now.ToString("yyyyMMddhhmmssfffff") + System.IO.Path.GetExtension(this.fUpImgTitle.FileName);
                //上传图片
                this.fUpImgTitle.SaveAs(Server.MapPath(Folder));
                _P_Person.pPhoto = Folder;
            }
            else
            {
                //图片路径
                _P_Person.pPhoto = this.hidimgurl.Value;
            }

            if (!string.IsNullOrEmpty(pId))
            {
                _P_Person.pId = new Guid(pId);
                _PersonBLL.Update(_P_Person);
            }
            else
            {
                _PersonBLL.Add(_P_Person);
            }
            //把该信息的tag保存到p_Tag表
            if (!string.IsNullOrEmpty(this.txtTags.Value))
            {
                //new TagsBLL().Add(this.txtTags.Value, _P_Person.pId, _P_Person.ClassId, Convert.ToInt32(SystemVar.EnumTagType.Person));
            }
            this.ClientScript.RegisterStartupScript(GetType(), "alert", "<script>alert('保存成功！');window.location.href='PersonManage.aspx'</script>", false);
        }

        //下载图片到本地
        private string SaveUrlPics(string strHTML, string path)
        {
            string[] imgurlAry = GetImgTag(strHTML);
            try
            {
                for (int i = 0; i < imgurlAry.Length; i++)
                {
                    if (imgurlAry[i].IndexOf("www.alihaoche.com") < 0 || imgurlAry[i].IndexOf("../../UpFile/Head/") < 0)
                    {

                        //WebRequest req = WebRequest.Create(imgurlAry[i]);
                        string fileName = DateTime.Now.ToString("yyyyMMddhhmmssfffff").Substring(0, 17);
                        WebClient wc = new WebClient();
                        if (imgurlAry[i] != "")
                        {
                            wc.DownloadFile(imgurlAry[i], Server.MapPath(path) + "/" + fileName + imgurlAry[i].Substring(imgurlAry[i].LastIndexOf(".")));
                            //替换原图片地址
                            string imgPath = path + "/" + fileName;
                            //ddl.Items.Add(imgPath + "/" + fileName + imgurlAry[i].Substring(imgurlAry[i].LastIndexOf(".")));
                            strHTML = strHTML.Replace(imgurlAry[i], imgPath + imgurlAry[i].Substring(imgurlAry[i].LastIndexOf(".")));
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch
            {
                //return ex.Message;
            }
            return strHTML;
        }

        /// <summary>
        /// 获取图片标志
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <returns></returns>
        public string[] GetImgTag(string htmlStr)
        {
            Regex regObj = new Regex("<img.+?>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            string[] strAry = new string[regObj.Matches(htmlStr).Count];
            int i = 0;
            foreach (Match matchItem in regObj.Matches(htmlStr))
            {
                strAry[i] = GetImgUrl(matchItem.Value);
                i++;
            }
            return strAry;
        }

        /// <summary>
        /// 获取图片URL地址
        /// </summary>
        /// <param name="imgTagStr"></param>
        /// <returns></returns>
        private string GetImgUrl(string imgTagStr)
        {
            string str = "";
            Regex regObj = new Regex("http://.+.(?:jpg|gif|bmp|png)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match matchItem in regObj.Matches(imgTagStr))
            {
                str = matchItem.Value;
            }
            return str;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExists_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtName.Value))
            {
                this.txtName.Value = PageValidateHelper.Filter(this.txtName.Value.Trim());
            }
            DataTable _dt = _PersonBLL.GetBaseList(1, "pCnName like '%" + this.txtName.Value + "%'");
            if (_dt != null && _dt.Rows.Count > 0)
            {
                this.sp_Tip.InnerHtml = "该信息已经存在!";
            }
            else
            {
                this.sp_Tip.InnerHtml = "可以添加!";
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("/Manage/Person/PersonManage.aspx");
        }
    }
}