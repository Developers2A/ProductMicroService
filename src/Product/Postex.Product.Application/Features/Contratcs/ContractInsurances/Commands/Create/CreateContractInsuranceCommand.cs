using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractInsurances.Commands.Create
{
    public class CreateContractInsuranceCommand : ITransactionRequest<ContractInsuranceDto>
    {
        public int ContractInfoId { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public double FixedPercent { get; set; }
        public int FixedValue { get; set; }
        public string Description { get; set; }
        public bool IsActice { get; set; }

    }
}
