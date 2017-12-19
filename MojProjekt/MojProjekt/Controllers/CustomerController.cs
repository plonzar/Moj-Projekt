using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MojProjekt.Domain.Abstract;
using MojProjekt.Domain.Entities;
using MojProjekt.Models;

namespace MojProjekt.Controllers
{
    public class CustomerController : Controller
    {
        IManager repository = new InvoicAndCustomerManager();

        public PartialViewResult Index()
        {
            var model = repository.Customers.ToList();
            return PartialView(model);
        }
        
    }
}