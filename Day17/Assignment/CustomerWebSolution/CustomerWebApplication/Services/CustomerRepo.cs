using CustomerWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWebApplication.Services
{
    public class CustomerRepo : IRepo<int, Customer>
    {
        private readonly AppDbContext _context;
        public CustomerRepo (AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer Get(int id)
        {
            Customer cust = _context.Customers.FirstOrDefault(c => c.Id == id);
            return cust;
        }

        public bool Add(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();
            return true;
        }

        public bool Remove(int id)
        {
            Customer cust = Get(id);
            _context.Customers.Remove(cust);
            _context.SaveChanges();
            return true;

        }

        public bool Update(Customer item)
        {
            Customer cust = _context.Customers.FirstOrDefault(x => x.Id == item.Id);
            if (cust != null)
            {
                cust.Name = item.Name;
                cust.Age = item.Age;
                cust.Phone = item.Phone;
                _context.Customers.Update(cust);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
