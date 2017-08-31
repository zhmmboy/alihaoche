var _width = null, _height = null;
var isHome = true;

$(function () {
    _width = $(window).width(), _height = $(window).height(); //获取window宽高

    for (var i = 0; i < menuJson.length; i++) {
        $("#Backstage .one_menu ul").append("<li style='background-position:" + menuJson[i].one_x + "px " + menuJson[i].one_y + "px'>" + menuJson[i].one_menu + "</li>");

    }

    menu(0, 0);//默认选择首页


    var rsecordIndex = 0;//记录上次的索引
    $("#Backstage .one_menu ul li").bind("click", function () {
        var index = $("#Backstage .one_menu ul li").index($(this));
        $("#Backstage .two_menu ul").html("");

        menu(index, rsecordIndex);
        init();//选中首页页面自适应重新加载

        $("#Backstage .two_menu ul li").bind("click", function () {
            var bt = $("#Backstage .two_menu ul li");
            var indexBt = bt.index($(this));
            var url = bt.eq(indexBt).attr("data-url");
            bt.css({ "background-color": "#f1f1f1", "border-bottom": "3px solid #32323a" });
            bt.eq(indexBt).css({ "background-color": "#ceffff", "border-bottom": "3px solid #00a5a5" });

            $("#Backstage .Route").text("您当前的位置:" + menuJson[index].one_menu + " > " + menuJson[index].two[indexBt].menu); //改变路径

            $("#Backstage .main_ifr iframe").attr("src", url);
        });
        $("#Backstage .two_menu ul li").eq(0).click();
        if (index == rsecordIndex) return;
        rsecordIndex = index;
    });


    init();
    //退出管理系统
    $("#Backstage .topBackExit").bind("click", function () {
        console.log("退出系统");
    });


});

//首页调用方法修改菜单焦点
function homeClickUrl(one, two) {
    $("#Backstage .one_menu ul li").eq(one).click();
    $("#Backstage .two_menu ul li").eq(two).click();

}

function menu(index, rsecordIndex) {
    console.log(index, rsecordIndex);
    $("#Backstage .one_menu ul li").eq(rsecordIndex).css({ "background-color": "" });
    $("#Backstage .one_menu ul li").eq(index).css({ "background-color": "#00a5a5" });
    if (menuJson[index].two.length == 0) {
        isHome = false;
        $("#Backstage .main_ifr iframe").attr("src", "home.html"); //显示首页
        $("#Backstage .Route").text("您当前的位置:" + menuJson[index].one_menu); //改变路径
        $("#Backstage .two_menu").hide();
    } else {
        isHome = true;
        $("#Backstage .two_menu").show();
    }
    for (var j = 0; j < menuJson[index].two.length; j++) {
        $("#Backstage .two_menu ul").append("<li data-url='" + menuJson[index].two[j].url + "'>" + menuJson[index].two[j].menu + "</li>");
    }
}


//窗体大小改变
$(window).resize(function () {
    _width = $(window).width(), _height = $(window).height(); //获取window宽高
    init(); //头部中间自适应
});

function init() {
    var menuWidth = $("#Backstage .menuLeft").width();
    $("#Backstage .topBackCenter").width(_width - 570); //头部中间背景自适应

    $("#Backstage .menu").height(_height - 81 - 30); //菜单左边高度
    $("#Backstage .menuLeft,#Backstage .menuRight").height(_height - 81 - 30); //菜单左边高度

    $("#Backstage .menuRight").width(_width - menuWidth); //菜单路径
    $("#Backstage .menuRight .two_menu").width(_width - (menuWidth + 15));
    $("#Backstage .menuRight .main_ifr").width(_width - (menuWidth + 16));
    if (isHome) {
        $("#Backstage .main_ifr").height(_height - 191);
    } else {
        $("#Backstage .main_ifr").height(_height - 151);
    }
}