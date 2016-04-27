function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}

$(document).ready(function () {
    var sid = getUrlParam('SID');//主贴的编号
    $.ajax({
        type: "Post",
        url: "ashx/PShow.ashx",
        data: { "Action": "Show","SID":sid},
        dataType: "json",
        success: function (data) {

            var tbody = $('#showp');
            if (jQuery.isEmptyObject(data)) { //json数据为空
                alert("无数据");
            }
            else {
                //用json返回数据行时
                $.each(data.Admin, function (index, item) {
                    var str = '<tr>\
                            <td style="text-align: center; ">' + sid
                                              + '</td>\
                            <td style="text-align: center; ">\
                                 <a href="about.html?tid='
                                + item.tid + '&sid='+sid+'">' + item.tid
                            + '</a>\
                            </td>\
                        <td style="text-align: center; ">' + item.TTopic
                      + '</td>\
                        <td style="text-align: center; ">' + item.TTime
                                              + '</td>\
                        <\tr>';
                    tbody.append(str);
                });
            }

        },
        error: function (err) {
            alert(err);
        }
    });

});