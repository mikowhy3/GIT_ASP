namespace WebApp_ASP.Models.Services
{
    //implementacja serwisu
    public class MemoryContactService : IContactService
    {

        private static Dictionary<int, ContactModel> contacts = new()
        {
            {

                1, new ContactModel()
                {
                    Category=Category.Business,
                    Id=1,
                    First_Name="Asia",
                    Last_Name="Klawka",
                    Email="email@gmail.com",
                    PhoneNumber="111 222 333",
                    BirthDate= new DateOnly(year:2000,month:10,day:3)
                }

            },
            {

                 2, new ContactModel()
                {
                    Category=Category.Family,
                    Id=2,
                    First_Name="Kasia",
                    Last_Name="Klawka",
                    Email="email@gmail.com",
                    PhoneNumber="234 192 222",
                    BirthDate= new DateOnly(year:2001,month:10,day:4)
                }
            },
            {
                 3, new ContactModel()
                {
                    Category=Category.Friends,
                    Id=3,
                    First_Name="Basia",
                    Last_Name="Plawka",
                    Email="email@gmail.com",
                    PhoneNumber="273 928 012",
                    BirthDate= new DateOnly(year:2003,month:11,day:30)
                }
            }
        };
        private static int _cureentId = 3;

        // implementacja wszystkich metod
        public void Add(ContactModel model)
        {
            model.Id = ++_cureentId;
            contacts.Add(model.Id, model);
        }

        public void Delete(int id)
        {
            contacts.Remove(id);
        }

        // ZAMIAST DZIENNIKA WYSWIETLAMY LISTE A NIE ORYGINALNY DZIENNIK
        // ODDZIELENIE LOGIKI PRZETWARZANIA DANYCH OD LOGIKI WYSWIETLANIA!
        public List<ContactModel> GetAll()
        {
            return contacts.Values.ToList();
        }

        // implementacja details
        public ContactModel? GetById(int id)
        {
            return contacts[id];
        }

        public void Update(ContactModel contact)
        {
            if (contacts.ContainsKey(contact.Id))
            {
                contacts[contact.Id] = contact;
            }
        }

    }
}
