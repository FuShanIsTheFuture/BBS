
$(document).ready(function () {
    $("#html1").click(
        function () {
          
            $("#test1").html("第一个按钮html");

        });

    $("#append").click(
        function () {
            $("#test2").append("第二个按钮append");

        });

    $("#before").click(
       function () {
           $("#test2").before("div2 前面");

       });
    $("#after").click(
       function () {
           $("#test1").after("div1 后面");

       });
    $("#json").click(
      function () {
          
          $.ajax({
              type: "post",
              url: "ashx/test.ashx",
              dataType: "json",
              success: function (data) {

                  var d2 = $("#test2");
                  $.each(data.people, function (index, item) {

                      var ss = "<p>" + item.firstName + " " + item.lastName + "</p>"
                      d2.append(ss);
                  });


              }
          });


      });
});


