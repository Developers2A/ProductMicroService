using FluentValidation;

namespace Product.Application.Features.CourierCods.Commands.DeleteCourierCod
{
    public class DeleteCourierCodCommandValidator : AbstractValidator<DeleteCourierCodCommand>
    {
        public DeleteCourierCodCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");
        }
    }
}
