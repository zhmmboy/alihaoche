<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnswerAdd.aspx.cs" Inherits="Car.Web.Manage.Question.AnswerAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增答案</title>
    <link href="../res/css/style.css" rel="stylesheet" />
    <script src="../res/js/jquery-1.11.1.min.js"></script>
    <script src="../res/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="myTable">
            <table cellpadding="0" cellspacing="0">
                <tr class="hui">
                    <td class="txt">问题
                    </td>
                    <td>
                        <input type="text" id="txtTitle" runat="server" class="addInput"
                            value="" maxlength="100" />
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
                    <th>答案：
                    </th>
                    <td>
                        <textarea id="txtAnswer" rows="3" cols="85" runat="server" class="addInput" style="width: 690px; height: 60px;"></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn_big upFileBtn" Text=" 保 存 " />
                        <asp:Button ID="Button1" runat="server" OnClick="btnBack_Click" CssClass="btn_big upFileBtn" Text=" 返 回 " />
                        <asp:Button ID="btnBack" runat="server" OnClick="btnBackAnswer_Click" CssClass="btn_big upFileBtn" Text=" 查看答案 " />
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
