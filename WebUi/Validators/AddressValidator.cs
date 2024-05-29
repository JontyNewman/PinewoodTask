using FluentValidation;

namespace JontyNewman.PinewoodTask.WebUi.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.Line1).NotEmpty()
            .WithMessage("Enter the first line of the address");

        RuleFor(a => a.Town).NotEmpty()
            .WithMessage("Enter the town or city of the address");

        RuleFor(a => a.County).NotEmpty()
            .WithMessage("Enter the county of the address");

        RuleFor(a => a.Postcode).NotEmpty()
            .WithMessage("Enter the postcode of the address");
    }
}
