using MojProjekt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojProjekt.Domain.Abstract
{
    public interface IManager
    {
        IEnumerable<Invoice> Invoices { get; }
        IEnumerable<Customer> Customers { get; }

        Customer RemoveCustomer(int customerId);
        void SaveCustomer(Customer customer);
        void AddCustomer(Customer customer, string id);
        void EditCustomer(Customer customer);

        Invoice RemoveInvoice(int invoiceId);
        void SaveInvoice(Invoice invoice);
        void AddInvoice(Invoice invoice, string id);
        void EditInvoice(Invoice invoice, string id);
    }
}
