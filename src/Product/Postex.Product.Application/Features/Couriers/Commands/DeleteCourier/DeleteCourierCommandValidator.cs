using FluentValidation;

namespace Postex.Product.Application.Features.Couriers.Commands.DeleteCourier
{
    public class DeleteCourierCommandValidator : AbstractValidator<DeleteCourierCommand>
    {
        public DeleteCourierCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().NotEmpty().WithMessage(" شناسه الزامی میباشد");
        }
    }
}
