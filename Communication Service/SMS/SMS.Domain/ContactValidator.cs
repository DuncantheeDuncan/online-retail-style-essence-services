using FluentValidation;

namespace SMS.Domain;

public class ContactValidator:AbstractValidator<Contact>
{
   public ContactValidator()
   {
      RuleFor(contact => contact.PhoneNumber).NotNull().Matches(@"^\+?\d{10,15}$")
         .WithMessage("Invalid phone number. It must be 10-15 digits long and may start with a '+'.");
   }
}