$(document).ready(function () {

        $.ajax({
            type: "Post",
            url: "ashx/index.ashx",
            //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字   
            data: { "Action": "Show"},
            dataType: "json",
            success: function (data) {

                var tbody = $('#show1');
                if (jQuery.isEmptyObject(data)) { //json数据为空
                    alert("无数据");
                }
                else {
                    //用json返回数据行时
                    $.each(data.Admin, function (index, item) {

                        /*<div class="col-sm-6 col-md-4">\
                            <div class="thumbnail">\
                                <img src="..." alt="...">\
                                <div class="caption">\
                                    <h3 style="text-align:center">'+item.TTopic+'</h3>\
                                    <p style="text-align:center">' + item.TContents + '</p>\
                                    <p style="text-align:center"><a href="about.html?tid=' + item.tid + '&sid=1" class="btn btn-primary" role="button">Read More</a></p>\
                                </div>\
                            </div>\
                        </div>*/
                        var tidimg = item.tid;
                        if (tidimg > 6)
                            itidimg %= 6;
                        var str = '<div class="col-sm-6 col-md-4">\
                            <div class="thumbnail">\
                                <img src="images/main' + tidimg + '.jpg" alt="..." style="height:194px;width:100%">\
                                <div class="caption">\
                                    <h3 style="text-align:center">'+ item.TTopic + '</h3>\
                                    <p style="text-align:center">' + item.TContents + '</p>\
                                    <p style="text-align:center"><a href="about.html?tid=' + item.tid + '&sid=1" class="btn btn-primary" role="button">Read More</a></p>\
                                </div>\
                            </div>\
                        </div>';
                        tbody.append(str);
                    });
                }

            },
            error: function (err) {
                alert(err);
            }
           
        });//显示文章


});