using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MojProjekt.Domain.Abstract;
using MojProjekt.Domain.Entities;

namespace MojProjekt.Models
{
    public class InvoicePrintViewModel
    {
        public InvoicePrintViewModel(Company comp, Invoice inv)
        {
            Company = comp;
            Invoice = inv;
        }

        public Company Company { get; set; }
        public Invoice Invoice { get; set; }
    }
}