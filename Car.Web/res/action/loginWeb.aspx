<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginWeb.aspx.cs" Inherits="Car.Web.res.action.loginWeb" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <meta content="IE=5.0000" http-equiv="X-UA-Compatible">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="GENERATOR" content="MSHTML 10.00.9200.17183">
</head>
<body>
    <div tabindex="-1" class="modal fade" id="modal-login" role="dialog"
        aria-hidden="true">
        <div class="modal-dialog" style="width: 480px; margin-top: 200px;">
            <div class="modal-content">
                <div class="modal-header">
                    <button class="close" aria-hidden="true" type="button"
                        data-dismiss="modal">
                        ×</button>
                    <h4 class="modal-title">登录或注册</h4>
                </div>
                <div class="modal-body">
                    <div class="login-form">
                        <form class="login-item hide" id="login-item-login">
                            <h5><small evt="login.to.reg"><span
                                class="glyphicon glyphicon-share-alt"></span>注册</small>登录</h5>
                            <h6>
                                <label for="inputEmail">邮箱</label>
                                <input name="email"
                                    class="form-control" id="inputEmail" type="email" placeholder="登录邮箱" value="">
                            </h6>
                            <h6>
                                <label for="inputPassword">密码</label>
                                <input
                                    name="password" class="form-control" id="inputPassword" type="password"
                                    placeholder="登录密码" value="">
                            </h6>
                            <div class="login-submit">
                                <input name="submit" class="btn" type="button" value="登录" evt="login.submit">
                                <input name="action" type="hidden" value="signin">
                                <label>
                                    <input name="remember" type="checkbox"
                                        checked="checked" value="forever">记住我</label>
                            </div>
                        </form>
                        <form class="login-item hide" id="login-item-reg">
                            <h5><small evt="login.to.login"><span
                                class="  glyphicon glyphicon-share-alt"></span>登录</small>注册</h5>
                            <h6>
                                <label for="inputName">昵称</label>
                                <input name="name"
                                    class="form-control" id="inputName" type="text" placeholder="设置昵称" value="">
                            </h6>
                            <h6>
                                <label for="inputEmail">邮箱</label>
                                <input name="email"
                                    class="form-control" id="Email1" type="email" placeholder="邮箱" value="">
                            </h6>
                            <h6>
                                <label for="inputPassword">密码</label>
                                <input name="password"
                                    class="form-control" id="Password1" type="password" placeholder="设置登录密码"
                                    value="">
                            </h6>
                            <div class="login-submit">
                                <input name="submit" class="btn" type="button" value="快速注册" evt="login.submit">
                                <input name="action" type="hidden" value="signup">
                            </div>
                        </form>
                        <div class="login-tips"></div>
                        <div class="login-other">
                            <h5>其他登录方式</h5>
                            <a class="login-qq"
                                href="http://www.alihaoche.com/oauth/qq">QQ账号登录</a>                         <a
                                    class="login-weibo" href="http://www.alihaoche.com/oauth/weibo">微博账号登录</a>

                            <ul>
                                <!-- <li><a href="#">找回密码(开发中)</a></li> 
                                <li><a
                                    href="http://www.alihaoche.com/readers">30天读者排行榜</a></li>-->
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
