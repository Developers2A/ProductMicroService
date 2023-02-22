using MediatR;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.ContractCouriers.Queries
{
    public class GetByCustomerContractCourierQuery : IRequest<List<ContractCourierDto>>
    {
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
