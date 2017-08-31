<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsTempManage.aspx.cs" Inherits="Car.Web.Manage.News.NewsTempManage" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新闻管理</title>
    <link href="../res/css/style.css" rel="stylesheet" />
    <script src="/Manage/res/js/jquery-1.11.1.min.js"></script>
    <script src="../res/My97DatePicker/WdatePicker.js"></script>
    <script>
        $(function () {
            $("input[id='chkId']").click(function () {

                var Id = "";
                $("input[id='chkId']:checked").each(function () {

                    Id += $(this).val() + ",";

                });
                $("#hidId").val(Id.substr(0, Id.length - 1));
            });

            //全选
            $("#chkall").click(function (e) {

                if ($("#chkall").is(":checked")) {
                    $("input[id='chkId']").prop('checked', 'true');
                }
                else {
                    $("input[id='chkId']").removeAttr('checked');
                }
            });

            $("#btnDel").click(function () {

                var Id = "";
                $("input[id='chkId']:checked").each(function () {

                    Id += $(this).val() + ",";

                });
                $("#hidId").val(Id.substr(0, Id.length - 1));
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="search" class="search">
            <table class="searchTable">
                <tr>
                    <td class="txt">分类：</td>
                    <td>
                        <asp:DropDownList ID="ddlCarBrand" runat="server" CssClass="ddlCss">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                        </asp:DropDownList>
                    </td> 
                    <td class="txt">标题：</td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="inputText"></asp:TextBox></td>
                    <td class="txt">状态：</td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="ddlCss">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="1">可用</asp:ListItem>
                            <asp:ListItem Value="2">不可用</asp:ListItem>
                        </asp:DropDownList>
                    </td>
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
                 <input type="checkbox" id="chkall" value="unchecked" />全选               
                <asp:Button ID="btnSet" runat="server" Text="审核" CssClass="btn_big" OnClick="btnSet_Click" />
                <asp:Button ID="btnTransfer" runat="server" Text="转移分类到" CssClass="btn_big" OnClick="btnTransfer_Click" />
                 <select name="selClass" id="selClass" runat="server" class="ddlCss"></select>
                  <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="btn_big" OnClick="btnDel_Click" />
                <a href="/Manage/News/NewsTempAdd.aspx" class="btn_big">+添加</a>
                <input type="hidden" id="hidId" runat="server" />
            </div>
        </div>
        <div id="main_table">
            <asp:GridView ID="gvList" CssClass="cpxinxi" AutoGenerateColumns="False"
                GridLines="None" runat="server" ShowHeaderWhenEmpty="True" EmptyDataText="暂没数据">
                <Columns>
                    <asp:TemplateField HeaderText="图片">
                        <ItemTemplate>
                            <input type="checkbox" id="chkId" value="<%#Eval("nId") %>" />
                            <img src="<%# Eval("nTitlePic")%>" height="60" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="标题">
                        <ItemTemplate>
                            <%# Eval("nTitle")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所属品牌">
                        <ItemTemplate>
                            <%# Eval("cbName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否推荐">
                        <ItemTemplate>
                            <%# Convert.ToBoolean(Eval("nIsRecommand"))?"<font color='green'>推荐</font>":"<font color='red'>不推荐</font>"%>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="是否审核">
                        <ItemTemplate>
                            <%# Convert.ToBoolean(Eval("nStatus"))?"<font color='green'>已审核</font>":"<font color='red'>未审核</font>"%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="添加时间">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("nAddTime")).ToString("yyyy-MM-dd HH:mm")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="/Manage/News/NewsTempAdd.aspx?Id=<%# Eval("nId")%>">编辑</a>
                            <a href="/News/Preview.aspx?Id=<%# Eval("nId")%>" target="_blank">预览</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <webdiyer:AspNetPager ID="pager" runat="server" FirstPageText="首页" LastPageText="末页"
            NextPageText="下一页" PrevPageText="上一页" ShowCustomInfoSection="Never" ShowNavigationToolTip="True"
            SubmitButtonText="转到" textafterinputbox="页" textbeforeinputbox="第" CssClass="fenye"
            HorizontalAlign="Right" AlwaysShow="True" PageSize="100"
            SubmitButtonClass="button" OnPageChanged="pager_PageChanged">
        </webdiyer:AspNetPager>
    </form>
</body>
</html>
