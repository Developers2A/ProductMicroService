using FluentValidation;

namespace Product.Application.Features.Statuses.Commands.CreateStatus
{
    public class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
    {
        public CreateStatusCommandValidator()
        {
            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
