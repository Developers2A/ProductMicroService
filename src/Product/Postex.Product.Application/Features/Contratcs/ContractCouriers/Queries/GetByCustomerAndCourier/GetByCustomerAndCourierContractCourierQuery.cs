using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByCustomerAndCourier
{
    public class GetByCustomerAndCourierContractCourierQuery : IRequest<CourierServicePriceDto>
    {
        public int CourierServiceId { get; set; }
        public int? CustomerId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
    }
}
