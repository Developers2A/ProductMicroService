using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractItemTypes.Commands.UpdateContractItemType
{
    public class UpdateContractItemTypeCommandValidator:AbstractValidator<UpdateContractItemTypeCommand>
    {
        public UpdateContractItemTypeCommandValidator()
        {
            RuleFor(p => p.ContractTypeCode)
                  .NotEmpty().WithMessage(" کد آیتم الزامی میباشد");
            RuleFor(p => p.ContractTypeName)
                 .NotEmpty().WithMessage(" نام آیتم الزامی میباشد");
        }
    }
}
