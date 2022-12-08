using FluentValidation;

namespace Product.Application.Features.CourierStatusMappings.Commands.DeleteCourierStatusMapping
{
    public class DeleteCourierStatusMappingCommandValidator : AbstractValidator<DeleteCourierStatusMappingCommand>
    {
        public DeleteCourierStatusMappingCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage(" شناسه الزامی میباشد");
        }
    }
}
