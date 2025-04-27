namespace SMS.Domain;

public class User(string name, string surname, Contact contact, Role role)
{
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;
    public Contact Contact { get; set; } = contact;
    public Role Role { get; set; } = role;
}