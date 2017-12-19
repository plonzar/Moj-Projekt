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
            Customer dbEntry = contex.Customers.FirstOrDefault(c => c.ID == customerId);
            if (dbEntry != null)
            {
                contex.Customers.Remove(dbEntry);
                contex.SaveChanges();
            }
            return dbEntry;
        }

        public Invoice RemoveInvoice(int invoiceId)
        {
            Invoice dbEntry = contex.Invoices.FirstOrDefault(c => c.Id == invoiceId);
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
                Customer dbEntry = contex.Customers.Find(customer.ID);
                if (dbEntry != null)
                {
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
                Invoice dbEntry = contex.Invoices.Find(invoice.Id);
                if (dbEntry != null)
                {
                    dbEntry.InvoiceNumber = invoice.InvoiceNumber;
                    dbEntry.ItemName = invoice.ItemName;
                    dbEntry.PriceWithoutTax = invoice.PriceWithoutTax;
                    dbEntry.PriceWithTax = invoice.PriceWithTax;
                    dbEntry.Tax = invoice.Tax;
                    dbEntry.customer = invoice.customer;
                }
            }
        }
    }
}