namespace SMS.Domain;

public class Message
{
    public string Text { get; set; }
    public MessageGroup Group { get; set; }
    public DateTime TimeSent { get; set; }
}