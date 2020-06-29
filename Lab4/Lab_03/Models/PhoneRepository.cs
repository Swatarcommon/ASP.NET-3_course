using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.Json;
using System.IO;

namespace PhoneStore.Models
{

    sealed public class PhoneRepository : IRepository<Phones>
    {
        PhoneDictionaryEntities db = new PhoneDictionaryEntities();

        public void Add(Phones item)
        {
            db.Phones.Add(item);
            db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phones> GetAllPhones()
        {
            var sortedPhones = db.Phones.Select(n => n).OrderBy(n => n.Name);
            return sortedPhones;
        }

        public bool Remove(Phones item)
        {
            if (item == null)
            {
                return false;
            }
            db.Phones.Remove(item);
            db.SaveChanges();
            return true;

        }

        public void Update(Phones item)
        {
            var phone = Get(item.Id);
            phone.Name = item.Name;
            phone.Phone_Number = item.Phone_Number;
            db.SaveChanges();
        }

        public Phones Get(int ID)
        {
            return db.Phones.FirstOrDefault(t => t.Id == ID);
        }

    }
}