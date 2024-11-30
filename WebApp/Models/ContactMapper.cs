namespace WebApp.Models;

public class ContactMapper
{
    public static ContactEntity ToEntity(ContactModel model)
    {
        return new ContactEntity()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            phoneNumber = model.phoneNumber,
            Email = model.Email,
            Birthday = model.Birthday,
            Category = model.Category,
            Organization = model.Organization,
            OrganizationId = model.OrganizationId,
        };
    }

    public static ContactModel FromEntity(ContactEntity model)
    {
        return new ContactModel()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            phoneNumber = model.phoneNumber,
            Email = model.Email,
            Birthday = model.Birthday,
            Category = model.Category,
            Organization = model.Organization,
            OrganizationId = model.OrganizationId,
        };
    }
}