﻿using FluentValidation;

namespace Postex.Product.Application.Features.CourierStatusMappings.Commands.CreateCourierStatusMapping
{
    public class CreateCourierStatusMappingCommandValidator : AbstractValidator<CreateCourierStatusMappingCommand>
    {
        public CreateCourierStatusMappingCommandValidator()
        {
            RuleFor(p => p.CourierId).
                NotEmpty().NotNull().WithMessage(" کوریر الزامی میباشد");

            RuleFor(p => p.StatusId)
                .NotEmpty().GreaterThan(0).WithMessage(" وضعیت الزامی میباشد");

            RuleFor(p => p.Code).
                NotEmpty().NotNull().WithMessage(" کد الزامی میباشد");
        }
    }
}
