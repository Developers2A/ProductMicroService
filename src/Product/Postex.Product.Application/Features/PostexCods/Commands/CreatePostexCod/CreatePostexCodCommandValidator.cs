using FluentValidation;

namespace Postex.Product.Application.Features.PostexCods.Commands.CreatePostexCod
{
    public class CreatePostexCodCommandValidator : AbstractValidator<CreatePostexCodCommand>
    {
        public CreatePostexCodCommandValidator()
        {
            RuleFor(p => p.CourierId)
               .NotEmpty().GreaterThan(0).WithMessage("کوریر الزامی میباشد");
        }
    }
}
