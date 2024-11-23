using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebApp_ASP.Models
{
    // po prostu poprawniejsze uzywanie widoku i tyle
    static public class EnumExtensions
    {

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}

// WYTLUMACZENIE!

/*
 public enum Category
{
    [Display(Name = "Osoba prywatna")]
    Private,
    
    [Display(Name = "Firma")]
    Business
}


Jeśli wywołasz GetDisplayName() na Category.Private, proces będzie wyglądał tak:

    GetType() — zwraca typ Category.
    GetMember("Private") — zwraca członka enum o nazwie "Private".
    First() — wybiera ten członek.
    GetCustomAttribute<DisplayAttribute>() — zwraca atrybut Display przypisany do Private.
    GetName() — zwraca "Osoba prywatna".



*/

