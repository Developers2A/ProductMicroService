using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByUserAndBoxType
{
    public class GetByUserAndBoxTypeContractBoxPriceQuery : IRequest<BoxPriceDto>
    {
        public int BoxTypeId { get; set; }
        public Guid? UserId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }

    }
}
