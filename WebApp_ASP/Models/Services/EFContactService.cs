
using WebApp_ASP.Mappers;

namespace WebApp_ASP.Models.Services
{
    public class EFContactService : IContactService
    {
        //_context – Pole prywatne, które przechowuje instancję AppDbContext.
        //Jest ono wstrzykiwane przez konstruktor (dzięki Dependency Injection)
        //i służy do operowania na danych w bazie.
        private AppDbContext _context;

        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        // Dodanie nowego kontaktu
       // public int Add(ContactModel contact)
       // {
        //    var e = _context.Contacts.Add(ContactMapper.ToEntity(contact));
        //    _context.SaveChanges();
        //    return e.Entity.Id;
       // }

        void IContactService.Add(ContactModel contact)
        {
            // musimy zrobic mapowanie bo DbSet i Contacts w AppDbContext operuje na ContactEntity
            ContactEntity entity = ContactMapper.ToEntity(contact);
            _context.Contacts.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            ContactEntity? find = _context.Contacts.Find(id);
            if (find != null)
            {
                _context.Contacts.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<ContactModel> GetAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList(); ;
        }

        public ContactModel? GetById(int id)
        {
            return ContactMapper.FromEntity(_context.Contacts.Find(id));
        }

        public void Update(ContactModel contact)
        {
            _context.Contacts.Update(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }

        
    }
}
