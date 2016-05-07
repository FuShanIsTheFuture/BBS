using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Admin.ashx
{
    /// <summary>
    /// AdminPlay 的摘要说明
    /// </summary>
    public class AdminPlay : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Session["UState"] 是否为管理员
            string json = "{'info':'失败'}";
            int ustate = Convert.ToInt32(context.Session["UState"]);
            if (ustate == 1)
            {
                json = "{'info':'no'}";
            }
            else
                json = "{'info':'yes'}";
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