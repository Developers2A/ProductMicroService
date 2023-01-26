using FluentValidation;

namespace Postex.Product.Application.Features.Zones.Commands.UpdateZone
{
    public class UpdateZoneCommandValidator : AbstractValidator<UpdateZoneCommand>
    {
        public UpdateZoneCommandValidator()
        {
            RuleFor(p => p.Id)
                  .NotEmpty().WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
