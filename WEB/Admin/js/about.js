function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}

function yanzheng() {
    //判断是否事先登录
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
            else { }
        },

    });
    
}
//操作回帖的内容
function reply() {
    var tid = getUrlParam('tid');//主贴的编号
    var sid = getUrlParam('sid');//获取板块编号
    var txtreply = $("#txtreply").val();//获取回帖的内容
    var txttitle = $("#replytitle").val();//获取回帖的主题
    if (txtreply != "" && txttitle != "") {
        $.ajax({
            type: "Post",
            url: "ashx/ABOUT.ashx",
            data: { "Action": "reply", "txtreply": txtreply, "txttitle": txttitle, "tid": tid, "sid": sid },
            dataType: "text",
            success: function (data) {
                var json = eval('(' + data + ')');
                alert(json.info);
            },
        })
    }
    else {
        alert("输入不正确");
    }
    window.location.reload();
}

//点赞数加1
function changegood() {
    var tid = getUrlParam('tid');//主贴的编号
    $.ajax({
        type: "Post",
        url: "ashx/ABOUT.ashx",
        data: { "Action": "good","tid":tid},
        dataType: "text",
        success: function (data) {
            var json = eval('(' + data + ')');
            alert(json.info);
        },
        
    })
    window.location.reload();
}


$(document).ready(function () {

    //<h5 style="text-align:center;color:#777">点击量：' + data.TClickCount + '<span style="margin-left:20px;"><a href="#" onclick="changegood()"><img src="./images/thumbs-up.jpg" width="20px" height="20px" /></a><span style="padding-left:5px">' + data.TGoodCount + '</span></span></h5>\

    var Userid = getUrlParam('tid');//获取网址传递过来的参数
    if (Userid != null) {
        $.ajax({
            type: "Post",
            url: "ashx/ABOUT.ashx",
            //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字   
            data: {"Action":"Show", "UserID": Userid },
            dataType: "json",
            success: function (data) {
                var tbody = $('#showabout');
                //用json返回一个对象数据
                //   tbody.append(data.LoginID + "<br/>" + data.AdminName);
                if (Userid > 6)
                    Userid %= 6;
                var outStr = '<div class="about-text">\
				<h3>'+data.TTopic+'</h3>\
			</div>	\
			<div class="about-info">\
<h5 style="text-align:center;color:#777">点击量：' + data.TClickCount + '<button class="btn btn-primary" type="button" style="background:#fff;padding:0px;border-color:#fdbe01;line-height:0px"><a href="#" onclick="changegood()"><img src="./images/thumbs-up.png" width="20px" height="20px" /></a><span class="badge" style="line-height:0px;color:#777">' + data.TGoodCount + '</span></button></h5>\
				<div class="col-md-5 about-info-left" style="margin-top:2em">\
					<img src="images/main'+Userid+'.jpg" alt="主贴图片"/>\
				</div>\
				<div class="col-md-7 about-info-right" style="margin-top:1em">\
                    <p style="text-indent:2em">' + data.TContents+ '</p>\
				</div>\
				<div class="clearfix"> </div>';

                tbody.append(outStr);

                //  alert(data.LoginID + data.AdminName);
            },
            error: function (err) {
                alert(err);
            }
        });//显示文章

        $.ajax({
            type: "Post",
            url: "ashx/ABOUT.ashx",
            data: { "Action": "ShowReply", "TID": Userid },
            dataType: "json",
            success: function (data) {

                var tbody = $('#showlist2');
                if (jQuery.isEmptyObject(data)) { //json数据为空
                    alert("无数据");
                }
                else {
                    //用json返回数据行时
                    $.each(data.Admin, function (index, item) {


                       var str = '<div class="col-md-4 about-text-info" style="text-align:center;">\
			    <h4 style="text-align:center">回帖用户：' + item.RUID + '</h4>\
			    <h5>' + item.RTopic + '</h5>\
			    <p class="about-pgh">' + item.RContents + '</p>\
		    </div>';
                        tbody.append(str);
                    });
                }

            },
            error: function (err) {
                alert(err);
            }
        });//显示回帖内容

    }
    else { alert('地址有误'); }

    //显示神回复的部分
    /*<div class="col-md-4 about-text-info">
			    <h4 style="text-align:center">1</h4>
			    <h5></h5>
			    <p class="about-pgh"></p>
		    </div>
		    <div class="col-md-4 about-text-info">
					    <h4 style="text-align:center">2</h4>
					    <h5></h5>
					    <p class="about-pgh"></p>
				    </div>
				    <div class="col-md-4 about-text-info">
					    <h4 style="text-align:center">3</h4>
					    <h5></h5>
					    <p class="about-pgh"></p>
				    </div>
				    <div class="clearfix"> </div>*/
   

});