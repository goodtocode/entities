using FluentValidation;

namespace GoodToCode.Locality.Application
{
    public class LocationGetValidator : AbstractValidator<LocationGetQuery>
    {
        public LocationGetValidator()
        {
            RuleFor(v => v.QueryPredicate).NotEmpty().NotNull();
        }
    }
}