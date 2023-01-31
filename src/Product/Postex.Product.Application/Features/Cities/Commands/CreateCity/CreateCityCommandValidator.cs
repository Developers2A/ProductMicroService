using FluentValidation;

namespace Postex.Product.Application.Features.Cities.Commands.CreateCity
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator()
        {
            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
            RuleFor(p => p.StateId)
                 .NotEmpty().WithMessage(" استان الزامی میباشد");
        }
    }
}
