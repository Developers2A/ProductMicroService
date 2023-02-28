using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Commands.Update
{
    public class UpdateContractBoxPriceCommand : ITransactionRequest<ContractBoxPriceDto>
    {
        public int Id { get; set; }
        public int BoxTypeId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? CustomerId { get; set; }
        public decimal SalePrice { get; set; }
        public decimal BuyPrice { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
