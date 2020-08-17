using FluentValidation;

namespace GoodToCode.Locality.Application
{
    public class GetLatestExamResultQueryValidator : AbstractValidator<LocationGetQuery>
    {
        public GetLatestExamResultQueryValidator()
        {
            RuleFor(v => v.QueryPredicate).NotEmpty().NotNull();
        }
    }
}