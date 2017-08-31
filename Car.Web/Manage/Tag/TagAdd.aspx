<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TagAdd.aspx.cs" Inherits="Car.Web.Manage.Tag.TagAdd" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="ckeditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>标签新增</title>
    <link href="../res/css/style.css" rel="stylesheet" />
    <script src="/Manage/res/js/jquery-1.11.1.min.js"></script>
    <script src="../res/My97DatePicker/WdatePicker.js"></script>
    <script src="../res/js/sysData.js"></script>

    <script>
        $(function () {

            createNationSelect("", "汉族");

        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="myTable">
            <table>
                <tr>
                    <td class="txt">头像：
                    </td>
                    <td>
                        <asp:FileUpload ID="fUpImgTitle" runat="server" CssClass="addInput" />
                        <input type="hidden" id="hidimgurl" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">姓名：
                    </td>
                    <td>
                        <input type="text" id="txtName" runat="server" class="addInput"
                            value="" maxlength="100" />
                        （100个字符以内）
                        <asp:Button ID="btnExists" runat="server" CssClass="btn_big upFileBtn" OnClick="btnExists_Click" Text="检测是否存在" />
                        <span id="sp_Tip" runat="server" style="color: red"></span>
                    </td>
                </tr>
                <tr>
                    <td class="txt">性别：
                    </td>
                    <td>
                        <input type="radio" id="rdoSex" runat="server" name="sex" />男
                        <input type="radio" id="rodSex2" runat="server" name="sex" />女
                    </td>
                </tr>
                <tr>
                    <td class="txt">英文姓名
                    </td>
                    <td>
                        <input type="text" id="txtEnName" runat="server" class="addInput"
                            value="" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">笔名（艺名）
                    </td>
                    <td>
                        <input type="text" id="txtPenName" runat="server" class="addInput"
                            value="" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">国籍：
                    </td>
                    <td>
                        <select id="selNationality" runat="server" class="ddlInputCss">
                            <option>中国</option>
                            <option>中国香港</option>
                            <option>中国澳门</option>
                            <option>中国台湾</option>
                            <option>美国</option>
                            <option>日本</option>
                            <option>韩国</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="txt">名族：
                    </td>
                    <td>
                        <select id="selNation" runat="server" class="ddlInputCss">
                            <option>请选择</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="txt">身高：
                    </td>
                    <td>
                        <input type="text" id="txtHeight" runat="server" class="addInput"
                            value="0" maxlength="100" />
                        CM
                    </td>
                </tr>
                <tr>
                    <td class="txt">体重：
                    </td>
                    <td>
                        <input type="text" id="txtWeight" runat="server" class="addInput"
                            value="0" maxlength="100" />
                        KG
                    </td>
                </tr>
                <tr>
                    <td class="txt">生日：
                    </td>
                    <td>
                        <input type="text" id="txtBirthday" runat="server" class="addInput"
                            value="" maxlength="100" onfocus="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd HH:mm'})" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">三围：
                    </td>
                    <td>
                        <input type="text" id="txtBWH" runat="server" class="addInput"
                            value="" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">毕业学校：
                    </td>
                    <td>
                        <input type="text" id="txtUniversity" runat="server" class="addInput"
                            value="" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">祖籍：
                    </td>
                    <td>
                        <input type="text" id="txtHomePlace" runat="server" class="addInput"
                            value="" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">现居地：
                    </td>
                    <td>
                        <input type="text" id="txtNowPlace" runat="server" class="addInput"
                            value="" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">职业：
                    </td>
                    <td>
                        <input type="text" id="txtJob" runat="server" class="addInput"
                            value="" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">血型：
                    </td>
                    <td>
                        <select id="selBloodType" runat="server" class="ddlInputCss">
                            <option>请选择</option>
                            <option>A</option>
                            <option>B</option>
                            <option>AB</option>
                            <option>O</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="txt">口头禅：
                    </td>
                    <td>
                        <input type="text" id="txtSpeak" runat="server" class="addInput"
                            value="" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">新浪blog：
                    </td>
                    <td>
                        <input type="text" id="txtSinaBlog" runat="server" class="addInput"
                            value="" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">腾讯blog：
                    </td>
                    <td>
                        <input type="text" id="txtTencentBlog" runat="server" class="addInput"
                            value="" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">个人网站：
                    </td>
                    <td>
                        <input type="text" id="txtHomePage" runat="server" class="addInput"
                            value="" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td class="txt">所属分类：
                    </td>
                    <td>
                        <select id="selClass" runat="server" class="ddlInputCss">
                            <option>请选择</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="txt">简介：
                    </td>
                    <td>
                        <textarea id="txtTips" rows="3" cols="85" runat="server" class="addInput" style="width: 690px; height: 60px;"></textarea>
                    </td>
                </tr>
                <tr class="hui">
                    <td class="txt">详细介绍：
                    </td>
                    <td>

                        <ckeditor:CKEditorControl runat="server" ID="txtContent" Width="700px" Height="400px" ToolbarFull="Copy|Paste|PasteText|
Undo|Redo|-|Find|-|RemoveFormat
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent
JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock
Styles|Format|Font|FontSize
TextColor|BGColor
Image|Table|HorizontalRule|SpecialChar
Link|Unlink
Maximize">
                        </ckeditor:CKEditorControl>

                    </td>
                </tr>
                <tr>
                    <td class="txt">关键词：
                    </td>
                    <td>
                        <input type="text" id="txtNTags" runat="server" class="addInput"
                            value="请用 空格 分割" onfocus="if($(this).val()=='请用 空格 分割'){$(this).val('');}"
                            onblur="if($(this).val()==''){$(this).val('请用 空格 分割');}" style="width: 560px" />
                        <input type="checkbox" id="article_deny_review" /><label for="article_deny_review">
                            <span>不允许评论本文</span></label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn_big upFileBtn" Text=" 保 存 " />
                        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" CssClass="btn_big upFileBtn" Text=" 返 回 " />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
