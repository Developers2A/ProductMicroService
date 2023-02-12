﻿using MediatR;
using Postex.ProfileManagement.Application.Dtos;

namespace Postex.ProfileManagement.Application.Features.Customers.Queries
{
    public class GetByIdQuery:IRequest<CustomerDto>
    {
        public int Id { get; set; }
    }
}