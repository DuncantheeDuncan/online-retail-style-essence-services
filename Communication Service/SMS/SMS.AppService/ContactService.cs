using SMS.Domain;
using Sms.Domain.Helpers;

namespace SMS.AppService;

public static class ContactService
{
    private static readonly ContactValidator ContactValidator = new();
    private static List<Contact> _contacts;


    static ContactService()
    {
        _contacts = ContactHelper.GetFakeContacts();
    }

    private static Contact? GetContact(string phoneNumber)
    => _contacts.Where(contact => contact.PhoneNumber == phoneNumber)
            .Select(contact => new Contact(contact.PhoneNumber))
            .FirstOrDefault();
    
    public static bool CheckNumberValidity(string phoneNumber)
    {
        var getContact = GetContact(phoneNumber);
        if (getContact == null || DuplicateContact(phoneNumber)) return false;
        
        var result = ContactValidator.Validate(getContact);
        return result.IsValid;
    }

    private static bool DuplicateContact(string number)
        => _contacts
            .Select(contact => contact.PhoneNumber == number)
            .FirstOrDefault();

    public static bool AddContact(Contact contact)
    {
        if (!CheckNumberValidity(contact.PhoneNumber)) return false;
        _contacts.Add(contact);
        return true;
    }
     
}