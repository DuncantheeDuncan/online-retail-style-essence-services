namespace Sms.Test;

public class SmsTest
{
    private Contact _contact = new Contact("+263642681132");
    [Fact]
    public void ShouldGetValidContact()
    {
        // given a contact number
        var contactNumber = _contact.PhoneNumber;
        // when checkContactValidity is called
        var checkNumberValidity = ContactService.CheckNumberValidity(contactNumber);
        // the length should be 10 digits long
        Assert.True(checkNumberValidity);
    }

    [Fact]
    public void ShouldCreateMessage()
    {
        // given 
    }
}