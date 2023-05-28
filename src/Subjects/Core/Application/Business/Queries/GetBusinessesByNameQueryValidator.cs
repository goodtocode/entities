using FluentValidation;

namespace Goodtocode.Subjects.Application;

public class GetBusinessesByNameQueryValidator : AbstractValidator<GetBusinessesByNameQuery>
{
    public GetBusinessesByNameQueryValidator()
    {
        RuleFor(x => x.BusinessName).NotEmpty();
    }
}