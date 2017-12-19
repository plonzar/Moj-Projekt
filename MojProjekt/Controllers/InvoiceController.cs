using MojProjekt.Domain.Abstract;
using MojProjekt.Domain.Entities;
using MojProjekt.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MojProjekt.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        IManager repository = new InvoicAndCustomerManager();

        string UserId;

        public ActionResult Index(string sortOrder, int? page, int size = 5)
        {
            UserId = User.Identity.GetUserId();
            var model = repository.Invoices
                .Where(i => i.UserId == UserId)
                .OrderByDescending(i => i.Id);

            //int pageSize = 10;
            //int pageNumber = (page ?? 1);

            return View(model);
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Invoice invoice)
        {
            UserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                repository.AddInvoice(invoice, UserId);   
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public ViewResult Edit(int id)
        {
            var model = repository.Invoices.FirstOrDefault(i => i.Id == id);
            if (model != null)
            {   
                return View(model);
            }
            else
            {
                return View("Index");
            }

        }
        [HttpPost]
        public ActionResult Edit(Invoice invoice)
        {
            UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                repository.EditInvoice(invoice, UserId);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Remove(int id)
        {
            var model = repository.Invoices.FirstOrDefault(i => i.Id == id);

            if (model != null)
            {
                repository.RemoveInvoice(model.Id);
            }

            return RedirectToAction("Index", "Invoice");
        }

        [ChildActionOnly]
        public ActionResult SingleCustomerInvoiceIist(Customer customer)
        {
            UserId = User.Identity.GetUserId();
            var model = repository.Invoices
                .Where(i => i.NIP == customer.NIP && i.UserId == UserId)
                .ToList();
            return PartialView("_SingleCustomerInvoiceList", model);
        }

       public ActionResult Autocomplete(string term)
        {
            UserId = User.Identity.GetUserId();
            var items = repository.Customers
                .Where(c => c.UserId == UserId)
                .Select(c => c.Name).ToArray();
            var filteredItems  = items
                .Where(item => item.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0);
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }
    }
}