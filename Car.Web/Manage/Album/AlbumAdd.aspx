<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlbumAdd.aspx.cs" Inherits="Car.Web.Manage.Album.AlbumAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增相册</title>
    <link href="../res/css/style.css" rel="stylesheet" />
    <script src="../res/js/jquery-1.11.1.min.js"></script>
    <script src="../res/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="myTable">
            <table cellpadding="0" cellspacing="0">
                <tr class="hui">
                    <td class="txt">相册名称
                    </td>
                    <td>
                        <input type="text" id="txtNTitle" runat="server" class="addInput"
                            value="" maxlength="100" />
                        （100个字符以内）
                        <asp:Button ID="btnExists" runat="server" CssClass="btn_big upFileBtn" OnClick="btnExists_Click" Text="检测是否存在" />
                        <span id="sp_Tip" runat="server" style="color: red"></span>
                    </td>
                </tr>
                <tr>
                    <td class="txt">所属：
                    </td>
                    <td>
                        <input type="hidden" id="hidPersonId" runat="server" />
                        <select id="selPerson" runat="server" class="ddlInputCss">
                            <option>请选择</option>
                        </select>
                    </td>
                </tr> <tr>
                    <td class="txt">所属分类：
                    </td>
                    <td>
                         <select id="selClass" runat="server" class="ddlInputCss">
                            <option>请选择</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <th>相册图片：
                    </th>
                    <td>
                        <asp:FileUpload ID="fUpImgTitle" runat="server" />
                        <input type="hidden" id="hidimgurl" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>核心提示：
                    </th>
                    <td>
                        <textarea id="txtIntro" rows="3" cols="85" runat="server" class="addInput" style="width: 690px; height: 60px;"></textarea>
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
