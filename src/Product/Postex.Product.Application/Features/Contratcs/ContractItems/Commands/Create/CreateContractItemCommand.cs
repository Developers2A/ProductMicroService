using Postex.Product.Application.Contracts;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.ContractItems.Commands.CreateContractItem
{
    public class CreateContractItemCommand : ITransactionRequest
    {
        public int ContractInfoId { get; set; }
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
