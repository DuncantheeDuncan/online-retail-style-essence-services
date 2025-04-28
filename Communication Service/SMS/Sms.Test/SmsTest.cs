using Microsoft.AspNetCore.Identity;
using Sms.Domain.Helpers;
using static SMS.AppService.UserService;

namespace Sms.Test;

public class SmsTest
{
    private readonly Contact _contact = new("+263642681132");
    private readonly Role _role = new() { Name = "Admin" };
    private List<User> users = UserHelper.GetFakeUsers();

    [Theory]
    [InlineData("+263642681132", true)]
    [InlineData("0642681132", true)]
    [InlineData(null, false)]
    [InlineData("642681132", false)]
    public void ShouldGetValidContact(string contactNumber, bool expected)
    {
        // when checkContactValidity is called
        var checkNumberValidity = ContactService.CheckNumberValidity(contactNumber);
        // the length should be 10 digits long
        Assert.Equal(expected,checkNumberValidity);
    }
    
    [Theory]
    [InlineData("Alice", "Johnson")]
    public void ShouldCreateUser(string name, string surname)
    {
        // given user details
        // when creating a user
        var newUser = CreateValidUser(name, surname, _contact, _role);
        // the system should create a valid user
        Assert.Equal("Alice", newUser?.Name);
    }
}