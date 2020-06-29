using Lab_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_03.Controllers
{
    public class DictController : Controller
    {
        static object locker = new object();
        PhoneRepository phoneRepository = new PhoneRepository();

        public ActionResult Index()
        {
            return View(phoneRepository.GetAllPhones());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Phone phone)
        {
                phoneRepository.Add(phone);
                return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
                var phone = phoneRepository.Get(id);
                if (phone == null)
                {
                    return HttpNotFound();
                }
                return View(phone);
        }


        [HttpPost]
        public ActionResult Update(Phone phone)
        {
            phoneRepository.Update(phone);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(string id)
        {
            var phone = phoneRepository.Get(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteSave(string id)
        {
            phoneRepository.Remove(phoneRepository.Get(id));
            return RedirectToAction("Index");
        }
    }
}