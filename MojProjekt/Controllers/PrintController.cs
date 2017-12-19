using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MojProjekt.Domain.Entities;
using MojProjekt.Domain.Abstract;
using MojProjekt.Models;
using Microsoft.AspNet.Identity;
using SelectPdf;
using System.Web.Security;

namespace MojProjekt.Controllers
{
    public class PrintController : Controller
    {
        ICompanyManager repository = new CompanyAndPrintManager();
        string UserId;

        public ViewResult GenerateInvoice(int invoiceID)
        {   
            UserId = User.Identity.GetUserId();

            var companyModel = repository.Companies
                .Where(c => c.UserId == UserId)
                .Single();
            var invoiceModel = repository.Invoices
                .Where(c => c.UserId == UserId)
                .Where(c => c.Id == invoiceID)
                .Single();

            var model = new InvoicePrintViewModel(companyModel, invoiceModel);

            return View(model);
        }

        //test

        public ActionResult GetPdf(int id)
        {
            var converter = new HtmlToPdf();

            UrlHelper urlHelper = new UrlHelper(this.ControllerContext.RequestContext);

            converter.Options.HttpCookies.Add(
            FormsAuthentication.FormsCookieName,
            Request.Cookies[FormsAuthentication.FormsCookieName].Value);

            string url = urlHelper.Action("GenerateInvoice", "Print", new { invoiceID = id });

            var doc = converter.ConvertUrl("http://localhost:51252/Invoice/Index");
            doc.Save(System.Web.HttpContext.Current.Response, true, "Faktura.pdf");
            doc.Close();

            return null;
        }
    }
}