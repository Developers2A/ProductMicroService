using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Commands.UpdateWeight
{
    public class UpdatePostWeightCommandValidator : AbstractValidator<UpdatePostWeightCommand>
    {
        public UpdatePostWeightCommandValidator()
        {
            RuleFor(p => p.ParcelCode)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
