using FluentValidation;

namespace GoodToCode.Shared.Domain
{
    public class GetLatestExamResultQueryValidator : AbstractValidator<BusinessGetQuery>
    {
        public GetLatestExamResultQueryValidator()
        {
            RuleFor(v => v.QueryPredicate).NotEmpty().NotNull();
        }
    }
}