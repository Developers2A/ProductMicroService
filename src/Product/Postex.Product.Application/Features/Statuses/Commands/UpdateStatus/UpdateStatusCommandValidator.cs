using FluentValidation;

namespace Postex.Product.Application.Features.Statuses.Commands.UpdateStatus
{
    public class UpdateStatusCommandValidator : AbstractValidator<UpdateStatusCommand>
    {
        public UpdateStatusCommandValidator()
        {
            RuleFor(p => p.Id)
                  .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
