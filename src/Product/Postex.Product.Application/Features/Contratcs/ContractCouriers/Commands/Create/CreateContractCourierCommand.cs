using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractCouriers.Commands.Create
{
    public class CreateContractCourierCommand : ITransactionRequest<ContractCourierDto>
    {
        public int ContractInfoId { get; set; }
        public int CourierId { get; set; }
        public int FixedDiscount { get; set; }
        public double PercentDiscount { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }

    }
}
