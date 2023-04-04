using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByUserAndCourier
{
    public class GetByUserAndCourierContractCourierQuery : IRequest<CourierServicePriceDto>
    {
        public int CourierServiceId { get; set; }
        public Guid? UserId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
