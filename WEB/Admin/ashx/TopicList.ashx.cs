using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WEB.Admin.ashx
{
    /// <summary>
    /// TopicList 的摘要说明
    /// </summary>
    public class TopicList : IHttpHandler, System.Web.SessionState.IRequiresSessionState//session接口
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
                    BLL.BBSTopic bll = new BLL.BBSTopic();
                    DataSet ds = bll.GetList("");
                    ds.Tables[0].TableName = "TopicTable";
                    //返回列表
                    json = WEB.DataConvertJson.DataTable2Json(ds.Tables[0]);



                }
            }
            else if (action == "Del")//删除操作
            {
                string DelNumS = context.Request.Form["DelNumS"];//获取批量删除的编号
                BLL.BBSTopic bll = new BLL.BBSTopic();
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