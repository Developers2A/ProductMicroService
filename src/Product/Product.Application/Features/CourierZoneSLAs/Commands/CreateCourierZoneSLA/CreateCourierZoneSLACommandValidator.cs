using FluentValidation;

namespace Product.Application.Features.CourierZoneSLAs.Commands.CreateCourierZoneSLA
{
    public class CreateCourierZoneSLACommandValidator : AbstractValidator<CreateCourierZoneSLACommand>
    {
        public CreateCourierZoneSLACommandValidator()
        {
            RuleFor(p => p.SLAId).
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
