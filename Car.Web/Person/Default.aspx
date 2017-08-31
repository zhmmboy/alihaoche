<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Car.Web.Person.Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10,IE=9,IE=8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-title" content="阿里好车">
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <title>明星资料大全_企业家名录_社会名人资料_网络红人资料_阿里好车</title>
    <meta name="keywords" content="明星资料大全、企业家名录、社会名人资料、网络红人资料、草根达人">
    <meta name="description" content="收集并分享全球明星资料大全、企业家名录、社会名人资料、网络红人资料。">
    <link rel="shortcut icon" href="http://www.alihaoche.com/favicon.ico">
    <link rel="stylesheet" id="_common-css" href="http://www.alihaoche.com/res/css/common.css" type="text/css" media="all">
    <link rel="apple-touch-icon" sizes="144x144" href="http://www.alihaoche.com/res/image/icon-144x144.png" />
    <!--[if lt IE 9]><script src="http://www.alihaoche.com/res/js/html5.js"></script><![endif]-->
</head>
<body class="home blog" data-navto="person">
    <!--Include Header-->
    <!--#include virtual="../Include/Header.html"-->
    <!--Include Header-->
    <section class="container">
        <div class="content-wrap">
            <div class="content excerpts">
                <h3 class="title"><small class="pull-right">共收录：<%=totalCount %> 篇 档案·资料。 </small><strong>最新发布</strong></h3>
                <asp:Repeater ID="rptData" runat="server">
                    <ItemTemplate>
                        <article class="excerpt">
                            <a target="_blank" class="thumbnail" href="http://www.alihaoche.com/person/<%#Eval("pId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" alt="<%#Eval("pCnName") %>:<%#Eval("pTips") %>" style="display: inline;"></a><h2><a target="_blank" href="http://www.alihaoche.com/person/<%#Eval("pid") %>.html" title="<%#Eval("pCnName") %>:<%#Eval("pJob") %>"><%#Eval("pCnName") %></a></h2>
                            <p class="note"><%#Eval("pTips") %></p>
                            <footer><time>分类：[<%#Eval("cName") %>]</time>/<time>&nbsp;&nbsp;<%#Convert.ToDateTime(Eval("pAddTime")).ToString("MM-dd HH:mm") %></time>/<a href="javascript:;" class="post-like" data-pid="<%#Eval("pid") %>" evt="like" evttype="person"><i class="glyphicon glyphicon-thumbs-up"></i>我喜欢 (<span><%#Eval("pFans") %></span>)</a><span class="post-views">阅读(<%#Eval("pClicks") %>)</span></footer>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="pagination">
                    <ul>
                        <%=pageStr %>
                    </ul>
                </div>
            </div>
        </div>
        <aside class="speedbar-wrap">
            <div class="speedbar">
               <%-- <ul class="speedbar-menu">
                    <li><a target="_blank" href="http://www.alihaoche.com/person/mingxing">明星·档案</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/person/qiyejia">企业家·档案</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/person/shehuimingren">社会名人·档案</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/person/wangluohongren">网络红人·档案</a></li>
                </ul>--%>
                <div class="speedbar-weixin">
                    <h5>微信关注“阿里好车”<br>
                        找名人资料就上阿里好车</h5>
                    <img src="http://www.alihaoche.com/res/image/weixin-qrcode.jpg" alt="微信关注“阿里好车”,找名人资料就上阿里好车！">
                </div>
            </div>
        </aside>
        <aside class="sidebar">
            <div class="widget widget_ui_viewposts affix-top">
                <h3 class="title"><strong>7天热门</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptHot" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/person/<%#Eval("pId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" alt="<%#Eval("pCnName") %>:<%#Eval("pJob") %>"><h2><%#Eval("pCnName") %></h2>
                                <p>
                                    <%#Eval("pTips") %><br />
                                    <time><%#Convert.ToDateTime(Eval("pAddTime")).ToString("MM-dd HH:mm") %></time><span class="post-views">阅读(<%#Eval("pclicks") %>)</span>
                                </p>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="widget widget_ui_tags">
                <h3 class="title"><strong>热门话题</strong></h3>
                <div class="items">
                    <asp:Repeater ID="rptTag" runat="server">
                        <ItemTemplate>
                            <a href="http://www.alihaoche.com/person/tag/<%#Server.UrlEncode(Eval("tName").ToString()) %>_1.html" title="“<%#Eval("tName") %>”相关文章"><%#Eval("tName") %><%#Convert.ToInt32(Eval("tClicks"))>200?"<span class=\"hot\">H</span>":"" %> </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="widget widget_ui_posts">
                <h3 class="title"><strong>网友留言</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptQuestion" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/question/<%#Eval("qId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../../","") %>" alt="<%#Eval("qTitle") %>"><h2><%#Eval("qTitle") %></h2>
                                <p><%#Eval("qIntro") %><br /><time><%#Convert.ToDateTime(Eval("qAddTime")).ToString("MM-dd HH:mm") %></time><span class="post-views">阅读(<%#Eval("qClicks") %>)</span></p>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </aside>
    </section>
    <!--Footer-->
    <!--#include virtual="../Include/Footer.html"-->
    <!--Footer-->
</body>
</html>
