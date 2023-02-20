using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractCouriers.Queries
{
    public class GetByContractIdContractCourierQueryHandler : IRequestHandler<GetByContractIdContractCourierQuery, List<ContractCourierDto>>
    {
        private readonly IReadRepository<ContractCourier> _readRepository;

        public GetByContractIdContractCourierQueryHandler(IReadRepository<ContractCourier> readRepository)
        {
            this._readRepository = readRepository;
        }
        public async Task<List<ContractCourierDto>> Handle(GetByContractIdContractCourierQuery request, CancellationToken cancellationToken)
        {
            var cod = await _readRepository.Table
                .Select(c => new ContractCourierDto
                {
                    Id = c.Id,
                    ContractInfoId = c.ContractInfoId,
                    CourierId = c.CourierId,
                    FixedDiscount=c.FixedDiscount,
                    PercentDiscount = c.PercentDiscount,
                    IsActive = c.IsActive,     
                    Description=c.Description,
                })
                .ToListAsync(cancellationToken);
            return cod;
        }
    }
   
}
