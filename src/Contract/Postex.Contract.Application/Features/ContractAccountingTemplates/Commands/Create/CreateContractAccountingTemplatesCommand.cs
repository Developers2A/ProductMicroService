using Postex.Contract.Application.Contracts;
using Postex.Contract.Domain;

namespace Postex.Contract.Application.Features.ContractAccountingTemplates.Commands.Create
{
    public class CreateContractAccountingTemplatesCommand: ITransactionRequest
    {
        public List<CreateContractAccountingTemplateCommand> ContractAccountingTemplates { get; set; }
    }
}
