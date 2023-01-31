using FluentValidation;

namespace Postex.Product.Application.Features.CourierStatusMappings.Commands.UpdateCourierStatusMapping
{
    public class UpdateCourierStatusMappingCommandValidator : AbstractValidator<UpdateCourierStatusMappingCommand>
    {
        public UpdateCourierStatusMappingCommandValidator()
        {
            RuleFor(p => p.Id)
              .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.CourierId)
                .NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");

            RuleFor(p => p.StatusId)
                .NotEmpty().GreaterThan(0).WithMessage(" وضعیت الزامی میباشد");

            RuleFor(p => p.Code).
               NotEmpty().NotNull().WithMessage(" کد الزامی میباشد");
        }
    }
}
