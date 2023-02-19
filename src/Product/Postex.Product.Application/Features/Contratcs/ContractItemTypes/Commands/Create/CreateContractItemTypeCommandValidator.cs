using FluentValidation;
using Postex.Product.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractItemTypes.Commands.CreateContractItemType
{
    public class CreateContractItemTypeCommandValidator: AbstractValidator<CreateContractItemTypeCommand>
    {
        public CreateContractItemTypeCommandValidator()
        {
            RuleFor(p => p.ContractTypeCode)
                  .NotEmpty().WithMessage(" کد آیتم الزامی میباشد");
            RuleFor(p => p.ContractTypeName)
                 .NotEmpty().WithMessage(" نام آیتم الزامی میباشد");
        }
    }
}
