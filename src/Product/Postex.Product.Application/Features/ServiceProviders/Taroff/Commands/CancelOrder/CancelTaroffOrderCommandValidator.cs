﻿using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.CancelOrder
{
    public class CancelTaroffOrderCommandValidator : AbstractValidator<CancelTaroffOrderCommand>
    {
        public CancelTaroffOrderCommandValidator()
        {
            RuleFor(p => p.OrderId)
                  .NotEmpty().NotNull().GreaterThan(0).WithMessage(" شماره سفارش الزامی میباشد");
        }
    }
}
