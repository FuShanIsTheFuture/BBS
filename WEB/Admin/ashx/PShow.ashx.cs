using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;

namespace WEB.Admin.ashx
{
    /// <summary>
    /// PShow 的摘要说明
    /// </summary>
    public class PShow : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "{}";
            string action = context.Request.Form["Action"];
            string sidstr = context.Request.Form["SID"];
            int sid =int.Parse(sidstr);
            if (action == "Show")
            {
                BLL.BBSSection bll = new BLL.BBSSection();
                DataSet ds = bll.GetList(sid,20);//调用业务逻辑层的方法
                ds.Tables[0].TableName = "Admin";//为数据表改名
                                                 //返回列表
                json = WEB.DataConvertJson.DataTable2Json(ds.Tables[0]);//调用把datatable转为json的方法
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