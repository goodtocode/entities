using FluentValidation;

namespace Goodtocode.Subjects.Application;

public class GetBusinessesAllQueryValidator : AbstractValidator<GetBusinessesAllQuery>
{
    public GetBusinessesAllQueryValidator()
    {
        RuleFor(x => x.BusinessName).NotEmpty();
        RuleFor(x => x.PageSize).GreaterThan(0);
        RuleFor(x => x.PageNumber).GreaterThan(0);
    }
}