using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Admin.ashx
{
    /// <summary>
    /// Add 的摘要说明
    /// </summary>
    public class register : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string json = "{'info':'增加数据失败'}";
            //获取动作的类型
            string action = context.Request.Form["Action"];
            if (action == "add")
            {
                //获取GET方法传递参数：Request.QueryString["参数名称"];
                //获取POST方法传递参数：Request.Form["参数名称"];
                string txtUserName = context.Request.Form["Name"]; //保存文本框对象，提高效率
                string txtPassWord = context.Request.Form["pwd"];
                string txtemail = context.Request.Form["email"];
                string adminSex = context.Request.Form["sex"];
                string txtbirthday = context.Request.Form["birthday"];
                string txtstatement = context.Request.Form["Statement"];


                Model.Admin model = new Model.Admin();
                model.Uname = txtUserName;//用户姓名
                model.UPassword = txtPassWord;//用户密码
                model.UEmail = txtemail;//用户邮箱
                //用户生日
                string y = txtbirthday.Substring(0, 4);
                string m = txtbirthday.Substring(4, 2);
                string d = txtbirthday.Substring(6, 2);
                txtbirthday = y + "-" + m + "-" + d;
                model.UBirthday = txtbirthday;//用户生日

                model.UStatement = txtstatement;//用户描述
                model.URegDate = DateTime.Now;//用户注册时间
                model.Usex = false;//用户性别
                if (adminSex == "true") { model.Usex = true; }

                BLL.Admin bll = new BLL.Admin();
                int n = bll.add(model);
                //返回单个文字信息
                if (n > 0) { json = "{'info':'增加数据成功,编号是：" + n + "'}"; }
            }
            else if (action == "Load")
            {
                if (context.Session["ID"] == null)
                {
                    json = "{'info':'no'}";
                }

            }
            context.Response.Write(json);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}