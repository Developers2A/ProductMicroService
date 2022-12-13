﻿using FluentValidation;

namespace Product.Application.Features.PostexCods.Commands.UpdatePostexCod
{
    public class UpdatePostexCodCommandValidator : AbstractValidator<UpdatePostexCodCommand>
    {
        public UpdatePostexCodCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.CourierId)
                .NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");
        }
    }
}
