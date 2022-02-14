using ProductWebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApplication2.Services
{
    public interface IRepo<K,T>
    {
        ICollection<T> GetAll();
        T Get(K id);
        bool Add(T item);
        bool Remove(K id);
        bool Update(T item);
        bool Buy(T item);
    }
}
