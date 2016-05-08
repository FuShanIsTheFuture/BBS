$(document).ready(

    function () {

        $("#btnSub").click(
                       function yanzheng() {
                           var meg = "";//设置返回的结果
                           if (form1.ttopic.value == ""||form1.ttopic.value.length>15) {
                               meg += "帖子标题不能为空或标题长度大于15" + "\n";
                           }
                           if (form1.tcontents.value == "") {
                               meg += "帖子内容不能为空" + "\n";
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

            //得到用户填写的内容
            var ttopic = $("#ttopic").val();
            var tcontents = $("#tcontents").val();
            var rsid = $("#rsid").val();

            //把数据传递到ashx文件里。然后把ashx回传的数据显示出来。
            $.ajax({
                type: "post",
                url: "ashx/NewTopic.ashx",
                data: { "Action": "add", "ttopic": ttopic, "tcontents": tcontents, "rsid": rsid },
                dataType: "text",
                success: function (data) {
                    var json = eval('(' + data + ')');
                    alert(json.info);
                },
            })

            alert(name + "\n" + pwd + "\n" + realname + "\n" + sex);
        };
    });