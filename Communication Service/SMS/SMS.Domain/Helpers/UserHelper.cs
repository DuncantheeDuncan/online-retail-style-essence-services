using SMS.Domain;

namespace Sms.Domain.Helpers;

public static class UserHelper
{
    public static List<User> GetFakeUsers()
    {
        return
        [
            new User("Alice", "Johnson", new Contact("+12345678901"), new Role { Name = "Admin" }),
            new User("Bob", "Smith", new Contact("+19876543210"), new Role { Name = "User" }),
            new User("Charlie", "Brown", new Contact("+11234567890"), new Role { Name = "Moderator" }),
            new User("Diana", "Prince", new Contact("+10987654321"), new Role { Name = "User" }),
            new User("Edward", "Norton", new Contact("+12309876543"), new Role { Name = "Admin" }),

            // Duplicates
            new User("Bobby", "Smithson", new Contact("+19876543210"), new Role { Name = "User" }), // Duplicate of Bob
            new User("Dina", "Prince", new Contact("+10987654321"), new Role { Name = "User" })
        ];
    }


}