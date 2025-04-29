namespace SMS.Domain;

public class Message(string text, MessageGroup group, DateTime timeCreated, DateTime timeSent)
{
    public string Text { get; set; } = text;
    public MessageGroup Group { get; set; } = group;
    public DateTime TimeCreated { get; set; } = timeCreated;
    public DateTime TimeSent { get; set; } = timeSent;
}