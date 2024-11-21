using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id{ get; set; }
    [Required(ErrorMessage = "First name is required")]
    [MaxLength(length: 20, ErrorMessage = "First name cannot be longer than 20 characters")]
    [MinLength(length: 2, ErrorMessage = "First name cannot be less than 2 characters")]
    [Display(Name = "Imię",Order = 2)]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(length: 50, ErrorMessage = "Last name cannot be longer than 50 characters")]
    [MinLength(length: 2, ErrorMessage = "Last name cannot be less than 2 characters")]
    [Display(Name = "Nazwisko",Order = 1)]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Adres email jest wymagany")]
    [EmailAddress(ErrorMessage = "Niepoprawny format adresu email")]
    [Display(Name = "Adres e-mail",Order = 4)]
    public string Email { get; set; }
    
    [Phone]
    [RegularExpression(@"\d{3} \d{3} \d{3}",ErrorMessage = "Wpisz numer według wzoru XXX XXX XXX")]
    [Display(Name = "Numer telefonu",Order = 3)]
    public string phoneNumber { get; set; }
    
    [DataType(DataType.Date)]
    [Display(Name = "Data Urodzin")]
    public DateOnly Birthday { get; set; }
    
    [Display(Name = "Kategoria")]
    public Category Category { get; set; }
    
}