using WebApp_ASP.Models;
using WebApp_ASP.Models.Services;


namespace WebApp_ASP.Mappers
{
    public class ContactMapper
    {

        /*
         * Entity Framework działa na encjach (klasach, które są mapowane na tabele w bazie danych), 
         * które mają specyficzną strukturę odpowiadającą tabelom w bazie. ContactModel jest tylko modelem
         * aplikacyjnym, który nie jest mapowany na tabelę w bazie danych, dlatego nie możesz bezpośrednio 
         * dodać obiektu ContactModel do DbSet<ContactEntity>.
         * */
        public static ContactModel FromEntity(ContactEntity arg)
        {
            return new ContactModel()
            {
                Id = arg.Id,
                First_Name = arg.First_Name,
                Last_Name = arg.Last_Name,
                BirthDate = arg.BirthDate,
                Email = arg.Email,
                PhoneNumber = arg.PhoneNumber,
                Category = arg.Category,

            };
        }

        public static ContactEntity ToEntity(ContactModel model)
        {
            return new ContactEntity()
            {
                Id = model.Id,
                First_Name = model.First_Name,
                Last_Name = model.Last_Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                BirthDate = model.BirthDate,
                Category=model.Category
            };
        }
    }
}

/*
 * Podsumowanie:

    Encja to klasa, która reprezentuje tabelę w bazie danych (np. ContactEntity).

    DbSet to kolekcja encji, która umożliwia operowanie na tabeli bazy danych (dodawanie,
    usuwanie, edytowanie rekordów).

    DbContext to klasa odpowiedzialna za połączenie z bazą danych i konfigurację mapowania encji na tabele.

    Migracje pozwalają na automatyczne synchronizowanie modelu danych z bazą danych,
    dzięki czemu nie musisz ręcznie tworzyć lub modyfikować tabel.

    Mapowanie to proces konwertowania danych między obiektami aplikacji a encjami,
    które są przechowywane w bazie danych.

Mam nadzieję, że to podsumowanie pomoże Ci lepiej zrozumieć, jak działają migracje, encje i inne procesy w Entity Framework! Jeśli masz dodatkowe pytania, śmiało pytaj!
*/
