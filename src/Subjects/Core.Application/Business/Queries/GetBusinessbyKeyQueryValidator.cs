using FluentValidation;

namespace Goodtocode.Subjects.Application;

public class GetBusinessbyKeyQueryValidator : AbstractValidator<GetBusinessByKeyQuery>
{
    public GetBusinessbyKeyQueryValidator()
    {
        RuleFor(x => x.BusinessKey).NotEmpty();
    }
}