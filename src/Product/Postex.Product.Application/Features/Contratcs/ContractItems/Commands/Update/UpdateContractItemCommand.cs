using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.ContractItems.Commands.UpdateContractItem
{
    public class UpdateContractItemCommand : ITransactionRequest<ContractItemDto>
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public ValueAddedType ContractItemType { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public bool IsActive { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string Description { get; set; }
    }
}
