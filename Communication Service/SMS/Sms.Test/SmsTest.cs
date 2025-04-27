using Microsoft.AspNetCore.Identity;
using Sms.Domain.Helpers;

namespace Sms.Test;

public class SmsTest
{
    private readonly Contact _contact = new Contact("+263642681132");
    private List<User> users;

    private SmsTest()
    {
        users =  UserHelper.GetFakeUsers();
    }
    
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
    
    [Fact]
    public void ShouldCreateUser()
    {
        // given user details
        // when creating a user
        var newUser = UserService.CreateValidUser();
        // the system should create a valid user
        Assert.Equal("Arnold", newUser.Name);
    }
}