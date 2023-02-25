using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractItems.Commands.Create
{
    public class CreateContractItemCommand : ITransactionRequest<ContractItemDto>
    {
        public int ContractInfoId { get; set; }
        public int CourierId { get; set; }
        public int ContractItemTypeId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public bool IsActive { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string? Description { get; set; }
    }
}
