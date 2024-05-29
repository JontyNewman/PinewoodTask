using FluentValidation;

namespace JontyNewman.PinewoodTask.WebUi.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Enter the name of the customer");

        RuleFor(c => c.Email).NotEmpty()
            .WithMessage("Enter the email address of the customer")
            .EmailAddress()
            .WithMessage("Enter a valid email address");

        RuleFor(c => c.Address).SetValidator(new AddressValidator());
    }
}
