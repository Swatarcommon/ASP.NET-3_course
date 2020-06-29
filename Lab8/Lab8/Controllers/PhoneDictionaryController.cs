using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab8.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers
{
    [Route("dictApi")]
    [ApiController]
    public class PhoneDictionaryController : ControllerBase
    {
        IRepository<Phone> phoneRepository;
        public PhoneDictionaryController(IRepository<Phone> rep)
        {
            phoneRepository = rep;
        }

        [HttpGet]
        public ActionResult<List<Phone>> Get()
        {
            return Ok(phoneRepository.GetAllPhones().ToList());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Phone> Get(int id)
        {
            Phone phone =  phoneRepository.Get(id);
            if (phone == null)
                return NoContent();
            return Ok(phone);
        }

        [HttpPost]
        public ActionResult<Phone> Post(Phone phone)
        {
            return phoneRepository.Add(phone);
        }

        [HttpPut]
        public ActionResult<Phone> Put(Phone phone)
        {
            return phoneRepository.Update(phone);
        }

        [HttpDelete("{id}")]
        public ActionResult<Phone> Delete(string id)
        {
            return phoneRepository.Remove(id);
        }


    }
}