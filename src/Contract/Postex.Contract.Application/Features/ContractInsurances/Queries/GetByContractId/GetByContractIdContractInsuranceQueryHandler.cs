using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Contract.Application.Dtos;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractInsurances.Queries
{
    public class GetByContractIdContractInsuranceQueryHandler : IRequestHandler<GetByContractIdContractInsuranceQuery, List<ContractInsuranceDto>>
    {
        private readonly IReadRepository<ContractInsurance> _readRepository;

        public GetByContractIdContractInsuranceQueryHandler(IReadRepository<ContractInsurance> readRepository)
        {
            this._readRepository = readRepository;
        }
        public async Task<List<ContractInsuranceDto>> Handle(GetByContractIdContractInsuranceQuery request, CancellationToken cancellationToken)
        {
            var insurance = await _readRepository.Table
                .Select(c => new ContractInsuranceDto
                {
                    Id=c.Id,
                    ContractInfoId = c.ContractInfoId,
                    FromValue = c.FromValue,
                    ToValue = c.ToValue,
                    FixedPercent = c.FixedPercent,
                    FixedValue = c.FixedValue,
                    Description=c.Description,
                })
                .ToListAsync(cancellationToken);
            return  insurance;
        }
    }
}
