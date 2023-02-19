using Postex.Product.Application.Contracts;
using Postex.Product.Domain;

namespace Postex.Product.Application.Features.ContractAccountingTemplates.Commands.Create
{
    public class CreateContractAccountingTemplateCommand: ITransactionRequest
    {
        public int ContractInfoId { get; set; }
        public string ContractDetailType { get; set; }
        public int ContractDetailId { get; set; }
        public Guid CustomerId { get; set; }
        public double PercentValue { get; set; }
        public int FixedValue { get; set; }
        public string Description { get; set; }
    }
}
