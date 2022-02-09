using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApplication.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> Products = new List<Product>()
        {
            new Product()
            {
                ProdId = 1,
                Name = "Hammer",
                Price = 9.90,
                SuppId = 101,
                Qty = 299,
                Remarks = "Red"
            },
            new Product()
            {
                ProdId = 2,
                Name = "Screwdriver",
                Price = 6.90,
                SuppId = 101,
                Qty = 209,
                Remarks = "Black"
            },
            new Product()
            {
                ProdId = 3,
                Name = "Nail",
                Price = 0.06,
                SuppId = 101,
                Qty = 1089,
                Remarks = "2-inch"
            },
            new Product()
            {
                ProdId = 4,
                Name = "Screw",
                Price = 0.08,
                SuppId = 101,
                Qty = 1209,
                Remarks = "1-inch"
            }
        };

        public IActionResult Index()
        {
            return View(Products);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(IFormCollection keyValues)
        {
            Product prod = new Product();
            prod.ProdId = Convert.ToInt32(keyValues["pid"]);
            prod.Name = keyValues["name"].ToString();
            prod.Price = Convert.ToDouble(keyValues["price"]);
            prod.Qty = Convert.ToInt32(keyValues["qty"]);
            prod.SuppId = Convert.ToInt32(keyValues["sid"]);
            prod.Remarks = keyValues["remarks"].ToString();
            Products.Add(prod);
            //return Content($"Hello {prod.Name}");
            return RedirectToAction("Index");
        }
        //public IActionResult Insert(Product prod)
        //{
        //    Products.Add(prod);
        //    return RedirectToAction("Index");
        //}
    }
}
