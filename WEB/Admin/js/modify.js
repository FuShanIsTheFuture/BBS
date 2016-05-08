function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}

   $(document).ready(

    function () {
        
        $("#btnSub").click(
                       function yanzheng() {
                           var meg = "";//设置返回的结果
                           if (form1.name.value.length > 15) {
                               meg += "输入的姓名长度大于15个字节" + "\n";
                           }
                           var patrn = /[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?/;
                           if (!patrn.exec(form1.email.value)) {
                               meg += "请正确输入邮箱" + "\n";
                           }
                           if (form1.birthday.value.length != 8) {
                               meg += "请输入8位生日，如19980101" + "\n";
                           }
                           if (form1.pwd.value == "") {
                               meg += "密码不能为空" + "\n";
                           }
                           if (form1.uclass.value == "") {
                               meg += "用户等级不能为空" + "\n";
                           }
                           if (form1.upoint.value == "") {
                               meg += "用户积分不能为空" + "\n";
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
            
            var UserID = getUrlParam('UserID');
            var Ustate = $('input:radio[name="Admin"]:checked').val();
            var name = $("#name").val();
            var pwd = $("#pwd").val();
            var email = $("#email").val();
            var birthday = $("#birthday").val();
            var Statement = $("#statement").val();
            var uclass = $("#uclass").val();
            var upoint = $("#upoint").val();

            //性别用布尔类型表示
            var adminSex = true;
            var sexCheck = $('input:radio[name="sex"]:checked').val();//得到单选按钮选中项的值
            if (sexCheck == '女') { adminSex = false; }

            //把数据传递到ashx文件里。然后把ashx回传的数据显示出来。
            $.ajax({
                type: "post",
                url: "ashx/modify.ashx",
                data: { "Action": "add", "UserID": UserID, "Name": name, "pwd": pwd, "email": email, "sex": adminSex, "birthday": birthday, "Statement": Statement, "Ustate": Ustate, "uclass": uclass, "upoint": upoint },
                dataType: "text",
                success: function (data) {
                    var json = eval('(' + data + ')');
                    alert(json.info);
                },
            })

            alert(name + "\n" + pwd + "\n" + realname + "\n" + sex);
        };
    });