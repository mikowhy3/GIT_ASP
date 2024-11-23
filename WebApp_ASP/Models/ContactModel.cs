using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp_ASP.Models
{
    public class ContactModel
    {

		// gdy dajemy display mozemy sobie usunac labele
		[Display(Name = "Priorytet")]
		public Priority Priority { get; set; }

		[Display(Name = "Kategoria")]
		public Category Category { get; set; }

        public int dupa { get; set; }


        // ukryte bedzie
        [HiddenInput]
		public int Id { get; set; }

		// wlasciwosc wymagana
		[Required(ErrorMessage = "Musisz wpisac imie!")]
		[MaxLength(length: 20, ErrorMessage = "Imie nie moze byc dluzsze niz 20 znakow")]
		[MinLength(length: 2, ErrorMessage = "Imie musi miec co najmniej 2 znaki")]

		[Display(Name = "Imię", Order = 1)]
		public string First_Name { get; set; }

		[Required(ErrorMessage = "Musisz wpisac imie!")]
		[MaxLength(length: 20, ErrorMessage = "Nazwisko nie moze byc dluzsze niz 20 znakow")]
		[MinLength(length: 2, ErrorMessage = "Nazwisko musi miec co najmniej 2 znaki")]

		[Display(Name = "Nazwisko", Order = 2)]
		public string Last_Name { get; set; }

		// wymagana @
		[EmailAddress]

		[Display(Name = "Adres Email", Order = 4)]
		public string Email { get; set; }

		[Phone]
		// po 3 cyfry uzytkwnik musi wpisac

		[RegularExpression(pattern: "\\d{3} \\d{3} \\d{3}", ErrorMessage = "Wpisz nr wg wzoru : XXX XXX XXX")]

		[Display(Name = "Telefon", Order = 3)]
		public string PhoneNumber { get; set; }

		
		// tylko mozna wpisywac date
		[DataType(DataType.Date)]

		[Display(Name = "Data urodzenia")]
		public DateOnly BirthDate { get; set; }
	}
}
