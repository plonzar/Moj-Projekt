using MojProjekt.Domain.Abstract;
using MojProjekt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MojProjekt.Models
{
    public class InvoicAndCustomerManager : IManager
    {
        ApplicationDbContext contex = new ApplicationDbContext();

        public IEnumerable<Invoice> Invoices
        {
            get { return contex.Invoices; }
        }
        public IEnumerable<Customer> Customers
        {
            get { return contex.Customers; }
        }

        public Customer RemoveCustomer(int customerId)
        {
            Customer dbEntry = contex.Customers
                .FirstOrDefault(c => c.ID == customerId);
            if (dbEntry != null)
            {
                contex.Customers.Remove(dbEntry);
                contex.SaveChanges();
            }
            return dbEntry;
        }

        public Invoice RemoveInvoice(int invoiceId)
        {
            Invoice dbEntry = contex.Invoices
                .FirstOrDefault(c => c.Id == invoiceId);
            if (dbEntry != null)
            {
                contex.Invoices.Remove(dbEntry);
                contex.SaveChanges();
            }
            return dbEntry;
        }

        //save Customer object in database
        public void SaveCustomer(Customer customer)
        {

            if (customer.ID == 0)
            {
                contex.Customers.Add(customer);
            }
            else
            {
                Customer dbEntry = contex.Customers
                    .FirstOrDefault(c => c.ID == customer.ID);
                if (dbEntry != null)
                {
                    dbEntry.UserId = customer.UserId;
                    dbEntry.Name = customer.Name;
                    dbEntry.NIP = customer.NIP;
                    dbEntry.PostCode = customer.PostCode;
                    dbEntry.Address = customer.Address;
                    dbEntry.City = customer.City;
                }
            }
            contex.SaveChanges();
        }

        //save Invoice object in database
        public void SaveInvoice(Invoice invoice)
        {
            if (invoice.Id == 0)
            {
                contex.Invoices.Add(invoice);
            }
            else
            {
                Invoice dbEntry = contex.Invoices
                    .FirstOrDefault(c => c.Id == invoice.Id);
                if (dbEntry != null)
                {
                    dbEntry.UserId = invoice.UserId;
                    dbEntry.InvoiceNumber = invoice.InvoiceNumber;
                    dbEntry.ItemName = invoice.ItemName;
                    dbEntry.PriceWithoutTax = invoice.PriceWithoutTax;
                    dbEntry.PriceWithTax = invoice.PriceWithTax;
                    dbEntry.Tax = invoice.Tax;
                    dbEntry.Name = invoice.Name;
                    dbEntry.Address = invoice.Address;
                    dbEntry.City = invoice.City;
                    dbEntry.PostCode = invoice.PostCode;
                    dbEntry.NIP = invoice.NIP;
                }
            }
            contex.SaveChanges();
        }



        public void AddInvoice(Invoice invoice, string id)
        {
            int invoiceNumberCounter;
            DateTime date = DateTime.Now;

            var exist = contex.Invoices
                .Where(i => i.UserId == id)
                .Count();

            if (exist  != 0)
            {
                invoiceNumberCounter = Invoices
                     .Where(i => i.UserId == id)
                     .LastOrDefault().InvoiceNumber + 1;
            }
            else
            {
                invoiceNumberCounter = 1;
            }

            invoice.Day = date.Day;
            invoice.Month = date.Month;
            invoice.Year = date.Year;
            invoice.InvoiceNumber = invoiceNumberCounter;
            invoice.UserId = id;

            if (contex.Customers
                .Where(c => c.UserId == id)
                .FirstOrDefault(c => c.NIP == invoice.NIP) == null)
            {
                Customer newCustomer = new Customer()
                {   
                    UserId = id,
                    Name = invoice.Name,
                    Address = invoice.Address,
                    City = invoice.City,
                    PostCode = invoice.PostCode,
                    NIP = invoice.NIP
                };
                SaveCustomer(newCustomer);
                SaveInvoice(invoice);
            }
            else
            {
                SaveInvoice(invoice);
            }
        }

        public void EditInvoice(Invoice invoice, string id)
        {
            if (contex.Customers
                .Where(i => i.UserId == id)
                .FirstOrDefault(c => c.NIP == invoice.NIP) == null)
            {
                Customer newCustomer = new Customer()
                {
                    UserId = id,
                    Name = invoice.Name,
                    Address = invoice.Address,
                    City = invoice.City,
                    PostCode = invoice.PostCode,
                    NIP = invoice.NIP
                };
                SaveCustomer(newCustomer);
                SaveInvoice(invoice);
            }
            else
            {
                SaveInvoice(invoice);
            }
        }

        public void AddCustomer(Customer customer, string id)
        {
            customer.UserId = id;
            SaveCustomer(customer);
            
        }

        public void EditCustomer(Customer customer)
        {
            SaveCustomer(customer);
        }
    }
}
