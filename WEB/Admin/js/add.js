$(document).ready(
    function () {

        //进入ashx判断是否已经登录

        $.ajax({
            type: "post",
            url: "ashx/add.ashx",
            data: { "Action": "Load" },
            dataType: "text",
            success: function (data) {
                //返回类型为text时 要处理一下 
                var json = eval('(' + data + ')');
                if (json.info == 'no') {
                    alert('请先登录');
                    window.location.href = "login.html";
                }
            },

        });


        //在这里写代码
        //找到取消按钮，添加功能：单击是、、1. 弹出一个框
        //2.点击取消。给登录名、密码清空。真实姓名设置为匿名
        $("#btnCancel").click(
            function () {
              //  alert("hello world 哈哈");
                $("#Uname").val("");
                $("#Upwd").val("");
                $("#Ureal").val("匿名");
            });
        //点击注册按钮。获取登录名、密码、真实姓名。用弹出框显示出来。
        $("#btnSub").click(
            function () {

                var name = $("#Uname").val();
                var pwd = $("#Upwd").val();
                var realname = $("#Ureal").val();
                //性别用布尔类型表示
                var adminSex = true;
                var sexCheck = $('input:radio[name="sex"]:checked').val();//得到单选按钮选中项的值
                if (sexCheck == '女') { adminSex = false; }

                //把数据传递到ashx文件里。然后把ashx回传的数据显示出来。
                $.ajax({
                    type: "post",
                    url: "ashx/Add.ashx",
                    data: { "Action":"add","Name": name, "pwd": pwd, "realname": realname, "sex": adminSex },
                    dataType: "text",
                    success: function (data) {

                        var json = eval('(' + data + ')');
                        alert(json.info);
                    },
                });

               // alert(name + "\n" + pwd + "\n" + realname+"\n"+sex);
            });
    });