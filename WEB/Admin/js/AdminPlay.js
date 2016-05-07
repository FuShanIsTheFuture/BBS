$(document).ready(function () {
    $("#AdminPlay").hide();
    $.ajax({
        type: "Post",
        url: "ashx/AdminPlay.ashx",
        //方法传参的写法一定要对，UserName为形参的名字,PassWord为第二个形参的名字   
        data: {},
        dataType: "text",
        success: function (data) {
            //返回类型为text时 要处理一下 
            var json = eval('(' + data + ')');
            //   $("#result").val(json); 
            if (json.info == 'yes') {
                $("#AdminPlay").show();
            }
            else {
                $("#AdminPlay").hide();
            }
        },
        error: function (err) {
            alert(err);
        }
    });
});