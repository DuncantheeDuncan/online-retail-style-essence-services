namespace SMS.Domain;

public class MessageState(string status)
{
    public string Status { get; set; } = status;
}