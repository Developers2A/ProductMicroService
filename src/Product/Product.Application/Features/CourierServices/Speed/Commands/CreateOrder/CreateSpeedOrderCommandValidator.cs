using FluentValidation;

namespace Product.Application.Features.CourierServices.Speed.Commands.CreateOrder
{
    public class CreateSpeedOrderCommandValidator : AbstractValidator<CreateSpeedOrderCommand>
    {
        public CreateSpeedOrderCommandValidator()
        {
        }
    }
}
