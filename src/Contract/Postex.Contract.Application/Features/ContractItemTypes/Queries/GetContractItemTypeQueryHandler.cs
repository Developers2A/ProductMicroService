using MediatR;

using Postex.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Postex.Contract.Application.Dtos;
using Postex.Contract.Domain;

namespace Postex.Contract.Application.Features.ContractItemTypes.Queries
{
    public class GetContractItemTypeQueryHandler : IRequestHandler<GetContractItemTypeQuery, List<ContractItemTypeDto>>
        {
            private readonly IReadRepository<ContractItemType> _readRepository;

            public GetContractItemTypeQueryHandler(IReadRepository<ContractItemType> readRepository)
            {
                _readRepository = readRepository;
            }

            public async Task<List<ContractItemTypeDto>> Handle(GetContractItemTypeQuery request, CancellationToken cancellationToken)
            {

                var contractItemTypes = await _readRepository.Table
                .Select(c=> new ContractItemTypeDto
                {
                    Id=c.Id,
                    ContractTypeCode=c.ContractTypeCode,
                    ContractTypeName=c.ContractTypeName,
                })
                    .OrderBy(x => x.ContractTypeCode)
                    .ToListAsync(cancellationToken);

                return contractItemTypes;
            }
        }
}
