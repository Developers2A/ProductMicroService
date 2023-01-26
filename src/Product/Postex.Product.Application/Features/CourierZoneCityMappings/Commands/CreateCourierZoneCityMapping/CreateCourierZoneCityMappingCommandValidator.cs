using FluentValidation;

namespace Postex.Product.Application.Features.CourierZoneCityMappings.Commands.CreateCourierZoneCityMapping
{
    public class CreateCourierZoneCityMappingCommandValidator : AbstractValidator<CreateCourierZoneCityMappingCommand>
    {
        public CreateCourierZoneCityMappingCommandValidator()
        {
            RuleFor(p => p.CityId)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" شهر الزامی میباشد");

            RuleFor(p => p.CourierZoneId)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" زون الزامی میباشد");
        }
    }
}
