using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_03.Controllers
{
    public class ErrorController : Controller
    {
        [ActionName("404")]
        public ActionResult Error404()
        {
            return View();
        }
    }
}