using FluentValidation;

namespace Postex.Product.Application.Features.CourierCityMappings.Commands.UpdateCourierMapping
{
    public class UpdateCourierCityMappingCommandValidator : AbstractValidator<UpdateCourierCityMappingCommand>
    {
        public UpdateCourierCityMappingCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.CityId)
                .NotEmpty().GreaterThan(0).WithMessage(" شهر الزامی میباشد");

            RuleFor(p => p.CourierId)
                .NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");

            RuleFor(p => p.Code)
               .NotEmpty().NotNull().WithMessage(" کد الزامی میباشد");

            RuleFor(p => p.MappedCode)
               .NotEmpty().NotNull().WithMessage(" کد نگاشت شده الزامی میباشد");
        }
    }
}
