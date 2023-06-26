using FluentValidation;

namespace Goodtocode.Subjects.Application.Business.Commands;

public class UpdateBusinessCommandValidator : AbstractValidator<UpdateBusinessCommand>
{
    public UpdateBusinessCommandValidator()
    {
        RuleFor(y => y.BusinessKey).NotEmpty();
        RuleFor(x => x.BusinessName).NotEmpty();
    }
}