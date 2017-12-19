using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojProjekt.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public Customer customer { get; set; }
        public decimal PriceWithoutTax { get; set; }
        public DateTime date { get; set; }
        public decimal Tax { get; set; }
        public decimal PriceWithTax { get; set; }
        public string ItemName { get; set; }
    }
}
