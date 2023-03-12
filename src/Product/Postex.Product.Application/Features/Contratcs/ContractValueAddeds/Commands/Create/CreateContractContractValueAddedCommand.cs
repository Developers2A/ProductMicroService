using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Commands.Create
{
    public class CreateContractContractValueAddedCommand : ITransactionRequest<ContractValueAddedDto>
    {
        public int ContractInfoId { get; set; }
        public int CourierId { get; set; }
        public int valueAddedTypeId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public bool IsActive { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string? Description { get; set; }
    }
}
