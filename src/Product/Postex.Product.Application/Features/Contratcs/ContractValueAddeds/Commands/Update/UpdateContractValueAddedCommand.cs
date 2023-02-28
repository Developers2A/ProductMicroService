using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Commands.Update
{
    public class UpdateContractValueAddedCommand : ITransactionRequest<ContractValueAddedDto>
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int ValueAddedTypeId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public bool IsActive { get; set; }
        public decimal SalePrice { get; set; }
        public decimal BuyPrice { get; set; }
        public string Description { get; set; }
    }
}
