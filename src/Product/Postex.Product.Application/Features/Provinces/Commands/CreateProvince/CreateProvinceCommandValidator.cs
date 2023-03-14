using FluentValidation;

namespace Postex.Product.Application.Features.Provinces.Commands.CreateProvince
{
    public class CreateProvinceCommandValidator : AbstractValidator<CreateProvinceCommand>
    {
        public CreateProvinceCommandValidator()
        {
            RuleFor(p => p.Name)
                 .NotEmpty().WithMessage(" نام الزامی میباشد");
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage(" کد استان الزامی میباشد");
        }
    }
}
