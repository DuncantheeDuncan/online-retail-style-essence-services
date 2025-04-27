using System.ComponentModel.DataAnnotations;
using SMS.Domain;
using Sms.Domain.Helpers;

namespace SMS.AppService;

public static class UserService
{
    private static readonly  UserValidator UserValidator = new();
    private static List<User> _users;

    static UserService()
    {
        _users = UserHelper.GetFakeUsers();
    }
    public static User? CreateValidUser(string name, string surname, Contact contact, Role role)
    {
        var user= new User(name, surname, contact, role);
        var validatedUser = UserValidator.Validate(user);
        if (!validatedUser.IsValid) return null;
        _users.Add(user);
        return user;
    }
    
}