using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractInfos.Commands.Create
{
    public class CreateContractCommandValidator : AbstractValidator<CreateContractCommand>
    {
        public CreateContractCommandValidator()
        {
            RuleFor(p => p.ContractNo).
                NotEmpty().NotNull().WithMessage("شماره قرارداد الزامی می باشد");

        }
    }
}
