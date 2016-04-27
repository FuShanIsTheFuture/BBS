using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace WEB.Admin.ashx
{
    /// <summary>
    /// list 的摘要说明
    /// </summary>
    public class list : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "{}";
            string action = context.Request.Form["Action"];

            if (action == "Show")
            {

                BLL.Admin bll = new BLL.Admin();
                DataSet ds = bll.GetList(10);//调用业务逻辑层的方法
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