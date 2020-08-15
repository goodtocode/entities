using FluentValidation;

namespace GoodToCode.Subjects.Application
{
    public class GetLatestExamResultQueryValidator : AbstractValidator<BusinessGetQuery>
    {
        public GetLatestExamResultQueryValidator()
        {
            RuleFor(v => v.QueryPredicate).NotEmpty().NotNull();
        }
    }
}