using SMS.Domain;

namespace Sms.Domain.Helpers;

public static class ContactHelper
{
    public static List<Contact> GetFakeContacts()
    {
        return
        [
            new Contact("0642681132"),
            new Contact("+263642681132")
        ];
    }
}