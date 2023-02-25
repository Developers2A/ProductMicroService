﻿using MediatR;
using Postex.UserManagement.Application.Dtos.Customers;

namespace Postex.UserManagement.Application.Features.CustomerCods.Queries.GetByCustomerId
{
    public class GetByCustomerIdQuery : IRequest<CustomerCodDto>
    {
        public Guid CustomerId { get; set; }
    }
}
