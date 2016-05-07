//$(document).ready(
    
//    function () {
        
//        $("#btnSub").click(
//                       function yanzheng() {
//                           var meg = "";//设置返回的结果
//                           if (form1.UserName.value.length > 15) {
//                               meg += "输入的姓名长度大于15个字节" + "\n";
//                           }
//                           var patrn = /[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?/;
//                           if (!patrn.exec(form1.UserEmail.value)) {
//                               meg += "请正确输入邮箱" + "\n";
//                           }
//                           if (form1.UserBirthday.value.length != 8) {
//                               meg += "请输入8位生日，如19980101" + "\n";
//                           }
//                           if (form1.UserPwd.value == "") {
//                               meg += "密码不能为空" + "\n";
//                           }

//                           if (meg.length > 0) {
//                               alert(meg);
//                               return false;
//                           }
//                           else {
//                               go();
//                           }
//                       }
//          );

//        //点击注册按钮。获取登录名、密码、真实姓名。用弹出框显示出来。
//        function go() {
//            //判断是否是管理员
//            var Ustate = $('input:radio[name="Admin"]:checked').val();
//            if (Ustate != '1') {
//                //进入ashx判断是否已经登录
//                $.ajax({
//                    type: "post",
//                    url: "ashx/NewUser.ashx",
//                    data: { "Action": "Load" },
//                    dataType: "text",
//                    success: function (data) {
//                        //返回类型为text时 要处理一下 
//                        var json = eval('(' + data + ')');
//                        if (json.info == 'no') {
//                            alert('注册管理员请先联系管理员');
//                            window.history.go(-1);
//                        }
//                        else {
//                            setuser();
//                        }
//                    }

//                });
//            }//判断是否是管理员登录
//            else {
//                setuser();
//            }
            
//        };
//        function setuser() {

//            var Ustate = $('input:radio[name="Admin"]:checked').val();
//            var name = $("#UserName").val();
//            var pwd = $("#UserPwd").val();
//            var email = $("#UserEmail").val();
//            var birthday = $("#UserBirthday").val();
//            var Statement = $("#UserReg").val();

//            //性别用布尔类型表示
//            var adminSex = true;
//            var sexCheck = $('input:radio[name="sex"]:checked').val();//得到单选按钮选中项的值
//            if (sexCheck == '女') { adminSex = false; }

//            //把数据传递到ashx文件里。然后把ashx回传的数据显示出来。
//            $.ajax({
//                type: "post",
//                url: "ashx/NewUser.ashx",
//                data: { "Action": "add", "Name": name, "pwd": pwd, "email": email, "sex": adminSex, "birthday": birthday, "Statement": Statement, "Ustate": Ustate },
//                dataType: "text",
//                success: function (data) {
//                    var json = eval('(' + data + ')');
//                    alert(json.info);
//                },
//            })

//            alert(name + "\n" + pwd + "\n" + realname + "\n" + sex);
//        };
//    });

$(document).ready(

    function () {

        $("#btnSub").click(
                       function yanzheng() {
                           var meg = "";//设置返回的结果
                           if (form1.UserName.value.length > 15) {
                               meg += "输入的姓名长度大于15个字节" + "\n";
                           }
                           var patrn = /[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?/;
                           if (!patrn.exec(form1.UserEmail.value)) {
                               meg += "请正确输入邮箱" + "\n";
                           }
                           if (form1.UserBirthday.value.length != 8) {
                               meg += "请输入8位生日，如19980101" + "\n";
                           }
                           if (form1.UserPwd.value == "") {
                               meg += "密码不能为空" + "\n";
                           }

                           if (meg.length > 0) {
                               alert(meg);
                               return false;
                           }
                           else {
                               go();
                           }
                       }
          );

        //点击注册按钮。获取登录名、密码、真实姓名。用弹出框显示出来。
        function go() {
            
            var Ustate = $('input:radio[name="Admin"]:checked').val();
            var name = $("#UserName").val();
            var pwd = $("#UserPwd").val();
            var email = $("#UserEmail").val();
            var birthday = $("#UserBirthday").val();
            var Statement = $("#UserReg").val();

            //性别用布尔类型表示
            var adminSex = true;
            var sexCheck = $('input:radio[name="sex"]:checked').val();//得到单选按钮选中项的值
            if (sexCheck == '女') { adminSex = false; }

            //把数据传递到ashx文件里。然后把ashx回传的数据显示出来。
            $.ajax({
                type: "post",
                url: "ashx/NewUser.ashx",
                data: { "Action": "add", "Name": name, "pwd": pwd, "email": email, "sex": adminSex, "birthday": birthday, "Statement": Statement, "Ustate": Ustate },
                dataType: "text",
                success: function (data) {
                    var json = eval('(' + data + ')');
                    alert(json.info);
                },
            })

            alert(name + "\n" + pwd + "\n" + realname + "\n" + sex);
        };
    });