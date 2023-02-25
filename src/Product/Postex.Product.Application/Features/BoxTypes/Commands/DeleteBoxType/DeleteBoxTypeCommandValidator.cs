using FluentValidation;

namespace Postex.Product.Application.Features.BoxTypes.Commands.DeleteBoxType
{
    public class DeleteBoxTypeCommandValidator : AbstractValidator<DeleteBoxTypeCommand>
    {
        public DeleteBoxTypeCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().NotEmpty().WithMessage(" شناسه الزامی میباشد");
        }
    }
}
