using FluentValidation;

namespace Product.Application.Features.CourierServiceZones.Commands.UpdateCourierServiceZone
{
    public class UpdateCourierServiceZoneCommandValidator : AbstractValidator<UpdateCourierServiceZoneCommand>
    {
        public UpdateCourierServiceZoneCommandValidator()
        {
            RuleFor(p => p.Id)
              .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.CourierId).
               NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");

            RuleFor(p => p.StateId).
                NotEmpty().GreaterThan(0).WithMessage(" استان الزامی میباشد");

            RuleFor(p => p.CourierServiceId).
               NotEmpty().GreaterThan(0).WithMessage(" شناسه اس ال ای الزامی میباشد");

            RuleFor(p => p.ZoneId).
               NotEmpty().GreaterThan(0).WithMessage(" شناسه زون الزامی میباشد");

            RuleFor(p => p.CityFromId).
              NotEmpty().GreaterThan(0).WithMessage(" شهر مبدا الزامی میباشد");

            RuleFor(p => p.CityToId).
              NotEmpty().GreaterThan(0).WithMessage(" شهر مقصد الزامی میباشد");
        }
    }
}
