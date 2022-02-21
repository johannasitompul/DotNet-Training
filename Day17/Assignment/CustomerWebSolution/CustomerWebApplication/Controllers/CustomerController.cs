using CustomerWebApplication.Models;
using CustomerWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWebApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepo<int, Customer> _repo;

        public CustomerController(IRepo<int, Customer> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public IActionResult Details(int id)
        {
            Customer cust = _repo.Get(id);
            return View(cust);
        }

        public IActionResult Create()
        {
            return View(new Customer());
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _repo.Add(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Customer customer = _repo.Get(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(int id, Customer customer)
        {
            _repo.Update(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Customer customer = _repo.Get(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(int id, Customer customer)
        {
            _repo.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
