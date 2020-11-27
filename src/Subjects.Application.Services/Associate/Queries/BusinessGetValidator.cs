using FluentValidation;

namespace GoodToCode.Subjects.Application
{
    public class BusinessGetValidator : AbstractValidator<BusinessGetQuery>
    {
        public BusinessGetValidator()
        {
            RuleFor(v => v.BusinessKey).NotEmpty().NotNull();
        }
    }
}