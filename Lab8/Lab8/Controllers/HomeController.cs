using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab8.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IRepository<Phone> phoneRepository;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"{context.ActionDescriptor.DisplayName} {context.HttpContext.Request.Method}" +
                $" {context.HttpContext.Request.Path} {context.HttpContext.Request.QueryString}");
        }

        public HomeController(ILogger<HomeController> logger, IRepository<Phone> rep)
        {
            phoneRepository = rep;
            _logger = logger;
        }

        public IActionResult Info()
        {
            return View(phoneRepository.GetAllPhones());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Phone phone)
        {
            phoneRepository.Add(phone);
            return RedirectToAction("Info");
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            int ID = Int32.Parse(id);
            var phone = phoneRepository.Get(ID);
            if (phone == null)
            {
                _logger.LogInformation("Telephone Not Found");
                return NotFound();
            }
            return View(phone);
        }

        [HttpPost]
        public IActionResult Update(Phone phone)
        {
            phoneRepository.Update(phone);
            return RedirectToAction("Info");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            int ID = Int32.Parse(id);
            var phone = phoneRepository.Get(ID);
            if (phone == null)
            {
                _logger.LogInformation("Telephone Not Found");
                return NotFound();
            }
            return View(phone);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteSave(string id)
        {
            phoneRepository.Remove(id);
            return RedirectToAction("Info");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
