namespace SMS.Domain;

public class Contact(string phoneNumber)
{
    public string PhoneNumber { get; set; } = phoneNumber;
}