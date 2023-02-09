using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.ProfileManagement.Application.Features.CustomerCods.Commands.Create
{
    public class CreateCustomerCodCommandValidator : AbstractValidator<CreateCustomerCodCommand>
    {
        public CreateCustomerCodCommandValidator()
        {
            //RuleFor(p=> p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام الزامی می باشد");
            //RuleFor(p => p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام خانوادگی الزامی می باشد");
        }
    }
}
