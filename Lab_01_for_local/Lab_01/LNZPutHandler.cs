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

            int parmAI = Int32.Parse(parmA);
            int parmBI = Int32.Parse(parmB);

            result += "Sum result = " + (parmAI + parmBI);
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}