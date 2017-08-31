<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlbumManage.aspx.cs" Inherits="Car.Web.Manage.Album.AlbumManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>相册管理</title>
    <link href="../res/css/style.css" rel="stylesheet" />
    <script src="/Manage/res/js/jquery-1.11.1.min.js"></script>
    <script src="../res/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="search" class="search">
            <table class="searchTable">
                <tr>
                    <td class="txt">所属分类：</td>
                    <td>
                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="ddlCss">
                            <asp:ListItem Value="-1">请选择</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td class="txt">相册名称：</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="inputText"></asp:TextBox></td>
                    <td></td>
                    <td></td>

                    <td class="txt">添加时间：</td>
                    <td>
                        <asp:TextBox ID="txtRegStartDate" runat="server" onfocus="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd HH:mm',maxDate:'#F{$dp.$D(\'txtRegEndDate\')}'})" CssClass="inputText"></asp:TextBox></td>
                    <td>-</td>
                    <td>
                        <asp:TextBox ID="txtRegEndDate" runat="server" onfocus="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd HH:mm',minDate:'#F{$dp.$D(\'txtRegStartDate\')}'})" CssClass="inputText"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="btnSelect" runat="server" CssClass="btn_big" Text="搜索" OnClick="btnSelect_Click" />
                    </td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <div class="QuesAdd">
                <a href="/Manage/News/NewsAdd.aspx" class="btn_big">+添加</a>
            </div>
        </div>
        <div id="main_table">
            <asp:GridView ID="gvList" CssClass="cpxinxi" AutoGenerateColumns="False"
                GridLines="None" runat="server" ShowHeaderWhenEmpty="True" EmptyDataText="暂没数据">
                <Columns>
                    <asp:TemplateField HeaderText="相册封面">
                        <ItemTemplate>
                            <a href="AlbumInfoManage.aspx?Id=<%#Eval("aId") %>"><img src="<%# Eval("aPhoto")%>" width="150" /></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="相册名称">
                        <ItemTemplate>
                            <%# Eval("aName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所属名人">
                        <ItemTemplate>
                            <%# Eval("pCnName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="添加时间">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("aAddTime")).ToString("yyyy-MM-dd HH:mm")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="标签">
                        <ItemTemplate>
                            <%# Eval("aTags")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="/Manage/Album/AlbumAdd.aspx?Id=<%# Eval("aId")%>">编辑</a>
                            <a href="/Manage/Album/AlbumManage.aspx?Id=<%# Eval("aId")%>&action=del">删除</a>
                            <a href="/Manage/Album/AlbumInfoAdd.aspx?Id=<%# Eval("aId")%>">上传</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <webdiyer:AspNetPager ID="pager" runat="server" FirstPageText="首页" LastPageText="末页"
            NextPageText="下一页" PrevPageText="上一页" ShowCustomInfoSection="Never" ShowNavigationToolTip="True"
            SubmitButtonText="转到" textafterinputbox="页" textbeforeinputbox="第" CssClass="fenye"
            HorizontalAlign="Right" AlwaysShow="True" PageSize="10"
            SubmitButtonClass="button" OnPageChanged="pager_PageChanged">
        </webdiyer:AspNetPager>
    </form>
</body>
</html>
