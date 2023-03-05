using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByContractId
{
    public class GetByContractIdContractValueAddedQueryHandler : IRequestHandler<GetByContractIdContractValueAddedQuery, List<ContractValueAddedDto>>
    {
        private readonly IReadRepository<ContractValueAdded> _readRepository;

        public GetByContractIdContractValueAddedQueryHandler(IReadRepository<ContractValueAdded> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<ContractValueAddedDto>> Handle(GetByContractIdContractValueAddedQuery request, CancellationToken cancellationToken)
        {
            var items = await _readRepository.Table.Include(b => b.ValueAddedType)
                .Select(c => new ContractValueAddedDto
                {
                    ContractInfoId = c.ContractInfoId,
                    CourierId = c.CourierId,
                    ValueAddedTypeId = c.ValueAddedTypeId,
                    StateId = c.StateId,
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
