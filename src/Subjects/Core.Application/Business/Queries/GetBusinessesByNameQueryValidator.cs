using FluentValidation;

namespace Goodtocode.Subjects.Application;

public class GetBusinessesByNameQueryValidator : AbstractValidator<GetBusinessesByNameQuery>
{
    public GetBusinessesByNameQueryValidator()
    {
        RuleFor(x => x.BusinessName).NotEmpty();
        RuleFor(x => x.PageSize).GreaterThan(0);
        RuleFor(x => x.PageNumber).GreaterThan(0);
    }
}