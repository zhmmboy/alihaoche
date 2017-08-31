<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Car.Web.Question.Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10,IE=9,IE=8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-title" content="阿里好车">
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <title>明星_企业家_社会名人_网络红人_话题_辩论_疑问_阿里好车</title>
    <meta name="keywords" content="明星、企业家、社会名人、网络红人、话题、辩论、疑问">
    <meta name="description" content="收集并分享全球明星、企业家、社会名人、网络红人、话题、辩论，解答、疑问。">
    <link rel="shortcut icon" href="http://www.alihaoche.com/favicon.ico">
    <link rel="stylesheet" id="_common-css" href="http://www.alihaoche.com/res/css/common.css" type="text/css" media="all">
    <link rel="apple-touch-icon" sizes="144x144" href="http://www.alihaoche.com/res/image/icon-144x144.png">
    <!--[if lt IE 9]><script src="http://www.alihaoche.com/res/js/html5.js"></script><![endif]-->
</head>
<body class="home blog" data-navto="question">
    <!--Include Header-->
    <!--#include virtual="../Include/Header.html"-->
    <!--Include Header-->
    <section class="container">
        <div class="content-wrap">
            <div class="content excerpts">
                <h3 class="title"><small class="pull-right">共收录：<%=totalCount %> 篇 互动·问答。</small><strong>最新发布</strong></h3>
                <asp:Repeater ID="rptData" runat="server">
                    <ItemTemplate>
                        <article class="excerpt-question">
                            <h2><a target="_blank" href="http://www.alihaoche.com/question/<%#Eval("qId") %>.html"><%#Eval("qTitle") %></a></h2>
                            <p class="note"><%#Eval("qIntro") %></p>
                            <footer><time><%#Convert.ToDateTime(Eval("qAddTime")).ToString("yyyy-MM-dd HH:mm:ss") %></time>/<span class="post-views">阅读(<%#Eval("qClicks") %>)</span>/<span class="post-views">赞数(<%#Eval("qGood") %>)</span></footer>
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
              <%--  <ul class="speedbar-menu">
                    <li><a target="_blank" href="http://www.alihaoche.com/question/week.html">7天热门排行</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/question/month.html">30天热门排行</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/question/zan.html">点赞热门</a></li>
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
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/question/<%#Eval("qId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("./.","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("./.","") %>" style="display: block;" alt="<%#Eval("qTitle") %>"><h2><%#Eval("qTitle") %></h2>
                                <p> <%#Eval("qIntro") %><br /><time><%#Convert.ToDateTime(Eval("qAddTime")).ToString("MM-dd") %></time><span class="post-views">阅读(<%#Eval("qClicks") %>)</span></p>
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
                            <a href="http://www.alihaoche.com/question/tag/<%#Server.UrlEncode(Eval("tName").ToString()) %>_1.html" title="“<%#Eval("tName") %>”相关文章"><%#Eval("tName") %><%#Convert.ToInt32(Eval("tClicks"))>200?"<span class=\"hot\">H</span>":"" %> </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="widget widget_ui_posts">
                <h3 class="title"><strong>特别推荐</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptRecommend" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/person/<%#Eval("pId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("pPhoto").ToString().Replace("../","") %>" style="display: block;" alt="<%#Eval("pCnName") %>:<%#Eval("pJob") %>"><h2><%#Eval("pCnName") %></h2>
                                <p><%#Eval("pTips") %><br /><time><%#Convert.ToDateTime(Eval("pAddTime")).ToString("MM-dd") %></time><span class="post-views">阅读(<%#Eval("pClicks") %>)</span></p>
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
