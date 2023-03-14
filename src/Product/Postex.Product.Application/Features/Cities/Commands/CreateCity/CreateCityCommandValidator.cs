using FluentValidation;

namespace Postex.Product.Application.Features.Cities.Commands.CreateCity
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator()
        {
            RuleFor(p => p.Name)
                  .NotEmpty().NotNull().WithMessage(" نام الزامی میباشد");
            RuleFor(p => p.ProvinceId)
                 .NotEmpty().NotNull().GreaterThan(0).WithMessage(" استان الزامی میباشد");
        }
    }
}
