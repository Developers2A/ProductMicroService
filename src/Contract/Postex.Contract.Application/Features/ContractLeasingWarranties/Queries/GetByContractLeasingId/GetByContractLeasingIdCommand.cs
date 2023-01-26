using MediatR;
using Postex.Contract.Application.Contracts;
using Postex.Contract.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractLeasingWarranties.Queries.GetById
{

    public class GetByContractLeasingIdCommand : IRequest<ContractLeasingWarrantyDto>
    {
        public int ContractLeasingId { get; set; }
    }
}
