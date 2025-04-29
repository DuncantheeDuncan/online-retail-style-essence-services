namespace SMS.Domain;

public class MessageGroup(string name, MessageType type)
{
    public string Name { get; set; } = name;
    public MessageType Type { get; set; } = type;
}