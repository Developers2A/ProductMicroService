using FluentValidation;

namespace Postex.Product.Application.Features.CourierZoneCityMappings.Commands.UpdateCourierZoneCityMapping
{
    public class UpdateCourierZoneCityMappingCommandValidator : AbstractValidator<UpdateCourierZoneCityMappingCommand>
    {
        public UpdateCourierZoneCityMappingCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.CityId)
                .NotEmpty().GreaterThan(0).WithMessage(" شهر الزامی میباشد");

            RuleFor(p => p.CourierZoneId)
                .NotEmpty().GreaterThan(0).WithMessage(" زون الزامی میباشد");
        }
    }
}
