using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;

namespace WEB.Admin.ashx
{
    /// <summary>
    /// index 的摘要说明
    /// </summary>
    public class index : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "{'info':'数据失败'}";
            string action = context.Request.Form["Action"];
            if (action == "Show")//显示数据页
            {
                BLL.BBSTopic bll = new BLL.BBSTopic();
                // Model.Admin前必须加 [Serializable]
                DataSet ds = bll.GetModels();//调用业务逻辑层的方法
                ds.Tables[0].TableName = "Admin";//为数据表改名
                                                 //返回列表
                json = WEB.DataConvertJson.DataTable2Json(ds.Tables[0]);//调用把datatable转为json的方法
                context.Response.Write(json);
            }
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