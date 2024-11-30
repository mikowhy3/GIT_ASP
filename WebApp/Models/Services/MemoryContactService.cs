namespace WebApp.Models.Services;

public class MemoryContactService : IContactService
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {1,new ContactModel
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Kozak",
                Email = "adam.kozak@example.com",
                phoneNumber = "111 222 333",
                Category = Category.Buisiness,
                Birthday = new DateOnly(1980,1,1)
            }
            
        },
        {2,new ContactModel
        {
            Id = 2,
            FirstName = "Bartosz",
            LastName = "Luzak",
            Email = "bartosz.luzak@example.com",
            phoneNumber = "222 333 444",
            Category = Category.Family,
            Birthday = new DateOnly(2002,4,20)
        }},
        {3,new ContactModel
            {
                Id = 3,
                FirstName = "Bartosz",
                LastName = "Guzak",
                Email = "bartosz.guzak@example.com",
                Category = Category.Friend,
                phoneNumber = "333 444 555",
                Birthday = new DateOnly(2003,4,20)
            }
        }
    };

    private static int _currentId = 3;
    
    public void Add(ContactModel model)
    {
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;
        }
    }

    public void Delete(int id)
    {
       _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }

    public List<OrganizationEntity> GetAllOrganizations()
    {
        throw new NotImplementedException();
    }
}