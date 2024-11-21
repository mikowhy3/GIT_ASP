using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public enum Category
{
    [Display(Name = "Rodzina",Order = 1)]
    Family,
    [Display(Name = "Przyjaciele",Order = 2)]
    Friend,
    [Display(Name = "Kontakt Biznesowy",Order = 3)]
    Buisiness
}