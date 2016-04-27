$(document).ready(function () {

    $.ajax({
        type: "Post",
        url: "ashx/TopicContent.ashx",
        data: { "Action": "Show" },
        dataType: "json",
        success: function (data) {

            var tbody = $('#showtopic');
            if (jQuery.isEmptyObject(data)) { //json数据为空
                alert("无数据");
            }
            else {
                //用json返回数据行时
                $.each(data.Admin, function (index, item) {
                    var str = '<tr>\
                            <td style="text-align: center; ">\
                                 <a href="about.html?tid='
                                 + item.tid + '">' + item.tid
                             + '</a>\
                            </td>\
                        <td style="text-align: center; ">' + item.TTopic
                       + '</td>\
                        <td style="text-align: center; ">' + item.TTime
                                               + '</td>\
                    <td style="text-align: center; ">' + item.TLastClickT
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