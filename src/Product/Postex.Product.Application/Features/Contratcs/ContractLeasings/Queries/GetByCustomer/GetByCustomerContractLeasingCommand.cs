﻿using MediatR;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractLeasings.Queries.GetByCustomer
{

    public class GetByCustomerContractLeasingCommand : IRequest<ContractLeasingDto>
    {
        public int CustomerId { get; set; }
    }
}
