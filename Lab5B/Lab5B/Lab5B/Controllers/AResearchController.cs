using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Lab5B.Controllers
{
    public class AResearchController : Controller
    {
        public ActionResult Index()
        {
            return Content("GET:AResearch/Index\n");
        }

        [AAFilter]
        public ActionResult AA()
        {
            return Content("AA result\n");
        }

        [ARFilter]
        public ActionResult AR()
        {
            return Content($"AR result\n");
        }

        [AEFilter]
        public ActionResult AE()
        {
            throw new Exception("Exception in AE Action");
            return Content($"AE worked right\n"); ;
        }

        public class AAFilter : FilterAttribute, IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("AA:Вызов после работы метода действия\n");
            }

            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("AA:Вызов перед вызовом метода действия\n");
            }
        }

        public class ARFilter : FilterAttribute, IResultFilter
        {
            public void OnResultExecuted(ResultExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write($"AR:Вызов после возвращение результата действия\n{filterContext.HttpContext.Timestamp.Ticks}\n");
            }

            public void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write($"AA:Вызов до вовзаращение резульата действия\n{filterContext.HttpContext.Timestamp.Ticks}\n");
            }
        }

        public class AEFilter : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                filterContext.HttpContext.Response.Write("AE:Вызвано исключение\n");
                //filterContext.Result = new RedirectResult("http://localhost:9189/AResearch/AA");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}