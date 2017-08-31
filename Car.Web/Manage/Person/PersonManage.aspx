<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonManage.aspx.cs" Inherits="Car.Web.Manage.Person.PersonManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>名人信息管理</title>
    <link href="../res/css/style.css" rel="stylesheet" />
    <script src="/Manage/res/js/jquery-1.11.1.min.js"></script>
    <script src="../res/My97DatePicker/WdatePicker.js"></script>
    <script>
        $(function () {
            $("input[id='chkId']").click(function () {

                var Id="";
                $("input[id='chkId']:checked").each(function () {

                    Id += $(this).val()+",";

                });
                $("#hidId").val(Id.substr(0,Id.length-1));
            });
        })


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="search" class="search">
            <table class="searchTable">
                <tr>
                    <td class="txt">所属分类：</td>
                    <td>
                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="ddlCss">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                        </asp:DropDownList>
                    </td><td class="txt">状态：</td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="ddlCss">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                             <asp:ListItem Value="1">可用</asp:ListItem>
                             <asp:ListItem Value="2">不可用</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="txt">姓名：</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="inputText"></asp:TextBox></td>

                    <td class="txt">添加时间：</td>
                    <td>
                        <asp:TextBox ID="txtRegStartDate" runat="server" onfocus="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd HH:mm',maxDate:'#F{$dp.$D(\'txtRegEndDate\')}'})" CssClass="inputText"></asp:TextBox></td>
                    <td>-</td>
                    <td>
                        <asp:TextBox ID="txtRegEndDate" runat="server" onfocus="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd HH:mm',minDate:'#F{$dp.$D(\'txtRegStartDate\')}'})" CssClass="inputText"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="btnSelect" runat="server" CssClass="btn_big" Text="搜索" OnClick="btnSelect_Click" />
                    </td>
                </tr>
            </table>
            <div class="QuesAdd">
                <input type="hidden" id="hidId" value="" runat="server" />
                <a href="/Manage/Person/PersonAdd.aspx" class="btn_big">+添加</a>
                <select id="selStatus" runat="server" class="ddlCss"><option value="1">可用</option><option value="2">不可用</option></select>
                <asp:Button ID="btnSet" runat="server" Text="设置状态" CssClass="btn_big" OnClick="btnSet_Click" />
            </div>
        </div>
        <div id="main_table">
            <asp:GridView ID="gvList" CssClass="cpxinxi" AutoGenerateColumns="False"
                GridLines="None" runat="server" ShowHeaderWhenEmpty="True" EmptyDataText="暂没数据">
                <Columns>
                    <asp:TemplateField HeaderText="头像">
                        <ItemTemplate>
                         <input type="checkbox" id="chkId" value="<%#Eval("pId") %>" /> <img src="<%# Eval("pPhoto")%>" height="60" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                            <%# Eval("pCnName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="性别">
                        <ItemTemplate>
                            <%# Convert.ToBoolean(Eval("pSex"))?"男":"女"%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="职业">
                        <ItemTemplate>
                            <%# Eval("pJob")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所属分类">
                        <ItemTemplate>
                            <%# Eval("cName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="添加时间">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("pAddTime")).ToString("yyyy-MM-dd HH:mm")%>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%# Convert.ToInt32(Eval("pStatus"))==1?"可用":"不可用"%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="/Manage/Person/PersonAdd.aspx?Id=<%# Eval("pId")%>">编辑</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <webdiyer:AspNetPager ID="pager" runat="server" FirstPageText="首页" LastPageText="末页"
            NextPageText="下一页" PrevPageText="上一页" ShowCustomInfoSection="Never" ShowNavigationToolTip="True"
            SubmitButtonText="转到" textafterinputbox="页" textbeforeinputbox="第" CssClass="fenye"
            HorizontalAlign="Right" AlwaysShow="True" PageSize="6"
            SubmitButtonClass="button" OnPageChanged="pager_PageChanged">
        </webdiyer:AspNetPager>
    </form>
</body>
</html>
