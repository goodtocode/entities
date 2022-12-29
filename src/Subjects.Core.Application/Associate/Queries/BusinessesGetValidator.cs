using FluentValidation;

namespace GoodToCode.Subjects.Application
{
    public class BusinessesGetValidator : AbstractValidator<BusinessesGetQuery>
    {
        public BusinessesGetValidator()
        {
            RuleFor(v => v.QueryPredicate).NotEmpty().NotNull();
        }
    }
}