using FluentValidation;

namespace Goodtocode.Subjects.Models;

public class BusinessValidator : AbstractValidator<BusinessModel>
{
    public BusinessValidator()
    {
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(person => person.BusinessName).NotEmpty().WithMessage("Business name is a required field.")
            .Length(3, 50).WithMessage("Business name must be between 3 and 50 characters.");
       //RuleFor(person => person.Addresses).NotEmpty().WithMessage("You have to define at least one address per person");
        //RuleForEach(person => person.Addresses).SetValidator(new AddressValidator());
    }
}