using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductWebApplication2.Models;
using ProductWebApplication2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApplication2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepo<int, Product> _repo;

        public ProductController(IRepo<int, Product> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }
        public IActionResult Details(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategory();
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(product);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        public IActionResult Edit(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            _repo.Update(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Product product)
        {
            _repo.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Buy(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(int id, Product product)
        {
            _repo.Buy(product);
            return RedirectToAction("Index");
        }

        IEnumerable<SelectListItem> GetCategory()
        {
            List<SelectListItem> cats = new List<SelectListItem>();
            cats.Add(new SelectListItem { Text = "Food", Value = "Food" });
            cats.Add(new SelectListItem { Text = "Toy", Value = "Toy" });
            cats.Add(new SelectListItem { Text = "Clothing", Value = "Clothing" });
            return cats;
        }
    }
}
