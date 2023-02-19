﻿using MediatR;
using Postex.ProfileManagement.Application.Dtos;

namespace Postex.ProfileManagement.Application.Features.CustomerCods.Queries
{
    public class GetByCustomerIdQuery : IRequest<CustomerCodDto>
    {
        public Guid CustomerId { get; set; }
    }
}
