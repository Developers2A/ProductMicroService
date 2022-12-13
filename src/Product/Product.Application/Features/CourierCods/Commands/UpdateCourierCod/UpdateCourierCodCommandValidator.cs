using FluentValidation;

namespace Product.Application.Features.CourierCods.Commands.UpdateCourierCod
{
    public class UpdateCourierCodCommandValidator : AbstractValidator<UpdateCourierCodCommand>
    {
        public UpdateCourierCodCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.CourierId)
                .NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");
        }
    }
}
