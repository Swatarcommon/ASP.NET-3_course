using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.Json;
using System.IO;

namespace Lab_03.Models
{
    sealed public class PhoneRepository : IRepository<Phone>
    {
        static public List<Phone> Phones { get; set; } = new List<Phone>();
        public void SaveModel()
        {
            string json = JsonSerializer.Serialize<List<Phone>>(Phones);
            File.WriteAllText(@"D:\Studying\Course_3\Second_2sem\ASP.NET\Labs\Lab_03\Lab_03\Models\PhonesDB.json", json);
        }

        public void LoadModel()
        {
            Phones = JsonSerializer.Deserialize<List<Phone>>(File.ReadAllText(@"D:\Studying\Course_3\Second_2sem\ASP.NET\Labs\Lab_03\Lab_03\Models\PhonesDB.json"));
        }

        public void Add(Phone item)
        {
            if (item != null)
            {
                Phones.Add(item);
                SaveModel();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phone> GetAllPhones()
        {
            LoadModel();
            Phones.OrderBy(t => t.Last_name);
            return Phones;
        }

        public bool Remove(Phone item)
        {
            if (item == null)
            {
                return false;
            }
            Phones.Remove(item);
            SaveModel();
            return true;
        }

        public void Update(Phone item)
        {
            if (item != null)
            {
                var phone = Get(item.Last_name);
                Phones.Remove((Phone)phone);
                Phones.Add(item);
                SaveModel();
            }
        }

        public Phone Get(string last_name) => Phones.Find(t => t.Last_name == last_name);

    }
}