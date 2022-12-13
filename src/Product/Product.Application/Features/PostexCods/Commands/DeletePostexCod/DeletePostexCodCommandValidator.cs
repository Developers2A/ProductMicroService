using FluentValidation;

namespace Product.Application.Features.PostexCods.Commands.DeletePostexCod
{
    public class DeletePostexCodCommandValidator : AbstractValidator<DeletePostexCodCommand>
    {
        public DeletePostexCodCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");
        }
    }
}
