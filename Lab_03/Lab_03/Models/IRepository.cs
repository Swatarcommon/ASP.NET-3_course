using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03.Models
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAllPhones();
        T Get(string last_name);
        void Add(T item);
        bool Remove(T item);
        void Update(T item);
    }
}
