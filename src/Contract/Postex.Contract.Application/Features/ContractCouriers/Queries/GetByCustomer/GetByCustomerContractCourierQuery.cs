using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractCouriers.Queries.GetByCustomer
{
    public class GetByCustomerContractCourierQuery : IRequest<List<ContractCourierDto>>
    {
        public Guid? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
