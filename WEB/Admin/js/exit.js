$(document).ready(function () {
    //页面加载后判断是否登陆
    $.ajax({
        type: "post",
        url: "ashx/exit.ashx",
        dataType: "text",
        success: function (data) {
            alert('成功退出');
            window.location.href = "login.html";//跳转

        },

    });
});
