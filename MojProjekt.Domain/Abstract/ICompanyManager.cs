using MojProjekt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojProjekt.Domain.Abstract
{
    public interface ICompanyManager
    {
        IEnumerable<Company>Companies { get; }
        IEnumerable<Invoice>Invoices { get; }

        void SaveCompany(Company company, string id);
    }
}
