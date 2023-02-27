using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByCustomerAndCourier
{
    public class GetByCustomerAndCourierContractCourierQuery : IRequest<List<ContractCourierDto>>
    {
        public int CourierId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
