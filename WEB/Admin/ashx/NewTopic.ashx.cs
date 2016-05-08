using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Admin.ashx
{
    /// <summary>
    /// NewTopic 的摘要说明
    /// </summary>
    public class NewTopic : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
                //保存文本框对象，提高效率
                string ttopic = context.Request.Form["ttopic"];//帖子标题
                string tcontents = context.Request.Form["tcontents"];//帖子内容
                string rsid = context.Request.Form["rsid"];//帖子所属板块
                //string 

                Model.BBSTopic model = new Model.BBSTopic();
                model.TTopic = ttopic;
                model.TContents = tcontents;
                model.Tsid = int.Parse(rsid);
                model.TTime = DateTime.Now;//发帖时间
                model.Tuid = Convert.ToInt32(context.Session["ID"]);
                model.Treplycount = 0;
                model.TLastClickT = DateTime.Now;
                model.TClickCount = 0;

                BLL.BBSTopic bll = new BLL.BBSTopic();
                int n = bll.add(model);
                //返回单个文字信息
                if (n > 0) { json = "{'info':'增加数据成功,编号是：" + n + "'}"; }
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