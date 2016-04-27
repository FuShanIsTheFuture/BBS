using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WEB.Admin.ashx
{
    /// <summary>
    /// SHOW 的摘要说明
    /// </summary>
    public class SHOW : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string UserID = context.Request.Form["UserID"];
            BLL.Admin bll = new BLL.Admin();
            // Model.Admin前必须加 [Serializable]
            Model.Admin model = bll.GetModel(int.Parse(UserID));
            //返回一个类的对象
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string jsonString = serializer.Serialize(model);
            context.Response.Write(jsonString);
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