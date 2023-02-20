using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ContractBoxPrices.Queries
{
    public class GetByCustomerContractBoxPriceQueryHandler : IRequestHandler<GetByContractIdContractBoxPriceQuery, List<ContractBoxPriceDto>>
    {
        private readonly IReadRepository<ContractBoxPrice> _readRepository;

        public GetByCustomerContractBoxPriceQueryHandler(IReadRepository<ContractBoxPrice> readRepository)
        {
            this._readRepository = readRepository;
        }
        public async Task<List<ContractBoxPriceDto>> Handle(GetByContractIdContractBoxPriceQuery request, CancellationToken cancellationToken)
        {
            var boxPrice = await _readRepository.Table.Include(b => b.BoxType)
                .Select(c => new ContractBoxPriceDto
                {
                    Id = c.Id,
                    ContractInfoId = c.ContractInfoId,
                    BoxTypeId = c.BoxTypeId,
                    CityId = c.CityId,
                    ProvinceId = c.ProvinceId,
                    CustomerId= c.CustomerId,
                    SalePrice = c.SalePrice,
                    BuyPrice = c.BuyPrice,
                    BoxName = c.BoxType.Name,
                    Height = c.BoxType.Height,
                    Width = c.BoxType.Width,
                    Length = c.BoxType.Length,
                    Description=c.Description,
                    IsActive = c.IsActive,

                })
                .Where(c=> c.ContractInfoId == request.ContractInfoId)
                .ToListAsync(cancellationToken);
            return boxPrice;
        }
    }
}
