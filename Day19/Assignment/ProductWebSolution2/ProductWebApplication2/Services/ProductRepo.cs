using ProductWebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApplication2.Services
{
    public class ProductRepo : IRepo<int, Product>
    {
        private readonly ProductContext _context;

        public ProductRepo(ProductContext context)
        {
            _context = context;
        }
        
        public bool Add(Product item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return true;
        }

        public Product Get(int id)
        {
            Product product = _context.Product.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public ICollection<Product> GetAll()
        {
            return _context.Product.ToList();
        }

        public bool Remove(int id)
        {
            Product product = Get(id);
            _context.Product.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Product item)
        {
            Product product = _context.Product.FirstOrDefault(x => x.Id == item.Id);
            if (product != null)
            {
                product.Name = item.Name;
                product.Category = item.Category;
                product.Price = item.Price;
                product.Qty = item.Qty;
                product.Pic = item.Pic;
                product.Desc = item.Desc;
                _context.Product.Update(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Buy(Product item)
        {
            Product product = _context.Product.FirstOrDefault(x => x.Id == item.Id);
            if (product != null)
            {
                product.Qty = product.Qty - item.Qty;
                _context.Product.Update(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
