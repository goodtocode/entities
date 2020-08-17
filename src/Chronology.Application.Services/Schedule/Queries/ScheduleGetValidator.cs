using FluentValidation;

namespace GoodToCode.Chronology.Application
{
    public class ScheduleGetValidator : AbstractValidator<ScheduleGetQuery>
    {
        public ScheduleGetValidator()
        {
            RuleFor(v => v.QueryPredicate).NotEmpty().NotNull();
        }
    }
}