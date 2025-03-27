namespace SMS.Domain;

public class Contact(string phoneNumber)
{
    public string PhoneNumber { get; set; } = phoneNumber;
    /*public string Email { get; set; } = email;
    public string WhatsappNumber { get; set; } = whatsappNumber;*/
}