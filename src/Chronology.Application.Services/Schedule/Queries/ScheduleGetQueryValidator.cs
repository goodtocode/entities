using FluentValidation;

namespace GoodToCode.Chronology.Application
{
    public class GetLatestExamResultQueryValidator : AbstractValidator<ScheduleGetQuery>
    {
        public GetLatestExamResultQueryValidator()
        {
            RuleFor(v => v.QueryPredicate).NotEmpty().NotNull();
        }
    }
}