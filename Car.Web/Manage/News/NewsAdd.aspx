<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsAdd.aspx.cs" Inherits="Car.Web.Manage.News.NewsAdd" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="ckeditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新闻新增</title>
    <link href="../res/css/style.css" rel="stylesheet" />
    <script src="/Manage/res/js/jquery-1.11.1.min.js"></script>
    <script src="../res/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="myTable">
            <table cellpadding="0" cellspacing="0">
                <tr class="hui">
                    <td class="txt">文章标题
                    </td>
                    <td>
                        <input type="text" id="txtNTitle" runat="server" class="addInput"
                            value="" maxlength="100" />
                        （100个字符以内）
                        <asp:Button ID="btnExists" runat="server" CssClass="btn_big upFileBtn" OnClick="btnExists_Click" Text="检测是否存在" />
                        <span id="spTip" runat="server" style="color: red"></span>
                    </td>
                </tr>
                   <tr class="hui">
                    <td class="txt">SEO文章标题
                    </td>
                    <td>
                        <input type="text" id="txtNTitleSeo" runat="server" class="addInput"
                            value="" maxlength="100" />
                        （100个字符以内）
                        <asp:Button ID="btnExistsSeo" runat="server" CssClass="btn_big upFileBtn" OnClick="btnExistsSeo_Click" Text="检测是否存在" />
                        <span id="spTipSeo" runat="server" style="color: red"></span>
                    </td>
                </tr>
                <tr>
                    <th>文章来源
                    </th>
                    <td>
                        <input type="text" id="txtnFrom" runat="server" class="addInput"
                            value="阿里好车" onclick="this.select();" maxlength="30" onfocus="if(this.value=='阿里好车')this.value=''"
                            onblur="if(this.value=='')this.value='阿里好车'" />
                        <span>转载请注明出处，尊重他人劳动成果。</span>
                    </td>
                </tr>
                <tr>
                    <th>文章来源Url
                    </th>
                    <td>
                        <input type="text" id="txtnFromUrl" runat="server" class="addInput" />
                        <span>转载请注明出处，尊重他人劳动成果。</span>
                    </td>
                </tr>
                <tr>
                    <th>标题图片：
                    </th>
                    <td>
                        <asp:FileUpload ID="fUpImgTitle" runat="server" />
                        <input type="hidden" id="hidimgurl" runat="server" />
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
                </tr><tr>
                    <td class="txt">所属车型：
                    </td>
                    <td>
                        <input type="hidden" id="hidPersonId" runat="server" />
                        <select id="selCar" runat="server" class="ddlInputCss">
                            <option>请选择</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <th>是否推荐：
                    </th>
                    <td>
                        <asp:CheckBox ID="chkRecommand" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>核心提示：
                    </th>
                    <td>
                        <textarea id="txtTip" rows="3" cols="85" runat="server" class="addInput" style="width: 690px; height: 60px;"></textarea>
                    </td>
                </tr>
                <tr class="hui">
                    <th class="valign">文章内容
                    </th>
                    <td>

                        <ckeditor:CKEditorControl runat="server" ID="txtContent" BasePath="~/ckeditor" Width="700px" Height="400px" ToolbarFull="Copy|Paste|PasteText|
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
                    <th>关键词
                    </th>
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
