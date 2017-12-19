using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MojProjekt.Domain.Abstract;
using MojProjekt.Domain.Entities;

namespace MojProjekt.Models
{
    public class CompanyAndPrintManager : ICompanyManager
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<Company> Companies
        {
           get { return context.Companies; }
        }

        public IEnumerable<Invoice> Invoices
        {
            get { return context.Invoices; }
        }

        public void SaveCompany(Company company, string id)
        {

            if (company.ID == 0)
            {
                company.UserId = id;
                context.Companies.Add(company);
            }
            else
            {
                Company dbEntry = context.Companies
                    .FirstOrDefault(c => c.ID == company.ID);
                if (dbEntry != null)
                {
                    dbEntry.ID = company.ID;
                    dbEntry.UserId = company.UserId;
                    dbEntry.Name = company.Name;
                    dbEntry.NIP = company.NIP;
                    dbEntry.PostCode = company.PostCode;
                    dbEntry.Address = company.Address;
                    dbEntry.City = company.City;
                }
            }
            context.SaveChanges();
        }



    }
}