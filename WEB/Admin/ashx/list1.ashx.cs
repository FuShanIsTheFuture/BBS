using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WEB.Admin.ashx
{
    /// <summary>
    /// list1 的摘要说明
    /// </summary>
    public class list1 : IHttpHandler, System.Web.SessionState.IRequiresSessionState//session接口
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "";
            string action = context.Request.Form["Action"];

            if (action == "Show")//显示
            {

                if (context.Session["ID"] == null)
                {
                    json = "{}";//未登录
                }
                else
                {
                    BLL.Admin bll = new BLL.Admin();
                    DataSet ds = bll.GetList("");
                    ds.Tables[0].TableName = "AdminTable";
                    //返回列表
                    json = WEB.DataConvertJson.DataTable2Json(ds.Tables[0]);



                }
            }
            else if (action == "Del")//删除操作
            {
                string DelNumS = context.Request.Form["DelNumS"];//获取批量删除的编号
                BLL.Admin bll = new BLL.Admin();
                if (bll.DeleteList(DelNumS))
                {
                    json = "{'info':'删除成功'}";
                }
                else
                { json = "{'info':'删除失败'}"; }
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