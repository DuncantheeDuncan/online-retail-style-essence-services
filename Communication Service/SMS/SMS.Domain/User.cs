namespace SMS.Domain;

public class User
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Contact Contact { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Role Role { get; set; }
}