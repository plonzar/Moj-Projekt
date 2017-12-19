using MojProjekt.Domain.Abstract;
using MojProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MojProjekt.Controllers
{
    public class HomeController : Controller
    {
        IManager repository = new InvoicAndCustomerManager();
        // GET: Home
        public ActionResult Index()
        {
            var model = repository.Customers;

            return View();
        }
    }
}