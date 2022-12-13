using FluentValidation;

namespace Product.Application.Features.SLAs.Commands.DeleteSLA
{
    public class DeleteSLACommandValidator : AbstractValidator<DeleteSLACommand>
    {
        public DeleteSLACommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().NotEmpty().WithMessage(" شناسه الزامی میباشد");
        }
    }
}
