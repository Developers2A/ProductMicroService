using FluentValidation;
using Postex.ProfileManagement.Application.Features.CustomerCods.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.ProfileManagement.Application.Features.Customers.Commands.Create
{
    public class UpdateCustomerCodCommandValidator : AbstractValidator<CreateCustomerCodCommand>
    {
        public UpdateCustomerCodCommandValidator()
        {
            //RuleFor(p=> p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام الزامی می باشد");
            //RuleFor(p => p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام خانوادگی الزامی می باشد");
        }
    }
}
