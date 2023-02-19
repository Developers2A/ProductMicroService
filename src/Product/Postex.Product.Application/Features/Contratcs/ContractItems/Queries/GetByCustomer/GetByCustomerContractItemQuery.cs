﻿using MediatR;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.ContractItems.Queries
{
    public class GetByCustomerContractItemQuery : IRequest<List<ContractItemDto>>
    {
        public Guid? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
