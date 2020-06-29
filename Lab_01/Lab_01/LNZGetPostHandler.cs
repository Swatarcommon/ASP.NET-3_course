using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Lab_01
{
    public class LNZGetPostHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            string textFromFile = File.ReadAllText(@"D:\Apps\Le\Lab_01\getpost.html");
            if (context.Request.HttpMethod == "GET")
            {
                context.Response.ContentType = "text/html";
                context.Response.Write(textFromFile);
            }
            if (context.Request.HttpMethod == "POST")
            {
                int parmA = Int32.Parse(context.Request.Form.Get("x"));
                int parmB = Int32.Parse(context.Request.Form.Get("y"));
                context.Response.ContentType = "text/plain";
                int mul = parmA * parmB;
                context.Response.Write(String.Format("x = {0}, y= {1} \n x*y = {2}", parmA, parmB, mul));
            }
        }

    }
}