﻿using FluentValidation;

namespace Postex.UserManagement.Application.Features.UserInvoiceInfos.Commands.Create
{
    public class CreateUserInvoiceInfoCommandValidator : AbstractValidator<CreateUserInvoiceInfoCommand>
    {
        public CreateUserInvoiceInfoCommandValidator()
        {
            //RuleFor(p=> p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام الزامی می باشد");
            //RuleFor(p => p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام خانوادگی الزامی می باشد");
        }
    }
}
