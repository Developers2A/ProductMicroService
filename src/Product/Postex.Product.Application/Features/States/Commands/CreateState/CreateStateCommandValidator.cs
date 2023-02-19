﻿using FluentValidation;

namespace Postex.Product.Application.Features.States.Commands.CreateState
{
    public class CreateStateCommandValidator : AbstractValidator<CreateStateCommand>
    {
        public CreateStateCommandValidator()
        {
            RuleFor(p => p.Name)
                 .NotEmpty().WithMessage(" نام الزامی میباشد");
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage(" کد استان الزامی میباشد");
        }
    }
}
