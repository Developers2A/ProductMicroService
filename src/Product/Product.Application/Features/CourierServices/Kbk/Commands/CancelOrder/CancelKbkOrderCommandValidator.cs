﻿using FluentValidation;

namespace Product.Application.Features.CourierServices.Kbk.Commands.CancelOrder
{
    public class CancelKbkOrderCommandValidator : AbstractValidator<CancelKbkOrderCommand>
    {
        public CancelKbkOrderCommandValidator()
        {
            //RuleFor(p => p.CustomerName)
            //      .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
