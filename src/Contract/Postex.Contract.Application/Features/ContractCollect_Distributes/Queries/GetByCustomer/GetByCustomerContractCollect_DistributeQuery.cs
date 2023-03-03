using MediatR;
using Postex.Contract.Application.Contracts;
using Postex.Contract.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractCollect_Distributes.Queries.GetByCustomer
{
    public class GetByCustomerContractCollect_DistributeQuery : IRequest<List<ContractCollect_DistributeDto>>
    {
        public Guid? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
