﻿using FluentValidation;

namespace Product.Application.Features.CourierServices.Link.Commands.CreateOrder
{
    public class CreateLinkOrderCommandValidator : AbstractValidator<CreateLinkOrderCommand>
    {
        public CreateLinkOrderCommandValidator()
        {
            //RuleFor(p => p.CustomerName)
            //      .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
