using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWebApplication.Services
{
    public interface IRepo<K, T>
    {
        ICollection<T> GetAll();
        T Get(K k);
        bool Add(T item);
        bool Remove(K k);
        bool Update(T item);
    }
}
