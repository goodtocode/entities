using FluentValidation;

namespace GoodToCode.Occurrences.Application
{
    public class EventGetQueryValidator : AbstractValidator<EventGetQuery>
    {
        public EventGetQueryValidator()
        {
            RuleFor(v => v.QueryPredicate).NotEmpty().NotNull();
        }
    }
}