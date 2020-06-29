using System;
using System.Web;

namespace Lab_01
{
    public class LNZGetHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string parmA = context.Request.QueryString.Get("ParmA");
            string parmB = context.Request.QueryString.Get("ParmB");

            string result = String.Format("GET-Http-LNZ: ParmA = {0}, ParmA = {1} \n", parmA, parmB);

            int parmAI = Int32.Parse(parmA);
            int parmBI = Int32.Parse(parmB);

            result += "Sum result = " + (parmAI + parmBI);
            context.Response.ContentType = "text/plain";
            context.Response.StatusCode = 200;
            context.Response.Write(result);
        }
        public bool IsReusable
        {
            get { return false; }
        }

    }
}