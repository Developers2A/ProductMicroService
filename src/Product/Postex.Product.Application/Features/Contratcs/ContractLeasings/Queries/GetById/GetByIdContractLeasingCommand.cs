using MediatR;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractLeasings.Queries.GetById
{

    public class GetByIdContractLeasingCommand : IRequest<ContractLeasingDto>
    {
        public int Id { get; set; }
    }
}
