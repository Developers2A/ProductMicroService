using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Commands.Create
{
    public class CreateContractBoxPriceCommand : ITransactionRequest<ContractBoxPriceDto>
    {
        public int BoxTypeId { get; set; }
        public int ContractInfoId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? UserId { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
