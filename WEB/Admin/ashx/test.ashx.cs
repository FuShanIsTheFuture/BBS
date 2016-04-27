using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Admin.ashx
{
    /// <summary>
    /// test 的摘要说明
    /// </summary>
    public class test : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string json =  @"{ ""people"": [
      { ""firstName"": ""Brett"", ""lastName"":""McLaughlin"", ""email"": ""aaaa"" }, 
      { ""firstName"": ""Jason"", ""lastName"":""Hunter"", ""email"": ""bbbb""}, 
      { ""firstName"": ""Elliotte"", ""lastName"":""Harold"", ""email"": ""cccc"" } 
                    ]}";



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