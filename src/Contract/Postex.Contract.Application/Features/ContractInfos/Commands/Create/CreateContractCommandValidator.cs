using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.Contracts.Commands.CreateContractCommand
{
    public class CreateContractCommandValidator:AbstractValidator<CreateContractCommand>
    {
        public CreateContractCommandValidator()
        {
            RuleFor(p=> p.ContractNo).
                NotEmpty().NotNull().WithMessage("شماره قرارداد الزامی می باشد");
        }
    }
}
