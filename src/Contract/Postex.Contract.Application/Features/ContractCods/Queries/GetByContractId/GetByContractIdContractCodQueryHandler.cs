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

namespace Postex.Contract.Application.Features.ContractCods.Queries
{
    public class GetByContractIdContractCodQueryHandler : IRequestHandler<GetByContractIdContractCodQuery, List<ContractCodDto>>
    {
        private readonly IReadRepository<ContractCod> _readRepository;

        public GetByContractIdContractCodQueryHandler(IReadRepository<ContractCod> readRepository)
        {
            this._readRepository = readRepository;
        }
        public async Task<List<ContractCodDto>> Handle(GetByContractIdContractCodQuery request, CancellationToken cancellationToken)
        {
            var cod = await _readRepository.Table
                .Select(c => new ContractCodDto
                {
                    Id = c.Id,
                    ContractInfoId = c.ContractInfoId,
                    FromValue = c.FromValue,
                    ToValue = c.ToValue,
                    FixedPercent = c.FixedPercent,
                    FixedValue = c.FixedValue,
                    Description=c.Description,
                })
                .ToListAsync(cancellationToken);
            return cod;
        }
    }
   
}
