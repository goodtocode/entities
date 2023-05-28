using FluentValidation;

namespace Goodtocode.Subjects.Application;

public class GetBusinessQueryValidator : AbstractValidator<GetBusinessQuery>
{
    public GetBusinessQueryValidator()
    {
        RuleFor(x => x.BusinessName).NotEmpty();
    }
}