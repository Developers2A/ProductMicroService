﻿using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Bsw.Commands.CreateOrder
{
    public class CreateBswOrderCommandValidator : AbstractValidator<CreateBswOrderCommand>
    {
        public CreateBswOrderCommandValidator()
        {
            //RuleFor(p => p.CustomerName)
            //      .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
