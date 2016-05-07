using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Admin.ashx
{
    /// <summary>
    /// ShowAbout 的摘要说明
    /// </summary>
    public class ShowAbout : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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