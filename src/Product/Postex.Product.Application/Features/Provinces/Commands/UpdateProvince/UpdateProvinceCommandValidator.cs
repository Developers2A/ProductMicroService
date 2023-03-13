using FluentValidation;

namespace Postex.Product.Application.Features.Provinces.Commands.UpdateProvince
{
    public class UpdateProvinceCommandValidator : AbstractValidator<UpdateProvinceCommand>
    {
        public UpdateProvinceCommandValidator()
        {
            RuleFor(p => p.Id)
                  .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
