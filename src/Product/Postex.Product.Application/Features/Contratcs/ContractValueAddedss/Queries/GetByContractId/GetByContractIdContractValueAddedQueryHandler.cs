using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractItems.Queries.GetByContractId
{
    public class GetByContractIdContractValueAddedQueryHandler : IRequestHandler<GetByContractIdContractValueAddedQuery, List<ContractItemDto>>
    {
        private readonly IReadRepository<ContractItem> _readRepository;

        public GetByContractIdContractValueAddedQueryHandler(IReadRepository<ContractItem> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<ContractItemDto>> Handle(GetByContractIdContractValueAddedQuery request, CancellationToken cancellationToken)
        {
            var items = await _readRepository.Table.Include(b => b.ContractItemType)
                .Select(c => new ContractItemDto
                {
                    ContractInfoId = c.ContractInfoId,
                    CourierId = c.CourierId,
                    ContractItemTypeId = c.ContractItemTypeId,
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
