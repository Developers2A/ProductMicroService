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

namespace Postex.Contract.Application.Features.ContractItems.Queries.GetByContractId
{
    public class GetByContractIdContractItemQueryHandler : IRequestHandler<GetByContractIdContractItemQuery, List<ContractItemDto>>
    {
        private readonly IReadRepository<ContractItem> _readRepository;

        public GetByContractIdContractItemQueryHandler(IReadRepository<ContractItem> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<ContractItemDto>> Handle(GetByContractIdContractItemQuery request, CancellationToken cancellationToken)
        {
            var items = await _readRepository.Table.Include(b => b.ContractItemType)
                .Select(c => new ContractItemDto
                {
                    ContractInfoId = c.ContractInfoId,
                    CourierId = c.CourierId,
                    ContractItemTypeId = c.ContractItemTypeId,
                    ContractTypeCode = c.ContractItemType.ContractTypeCode,
                    ContractTypeName = c.ContractItemType.ContractTypeName,
                    ProvinceId = c.ProvinceId,
                    CityId = c.CityId,
                    IsActive = c.IsActive,
                    SalePrice = c.SalePrice,
                    BuyPrice = c.BuyPrice,
                    Description = c.Description,
                })
                .ToListAsync(cancellationToken);
            return items;
        }
    }

}
