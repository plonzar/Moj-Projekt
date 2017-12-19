using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MojProjekt.Domain.Abstract;
using MojProjekt.Domain.Entities;
using MojProjekt.Models;
using PagedList;
using Microsoft.AspNet.Identity;

namespace MojProjekt.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        IManager repository = new InvoicAndCustomerManager();

        string UserId;

        public ViewResult Index(string sortOrder, int? page, int size = 5, string searchString = null)
        {
            UserId = User.Identity.GetUserId();
            var model = repository.Customers
                .Where(c => c.UserId == UserId)
                .Where(c => searchString == null || c.Name.Contains(searchString) || c.NIP == searchString)
                .OrderBy(p => p.ID);
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            UserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                repository.AddCustomer(customer, UserId);
                return RedirectToAction("Index");
            }
            else
            {
                return View(customer);
            }          
        }

        public ActionResult Delete(int id)
        {
            repository.RemoveCustomer(id);

            return RedirectToAction("Index");
        }

        public ViewResult Edit(int id)
        {
            UserId = User.Identity.GetUserId();

            Customer customer = repository.Customers
                .Where(i => i.UserId == UserId)
                .FirstOrDefault(c => c.ID == id);
            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return View("Index");
            }
            
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repository.EditCustomer(customer);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ViewResult Details(int id)
        {
            UserId = User.Identity.GetUserId();

            Customer customer = repository.Customers
                .Where(c => c.UserId == UserId)
                .FirstOrDefault(c => c.ID == id);

            return View(customer);
        }

        [HttpGet]
        public JsonResult GetCustomerData(string term)
        {
            UserId = User.Identity.GetUserId();
            var data = repository.Customers
               .Where(c => c.UserId == UserId)
               .Where(c => c.Name.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0)
               .ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}