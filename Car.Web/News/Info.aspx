<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="Car.Web.News.Info" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10,IE=9,IE=8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-title" content="阿里好车">
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <title><%=TitleStr %>_阿里好车</title>
    <meta name="keywords" content="<%=KeyStr %>">
    <meta name="description" content="<%=DescStr %>">
    <link rel="shortcut icon" href="http://www.alihaoche.com/favicon.ico">
    <link rel="stylesheet" id="_common-css" href="http://www.alihaoche.com/res/css/common.css" type="text/css" media="all">
    <link rel="apple-touch-icon" sizes="144x144" href="http://www.alihaoche.com/res/image/icon-144x144.png" />
    <!--[if lt IE 9]><script src="http://www.alihaoche.com/res/js/html5.js"></script><![endif]-->
    <script src="http://www.alihaoche.com/res/js/share.js"></script>
    <link href="http://www.alihaoche.com/res/css/share.css" rel="styleSheet" type="text/css">
</head>
<body class="single single-post postid-<%=nId.ToString() %> single-format-standard" data-navto="news">
    <!--Include Header-->
    <!--#include virtual="../Include/Header.html"-->
    <!--Include Header-->
    <section class="container">
        <div class="content-wrap">
            <div class="content">
                <asp:Repeater ID="rptData" runat="server">
                    <ItemTemplate>
                        <header class="article-header">
                            <input type="hidden" id="hidpages" value="<%#Eval("nContent").ToString().Split(new string[]{"|page|"},StringSplitOptions.RemoveEmptyEntries).Length %>" />
                            <input type="hidden" id="hidcurrpage" value="<%#this.Request.QueryString["pageIndex"]==null?"1":this.Request.QueryString["pageIndex"]%>" />
                            <input type="hidden" id="hidnid" value="<%#Eval("nid") %>" />
                            <h1 class="article-title"><%#Eval("nTitle") %></h1>
                            <div class="article-meta">
                                <time><%#Convert.ToDateTime(Eval("nAddTime")).ToString("yyyy-MM-dd HH:mm") %></time><span class="item">小编：<a href="http://www.alihaoche.com/">阿里好车</a></span>
                                <span class="item">分类：<%#Eval("cbName") %></span>
                                <span class="item post-views">阅读(<%#Eval("nClicks") %>)</span>
                                <span class="item"></span>
                            </div>
                        </header>
                        <article class="article-content">
                            <div class="pagination">
                                <ul>
                                    <%#PrevNextForOneStr %>
                                </ul>
                            </div>
                            <%#Eval("nContent").ToString().IndexOf("|page|")>0?(Eval("nContent").ToString().Split(new string[]{"|page|"},StringSplitOptions.RemoveEmptyEntries)[PageIndex-1]):Eval("ncontent") %>
                            <div class="pagination">
                                <ul>
                                    <%#PrevNextForOneStr %>
                                </ul>
                            </div>
                            <p class="article-tags"><strong>猜你喜欢：</strong><%=TagsStr %></p>
                            <p class="post-copyright">此文由阿里好车编辑，未经允许不得转载：<a href="http://www.alihaoche.com/">阿里好车</a> » <a href="http://www.alihaoche.com/news/">汽车资讯</a> » <a href="http://www.alihaoche.com/news/<%#Eval("nId") %>"><%#Eval("nTitle") %></a></p>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>

                <script>
                    $(document).ready(function () {

                        //页面加载时判断图片大小 如果图片大小大于680px 则宽度自动压缩为680px
                        $(".article-content").find("img").load(function (i) {
                            if (this.width > 680) {
                                this.width = 680;
                            }
                        })
                        if (parseInt($("#hidcurrpage").val()) > 0 && parseInt($("#hidcurrpage").val()) < parseInt($("#hidpages").val())) {
                            //鼠标放到图片上时变成手型
                            $(".article-content").find("img").mouseover(function (i) {
                                this.style.cursor = "pointer";
                            })
                            //鼠标放到图片上时变成手型
                            $(".article-content").find("img").mouseover(function (i) {
                                this.alt = "点击浏览下一页";
                            })
                            //鼠标点击图片时跳转到下一页
                            $(".article-content").find("img").click(function (i) {

                                window.location.href = $("#hidnid").val() + "_" + (parseInt($("#hidcurrpage").val()) + 1);
                            })
                        } else if (parseInt($("#hidpages").val()) == parseInt($("#hidcurrpage").val())) {
                            //回到第一页重新浏览
                            //鼠标放到图片上时变成手型
                            $(".article-content").find("img").mouseover(function (i) {
                                this.style.cursor = "pointer";
                            })
                            //鼠标放到图片上时变成手型
                            $(".article-content").find("img").mouseover(function (i) {
                                this.alt = "点击浏览频道页面";
                            })
                            //鼠标点击图片时跳转到下一页
                            $(".article-content").find("img").click(function (i) {

                                //浏览该频道 页面
                                //window.location.href=$("#hidnid").val()+".html";
                                window.location.href = (window.location.href.split("/" + $("#hidnid").val())[0] + "/");
                            })
                        }
                    })

                </script>
                <div class="article-social">
                    <a href="javascript:;" class="action action-like" data-pid="<%=this.Request.QueryString["id"].ToString() %>" evt="like" evttype="news"><i class="glyphicon glyphicon-thumbs-up"></i>我觉得很赞 (<span><%=TotalZan %></span>)</a>
                    <div class="action-share bdsharebuttonbox bdshare-button-style0-24" data-bd-bind="1419398361060">
                        <strong>分享到：</strong>
                        <a class="bds_qzone" data-cmd="qzone" title="分享到QQ空间"></a><a class="bds_tsina" data-cmd="tsina" title="分享到新浪微博"></a><a class="bds_weixin bdsm" data-cmd="weixin" title="分享到微信"></a><a class="bds_tqq" data-cmd="tqq" title="分享到腾讯微博"></a><a class="bds_sqq bdsm" data-cmd="sqq" title="分享到QQ好友"></a><a class="bds_renren" data-cmd="renren" title="分享到人人网"></a><a class="bds_douban" data-cmd="douban" title="分享到豆瓣网"></a>
                        <span class="bds_count" data-cmd="count" title="累计分享0次">0</span>
                    </div>
                </div>
                <nav class="article-nav">
                    <%=PrevNextArticleStr %>
                </nav>
                <div class="relates">
                    <h3 class="title"><strong>相关推荐</strong></h3>
                    <ul>
                        <asp:Repeater ID="rptRecommend" runat="server">
                            <ItemTemplate>
                                <li><a href="http://www.alihaoche.com/news/<%#Eval("nId") %>">
                                    <img data-src="http://www.alihaoche.com/<%#Eval("nTitlePic").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/news/<%#Eval("nTitlePic").ToString().Replace("../","") %>" alt="<%#Eval("nTitle") %>"><%#Eval("nTitle") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <h3 class="title" id="comments">
                    <strong>评论 <b>1</b></strong>
                </h3>
                <div id="respond" class="no_webshot">
                    <form action="http://www.alihaoche.com/res/action/comment.ashx" method="post" id="commentform">
                        <div class="comt">
                            <div class="comt-title">
                                <img alt="" data-src="http://www.alihaoche.com/res/image/avatar-default.png" class="avatar avatar-50 photo avatar-default" height="50" width="50" src="http://www.alihaoche.com/res/image/avatar-default.png">
                                <p><a id="cancel-comment-reply-link" href="javascript:;">取消</a></p>
                            </div>
                            <div class="comt-box">
                                <textarea placeholder="注意：与本文无关的评论将被清除，你的评论可以很给力！" class="input-block-level comt-area" name="comment" id="comment" cols="100%" rows="3" tabindex="1" onkeydown="if(event.ctrlKey&amp;&amp;event.keyCode==13){document.getElementById(&#39;submit&#39;).click();return false};"></textarea>
                                <div class="comt-ctrl">
                                    <div class="comt-tips">
                                        <input type="hidden" name="comment_post_ID" value="<%=nId.ToString() %>" id="comment_post_ID">
                                        <input type="hidden" name="comment_parent" id="comment_parent" value="0">
                                        <p style="display: none;">
                                            <input type="hidden" id="akismet_comment_nonce" name="akismet_comment_nonce" value="50c3df19be">
                                        </p>
                                        <label for="comment_mail_notify" class="checkbox inline hide" style="padding-top: 0">
                                            <input type="checkbox" name="comment_mail_notify" id="comment_mail_notify" value="comment_mail_notify" checked="checked">有人回复时邮件通知我</label><p style="display: none;"></p>
                                        <div class="comt-tip comt-loading" style="display: none;">评论提交中...</div>
                                        <div class="comt-tip comt-error" style="display: none;">#</div>
                                    </div>
                                    <button type="submit" name="submit" id="submit" tabindex="5">评论</button>
                                    <!-- <span data-type="comment-insert-smilie" class="muted comt-smilie"><i class="icon-thumbs-up icon12"></i> 表情</span> -->
                                </div>
                            </div>
                            <div class="comt-comterinfo" id="comment-author-info">
                                <ul>
                                    <li class="form-inline">
                                        <label class="hide" for="author">昵称</label><input class="ipt" type="text" name="author" id="author" value="" tabindex="2" placeholder="昵称"><span class="text-muted">昵称 (必填)</span></li>
                                    <li class="form-inline">
                                        <label class="hide" for="email">邮箱</label><input class="ipt" type="text" name="email" id="email" value="" tabindex="3" placeholder="邮箱"><span class="text-muted">邮箱 (必填)</span></li>
                                    <li class="form-inline">
                                        <label class="hide" for="url">网址</label><input class="ipt" type="text" name="url" id="url" value="" tabindex="4" placeholder="网址"><span class="text-muted">网址</span></li>
                                </ul>
                            </div>
                        </div>
                        <input type="hidden" value="1" id="comment_type" name="comment_type" />
                    </form>
                </div>
                <div id="postcomments">
                    <ol class="commentlist">
                       <%-- <li class="comment even thread-even depth-1" id="comment-11193"><span class="comt-f">#1</span><div class="comt-avatar">
                            <img alt="" data-src="http://www.alihaoche.com/avatar/80f0a161d84951a8bd6904ceb39d4be2.png" class="avatar avatar-50 photo" height="50" width="50" src="./10个淡化黑眼圈的妙招 夜猫子们快来细细学习吧--阿里好车_files/80f0a161d84951a8bd6904ceb39d4be2.png" style="display: block;">
                        </div>
                            <div class="comt-main" id="div-comment-11193">
                                现在知道咯<div class="comt-meta"><span class="comt-author"><a href="http://www.yingzaidaxue.com/" rel="external nofollow" class="url" target="_blank">赢在大学励志网</a></span><time>12-20</time><a class="comment-reply-link" href="javascript:;" onclick="return addComment.moveForm(&quot;div-comment-11193&quot;, &quot;11193&quot;, &quot;respond&quot;, &quot;<%=nId.ToString() %>&quot;)">回复</a></div>
                            </div>
                        </li>--%>
                        <!-- #comment-## -->
                    </ol>
                    <div class="pagenav">
                    </div>
                </div>
            </div>
        </div>
        <aside class="speedbar-wrap">
            <div class="speedbar">
               <%-- <ul class="speedbar-menu">
                    <li><a target="_blank" href="http://www.alihaoche.com/news/mingxing">明星·资讯</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/news/qiyejia">企业家·资讯</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/news/shehuimingren">社会名人·资讯</a></li>
                    <li><a target="_blank" href="http://www.alihaoche.com/news/wangluohongren">网络红人·资讯</a></li>
                </ul>--%>
                <div class="speedbar-weixin">
                    <h5>微信关注“阿里好车”<br>
                        找名人资料就上阿里好车</h5>
                    <img src="http://www.alihaoche.com/res/image/weixin-qrcode.jpg" alt="微信关注“阿里好车”,找名人资料就上阿里好车">
                </div>
            </div>
        </aside>

        <aside class="sidebar">
            <div class="widget article-social">
                <a href="javascript:;" class="action action-like" data-pid="<%=this.Request.QueryString["id"] %>" evt="like" evttype="news"><i class="glyphicon glyphicon-thumbs-up"></i>可以试试 (<span><%=TotalZan %></span>)</a>
                <div class="action-share bdsharebuttonbox bdshare-button-style0-24" data-bd-bind="1419398361060">
                    <strong>分享到：</strong>
                    <a class="bds_qzone" data-cmd="qzone" title="分享到QQ空间"></a><a class="bds_tsina" data-cmd="tsina" title="分享到新浪微博"></a><a class="bds_weixin bdsm" data-cmd="weixin" title="分享到微信"></a><a class="bds_tqq" data-cmd="tqq" title="分享到腾讯微博"></a><a class="bds_sqq bdsm" data-cmd="sqq" title="分享到QQ好友"></a><a class="bds_renren" data-cmd="renren" title="分享到人人网"></a><a class="bds_douban" data-cmd="douban" title="分享到豆瓣网"></a>
                    <span class="bds_count" data-cmd="count" title="累计分享0次">0</span>
                </div>
            </div>
            <div class="widget widget_ui_viewposts affix-top">
                <h3 class="title"><strong>7天热门</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptHot" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/news/<%#Eval("nId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("nTitlePic").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("nTitlePic").ToString().Replace("../","") %>" alt="<%#Eval("nTitle") %>"><h2><%#Eval("nTitle") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("nAddTime")).ToString("MM-dd HH:mm") %></time><span class="post-views">阅读(<%#Eval("nclicks") %>)</span></p>
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
                            <a href="http://www.alihaoche.com/tag/<%#Server.UrlEncode(Eval("tname").ToString()) %>" title="“<%#Eval("tname") %>”相关文章"><%#Eval("tname") %><%#Convert.ToInt32(Eval("tClicks"))>200?"<span class=\"hot\">H</span>":"" %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <%--<div class="widget widget_ui_posts">
                <h3 class="title"><strong>推荐相册</strong></h3>
                <ul class="posts-xs">
                    <asp:Repeater ID="rptAlbum" runat="server">
                        <ItemTemplate>
                            <li class="item-<%#Container.ItemIndex+1 %>"><a target="_blank" href="http://www.alihaoche.com/album/<%#Eval("aId") %>.html">
                                <img data-src="http://www.alihaoche.com/<%#Eval("aPhoto").ToString().Replace("../","") %>" class="thumb" src="http://www.alihaoche.com/<%#Eval("aPhoto").ToString().Replace("../","") %>" alt="<%#Eval("aName") %>"><h2><%#Eval("aName") %></h2>
                                <p><time><%#Convert.ToDateTime(Eval("aAddTime")).ToString("MM-dd HH:mm") %></time><span class="post-views">阅读(<%#Eval("aclicks") %>)</span></p>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>--%>
        </aside>
        <%=NextForRightStr %>
    </section>

    <!--Footer-->
    <!--#include virtual="../Include/Footer.html"-->
    <!--Footer-->
</body>
</html>
