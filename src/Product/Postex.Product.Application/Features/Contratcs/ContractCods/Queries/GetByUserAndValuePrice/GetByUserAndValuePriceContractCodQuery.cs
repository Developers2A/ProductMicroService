using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractCods.Queries.GetByUserAndValuePrice
{
    public class GetByUserAndValuePriceContractCodQuery : IRequest<CodPriceDto>
    {
        public double ValuePrice { get; set; }
        public Guid? UserId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
