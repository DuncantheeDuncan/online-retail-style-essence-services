namespace SMS.Domain;

public class Sms
{
    public required User Sender { get; set; }
    public required User Receiver { get; set; }
    public required Message Message { get; set; }
    public required MessageState State { get; set; }
}