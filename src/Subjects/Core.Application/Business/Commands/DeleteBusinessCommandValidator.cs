using FluentValidation;

namespace Goodtocode.Subjects.Application.Business.Commands;

public class DeleteBusinessCommandValidator : AbstractValidator<DeleteBusinessCommand>
{
    public DeleteBusinessCommandValidator()
    {
        RuleFor(y => y.BusinessKey).NotEmpty();        
    }
}