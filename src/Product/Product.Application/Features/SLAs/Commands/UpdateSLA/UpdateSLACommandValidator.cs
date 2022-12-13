using FluentValidation;

namespace Product.Application.Features.SLAs.Commands.UpdateSLA
{
    public class UpdateSLACommandValidator : AbstractValidator<UpdateSLACommand>
    {
        public UpdateSLACommandValidator()
        {
            RuleFor(p => p.Id)
                  .NotEmpty().WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
