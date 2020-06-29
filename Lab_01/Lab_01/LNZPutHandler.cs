using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_01
{
    public class LNZPutHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string parmA = context.Request.QueryString.Get("ParmA");
            string parmB = context.Request.QueryString.Get("ParmB");

            string result = "PUT-Http-LNZ: ParmA = " + parmA + ", ParmA = " + parmB;
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}