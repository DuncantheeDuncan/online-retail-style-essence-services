using FluentValidation;

namespace SMS.Domain;

public class UserValidator:AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Name)
            .MinimumLength(3)
            .WithMessage("Name must be longer than 2 characters.");
        
        RuleFor(x => x.Surname)
            .MinimumLength(3)
            .WithMessage("Surname must be longer than 2 characters.");
        
        RuleFor(x => x.Contact)
            .NotNull()
            .WithMessage("Contact Must Not Be Empty");
        
        RuleFor(x => x.Role)
            .NotNull()
            .WithMessage("Role Must Not Be Empty");
    }
}