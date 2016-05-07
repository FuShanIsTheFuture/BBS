$(document).ready(function () {
    $.ajax({
        type: "Post",
        url: "ashx/pages.ashx",
        data: { "Action": "Load" },
        dataType: "text",
        success: function (data) {
            //返回类型为text时 要处理一下 \
            var json = eval('(' + data + ')');
            if (json.info == 'no') {
                alert('请先登录');
                window.location.href = "login.html";
            }
            else { show(); }
        },

    });
    function show() {
        $.ajax({
            type: "Post",
            url: "ashx/pages.ashx",
            data: { "Action": "Show" },
            dataType: "json",
            success: function (data) {

                var tbody = $('#showlist');
                if (jQuery.isEmptyObject(data)) { //json数据为空
                    alert("无数据");
                }
                else {
                    //用json返回数据行时
                    $.each(data.Admin, function (index, item) {
                        var str = '<tr>\
                            <td style="text-align: center; ">\
                                 <a href="show.html?Uid='
                                     + item.Uid + '">' + item.Uid
                                 + '</a>\
                            </td>\
                           <td style="text-align: center; ">' + item.Uname
                           + '</td>\
                        <td style="text-align: center; ">' + item.UPassword
                           + '</td>\
                        <td style="text-align: center; ">' + item.URegDate
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
    }
});