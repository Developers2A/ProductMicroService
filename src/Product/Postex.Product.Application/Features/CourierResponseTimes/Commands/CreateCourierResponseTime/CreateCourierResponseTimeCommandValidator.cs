using FluentValidation;

namespace Postex.Product.Application.Features.CourierResponseTimes.Commands.CreateCourierResponseTime;

public class CreateCourierResponseTimeCommandValidator : AbstractValidator<CreateCourierResponseTimeCommand>
{
    public CreateCourierResponseTimeCommandValidator()
    {
        RuleFor(p => p.ResponseTime)
              .NotEmpty().WithMessage(" زمان پاسخگویی به ثانیه الزامی میباشد");
    }
}
