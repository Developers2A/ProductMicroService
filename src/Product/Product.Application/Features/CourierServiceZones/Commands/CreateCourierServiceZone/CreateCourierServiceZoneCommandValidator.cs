using FluentValidation;

namespace Product.Application.Features.CourierServiceZones.Commands.CreateCourierServiceZone
{
    public class CreateCourierServiceZoneCommandValidator : AbstractValidator<CreateCourierServiceZoneCommand>
    {
        public CreateCourierServiceZoneCommandValidator()
        {
            RuleFor(p => p.CourierServiceId).
                NotEmpty().GreaterThan(0).WithMessage(" شناسه اس ال ای الزامی میباشد");

            RuleFor(p => p.ZoneId).
               NotEmpty().GreaterThan(0).WithMessage(" شناسه زون الزامی میباشد");

            RuleFor(p => p.CourierId).
              NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");

            RuleFor(p => p.CityFromId).
              NotEmpty().GreaterThan(0).WithMessage(" شهر مبدا الزامی میباشد");

            RuleFor(p => p.CityToId).
              NotEmpty().GreaterThan(0).WithMessage(" شهر مقصد الزامی میباشد");
        }
    }
}
