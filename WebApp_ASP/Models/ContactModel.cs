using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp_ASP.Models
{
    public class ContactModel
    {

        // ukryte bedzie
        [HiddenInput]
        public int Id { get; set; }

        // wlasciwosc wymagana
        [Required(ErrorMessage = "Musisz wpisac imie!")]
        [MaxLength(length: 20, ErrorMessage = "Imie nie moze byc dluzsze niz 20 znakow")]
        [MinLength(length: 2, ErrorMessage = "Imie musi miec co najmniej 2 znaki")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Musisz wpisac imie!")]
        [MaxLength(length: 20, ErrorMessage = "Nazwisko nie moze byc dluzsze niz 20 znakow")]
        [MinLength(length: 2, ErrorMessage = "Nazwisko musi miec co najmniej 2 znaki")]
        public string Last_Name { get; set; }

        // wymagana @
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        // po 3 cyfry uzytkwnik musi wpisac
        [RegularExpression(pattern: "\\d{3} \\d{3} \\d{3}", ErrorMessage = "Wpisz nr wg wzoru : XXX XXX XXX")]
        public string PhoneNumber { get; set; }

        // tylko mozna wpisywac date
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }
    }
}
