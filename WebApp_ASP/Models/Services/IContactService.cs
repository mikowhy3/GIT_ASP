namespace WebApp_ASP.Models.Services
{
    public interface IContactService
    {

        // tutaj sa metody serwisowe, opierajace sie na dzialaniu biznesowym

        // ponizej konkretne metody usuwajace, dodajace, updatujace rzeczy
        void Add(ContactModel contact);
        void Update(ContactModel contact);

        void Delete(int id);

        // wyswiewtlenie wszystkich kontaktow
        List<ContactModel> GetAll();

        // wyswietlenie jednego kontaktu na podstawie id
        ContactModel? GetById(int id);

    }
}
