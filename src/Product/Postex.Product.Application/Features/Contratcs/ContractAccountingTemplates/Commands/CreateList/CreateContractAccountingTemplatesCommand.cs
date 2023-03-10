using Postex.Product.Application.Contracts;
using Postex.Product.Application.Features.Contratcs.ContractAccountingTemplates.Commands.Create;
using Postex.Product.Domain;

namespace Postex.Product.Application.Features.Contratcs.ContractAccountingTemplates.Commands.CreateList
{
    public class CreateContractAccountingTemplatesCommand : ITransactionRequest
    {
        public List<CreateContractAccountingTemplateCommand> ContractAccountingTemplates { get; set; }
    }
}
