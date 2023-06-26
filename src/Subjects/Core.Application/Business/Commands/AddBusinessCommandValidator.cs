using FluentValidation;

namespace Goodtocode.Subjects.Application;

public class AddBusinessCommandValidator : AbstractValidator<AddBusinessCommand>
{
    public AddBusinessCommandValidator()
    {
        RuleFor(x => x.BusinessName).NotEmpty();
    }
}