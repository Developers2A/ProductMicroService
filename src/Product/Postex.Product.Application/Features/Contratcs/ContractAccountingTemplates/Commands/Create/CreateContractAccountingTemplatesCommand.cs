using Postex.Product.Application.Contracts;
using Postex.Product.Domain;

namespace Postex.Product.Application.Features.ContractAccountingTemplates.Commands.Create
{
    public class CreateContractAccountingTemplatesCommand: ITransactionRequest
    {
        public List<CreateContractAccountingTemplateCommand> ContractAccountingTemplates { get; set; }
    }
}
