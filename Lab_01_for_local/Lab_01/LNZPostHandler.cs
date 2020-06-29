using System;
using System.IO;
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

            //показать в каком формате хранятся параметры в запросе
            var reader = new StreamReader(context.Request.InputStream);
            var inputString = reader.ReadToEnd();

            string result = "POST-Http-LNZ: ParmA = " + parmA + ", ParmA = " + parmB + "\n" + inputString;


            int parmAI = Int32.Parse(parmA);
            int parmBI = Int32.Parse(parmB);

            result += "\nSum result = " + (parmAI + parmBI);
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

    }
}
