function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}
$(document).ready(function () {
    var Userid = getUrlParam('UserID');//获取网址传递过来的参数
    if (Userid != null) {
        $.ajax({
            type: "Post",
            url: "ashx/SHOW.ashx",
            //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字   
            data: { "UserID": Userid },
            dataType: "json",
            success: function (data) {
                var tbody = $('#showinfo'); 
                //用json返回一个对象数据
                //   tbody.append(data.LoginID + "<br/>" + data.AdminName);
                var sex = '女';
                if (data.Usex == true) { sex = '男'; }

                var outStr = '<table cellSpacing="0" cellPadding="0" width="100%" border="2" style="border-color:#c34c21">\
                 <caption><h2>用户详细信息</h2></caption>\
	         	<tr>  <td height="45"  align="right" > 编号：</td> <td align="left" style="padding-left:10px"> ' + data.Uid + ' </td></tr> \
                <tr>  <td height="45" align="right"> 姓名：</td> <td align="left" style="padding-left:10px"> ' + data.Uname + ' </td></tr> \
	          	<tr>  <td height="45" align="right"> 密码：</td> <td align="left" style="padding-left:10px"> ' + data.UPassword + ' </td></tr> \
                <tr>  <td height="45" align="right"> 邮箱：</td> <td align="left" style="padding-left:10px"> ' + data.UEmail + ' </td></tr> \
	            <tr>  <td height="45" align="right"> 性别：</td> <td align="left" style="padding-left:10px"> ' + sex + ' </td></tr>\
                 <tr>  <td height="45" align="right"> 生日：</td> <td align="left" style="padding-left:10px"> ' + data.UBirthday + ' </td></tr>\
                 <tr>  <td height="45" align="right"> 等级：</td> <td align="left" style="padding-left:10px"> ' + data.UClass + ' </td></tr>\
                 <tr>  <td height="45" align="right"> 个人说明：</td> <td align="left" style="padding-left:10px"> ' + data.UStatement + ' </td></tr>\
                 <tr>  <td height="45" align="right"> 用户状态：</td> <td align="left" style="padding-left:10px"> ' + data.UState + ' </td></tr>\
                 <tr>  <td height="45" align="right"> 用户积分：</td> <td align="left" style="padding-left:10px"> ' + data.UPoint + ' </td></tr>\
            </table>';

                tbody.append(outStr);

                //  alert(data.LoginID + data.AdminName);
            },
            error: function (err) {
                alert(err);
            }
        });
    }
    else { window.history.go(-1);}


});