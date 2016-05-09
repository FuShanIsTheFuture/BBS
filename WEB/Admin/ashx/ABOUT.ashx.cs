using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;

namespace WEB.Admin.ashx
{
    /// <summary>
    /// ABOUT 的摘要说明
    /// </summary>
    public class ABOUT : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "{'info':'增加数据失败'}";
            string action = context.Request.Form["Action"];
            if (action == "Show")//显示数据页
            {
                string UserID = context.Request.Form["UserID"];
                BLL.BBSTopic bll = new BLL.BBSTopic();
                // Model.Admin前必须加 [Serializable]
                Model.BBSTopic model = bll.GetModel(int.Parse(UserID));
                //返回一个类的对象
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string jsonString = serializer.Serialize(model);
                context.Response.Write(jsonString);
            }
            else if (action == "Load")//检查是否已经登录
            {
                if (context.Session["ID"] == null)
                {
                    json = "{'info':'no'}";
                }
                context.Response.Write(json);
            }
            else if (action == "reply")//回帖操作
            {
                int id = int.Parse(context.Session["ID"].ToString());//获取当前用户的ID
                context.Response.ContentType = "text/plain";

                json = "{'info':'回帖失败','ID':-1}";

                string txtReply = context.Request.Form["txtreply"];//回帖内容
                string txtTitle = context.Request.Form["txttitle"];//回帖标题
                int tid = int.Parse(context.Request.Form["tid"]);//主贴编号
                int sid = int.Parse(context.Request.Form["sid"]);//板块编号

                BLL.BBSReply bll = new BLL.BBSReply();
                int n = bll.add(txtReply, txtTitle, tid, sid, id);
                //返回单个文字信息;
                if (n > 0)
                {
                    json = "{'info':'回帖成功！'}";
                }
                context.Response.Write(json);
            }
            else if (action == "good")
            {
                BLL.BBSTopic bll = new BLL.BBSTopic();
                int tid = int.Parse(context.Request.Form["tid"]);
                if (bll.changegood(tid))
                {
                    json = "{'info':'点赞成功！'}";
                }
                else
                    json = "{'info':'点赞失败！'}";
            }
            else if (action == "ShowReply")
            {
                BLL.BBSReply bll = new BLL.BBSReply();
                int tid = int.Parse(context.Request.Form["TID"]);
                DataSet ds = bll.GetList(tid,3);//调用业务逻辑层的方法
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