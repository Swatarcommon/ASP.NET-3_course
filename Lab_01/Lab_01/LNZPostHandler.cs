using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_01
{
    public class LNZPostHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            string parmA = context.Request.Params.Get("ParmA");
            string parmB = context.Request.Params.Get("ParmB");

            string result = "POST-Http-LNZ: ParmA = " + parmA + ", ParmA = " + parmB;
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

    }
}
