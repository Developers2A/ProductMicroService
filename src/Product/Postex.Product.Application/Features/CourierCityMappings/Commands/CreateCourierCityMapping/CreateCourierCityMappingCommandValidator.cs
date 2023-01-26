using FluentValidation;

namespace Postex.Product.Application.Features.CourierCityMappings.Commands.CreateCourierCityMapping
{
    public class CreateCourierCityMappingCommandValidator : AbstractValidator<CreateCourierCityMappingCommand>
    {
        public CreateCourierCityMappingCommandValidator()
        {
            RuleFor(p => p.CityId)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" شهر الزامی میباشد");

            RuleFor(p => p.CourierId)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");

            RuleFor(p => p.Code)
               .NotEmpty().NotNull().WithMessage(" کد الزامی میباشد");

            RuleFor(p => p.MappedCode)
               .NotEmpty().NotNull().WithMessage(" کد نگاشت شده الزامی میباشد");
        }
    }
}
