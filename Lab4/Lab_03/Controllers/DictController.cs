using PhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneStore.Controllers
{
    public class DictController : Controller
    {
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
        public ActionResult Add(Phones phone)
        {
            phoneRepository.Add(phone);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            int ID = Int32.Parse(id);
            var phone = phoneRepository.Get(ID);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }


        [HttpPost]
        public ActionResult Update(Phones phone)
        {
            phoneRepository.Update(phone);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(string id)
        {
            int ID = Int32.Parse(id);
            var phone = phoneRepository.Get(ID);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteSave(string id)
        {
            int ID = Int32.Parse(id);
            phoneRepository.Remove(phoneRepository.Get(ID));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            //base.Dispose(disposing);
        }
    }
}