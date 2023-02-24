using FluentValidation;
using Postex.Product.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractAccountingTemplates.Commands.Create
{
    public class CreateContractAccountingTemplatesValidator : AbstractValidator<CreateContractAccountingTemplatesCommand>
    {
        public CreateContractAccountingTemplatesValidator()
        {

            RuleFor(p => p.ContractAccountingTemplates.Sum(c => c.PercentValue))
                  .Equal(100).WithMessage("مجموع درصد ها باید 100 باشد");

        }
    }
}
