using System.ComponentModel.DataAnnotations;
using SMS.Domain;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace SMS.AppService;

public abstract class ContactService
{
    private static readonly ContactValidator ContactValidator = new ContactValidator();
    private static readonly List<Contact> Contact =
    [
        new Contact("0642681132"),
        new Contact("+263642681132")
    ];

    private static Contact? GetContact(string phoneNumber)
    {
        return Contact.Where(contact => contact.PhoneNumber == phoneNumber).Select(contact =>
            new Contact(contact.PhoneNumber)).FirstOrDefault();
    }
    public static bool CheckNumberValidity(string phoneNumber)
    {
        var getContact = GetContact(phoneNumber);
        if (getContact == null) return false;
        
        var result = ContactValidator.Validate(getContact);
        return result.IsValid;
    }
}