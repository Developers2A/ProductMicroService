using FluentValidation;
using Postex.Contract.Application.Contracts;
using Postex.Contract.Application.Features.ContractAccountingTemplates.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractItemTypes.Commands.CreateContractItemType
{
    public class CreateContractAccountingTemplatesCommandValidator : AbstractValidator<CreateContractAccountingTemplatesCommand>
    {
        public CreateContractAccountingTemplatesCommandValidator()
        {

            RuleFor(p => p.ContractAccountingTemplates.Sum(c => c.PercentValue))
                  .Equal(100).WithMessage("مجموع درصد ها باید 100 باشد");
          
        }
    }
}
