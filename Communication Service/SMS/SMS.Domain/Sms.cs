namespace SMS.Domain;

public class Sms
{
    public User Sender { get; set; }
    public User Receiver { get; set; }
    public Message Message { get; set; }
    public MessageState State { get; set; }
}