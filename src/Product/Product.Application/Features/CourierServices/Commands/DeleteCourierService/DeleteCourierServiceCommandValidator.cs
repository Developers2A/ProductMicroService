using FluentValidation;

namespace Product.Application.Features.CourierServices.Commands.DeleteCourierService
{
    public class DeleteCourierServiceCommandValidator : AbstractValidator<DeleteCourierServiceCommand>
    {
        public DeleteCourierServiceCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().NotEmpty().WithMessage(" شناسه الزامی میباشد");
        }
    }
}
