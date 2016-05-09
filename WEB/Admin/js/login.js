$(document).ready(function () {
    //注册提交按钮单击事件
    $("#login").click(function () {

        var txtUserName = $("#txtLoginName").val(); //获取文本框的值
        var txtPassWord = $("#txtLoginPWD").val();

        if ("" != txtUserName && "" != txtPassWord) {   //简单的验证放在客户端，减少服务器压力
            //利用post方式向服务器请求数据 
            $.ajax({
                type: "Post",
                url: "ashx/LOGIN.ashx",
                //方法传参的写法一定要对，UserName为形参的名字,PassWord为第二个形参的名字   
                data: { "UserName": txtUserName, "PassWord": txtPassWord },
                dataType: "text",
                success: function (data) {
                    //返回类型为text时 要处理一下 
                    var json = eval('(' + data + ')');
                    //   $("#result").val(json); 
                    alert(json.info + " 编号为：" + json.ID);
                    
                    //window.location.href = "index.html";//页面跳转
                    window.history.go(-1);
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
        else {
            alert("输入非法！");

        }
    });

});
