using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojProjekt.Domain.Entities
{
    public class Customer
    {
        public int ID { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę klienta")]
        [Display(Name ="Nazwa")]
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
    }
}
