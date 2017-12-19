using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MojProjekt.Domain.Entities;
using MojProjekt.Domain.Abstract;
using MojProjekt.Models;
using Microsoft.AspNet.Identity;

namespace MojProjekt.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        ICompanyManager repository = new CompanyAndPrintManager();
        string UserID;

        public ActionResult Edit()
        {
            UserID = User.Identity.GetUserId();

            var model = repository.Companies
                .Where(c => c.UserId == UserID)
                .SingleOrDefault();

            if (model != null)
            {
                return View(model);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            UserID = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                repository.SaveCompany(company, UserID);
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                return View();
            }
        }
    }
}