using Microsoft.AspNetCore.Identity;

namespace Sms.Test;

public class SmsTest
{
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
        
    }
}