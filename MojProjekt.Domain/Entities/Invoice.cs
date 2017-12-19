using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//naprawić customera trzba z osobna dać wszystkie parametry bo sie sql pierdoli i zależności daje między dwoma tabelami a ja chce meć to rozłączne i tyle

namespace MojProjekt.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę klienta")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Proszę podać nazwę miasta")]
        public string City { get; set; }

        [Display(Name = "Kod pocztowy")]
        [Required(ErrorMessage = "Proszę podać kod pocztowy")]
        public string PostCode { get; set; }

        [Display(Name = "Ulica")]
        [Required(ErrorMessage = "Proszę podać ulicę i numer")]
        public string Address { get; set; }

        [Display(Name = "NIP")]
        [Required(ErrorMessage = "Proszę podać NIP kilenta")]
        public string NIP { get; set; }

        [Required]
        [Display(Name = "Cena netto towaru")]
        public decimal PriceWithoutTax { get; set; }

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        [Required]
        [Display(Name = " stawka podateku")]
        
        public int Tax { get; set; }

        [Required]
        [Display(Name = "Cena brutto")]
        public decimal PriceWithTax { get; set; }

        [Required]
        [Display(Name ="Nazwa usługi/towaru")]
        public string ItemName { get; set; }
    }
}
