using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractCollect_Distributes.Queries
{
    public class GetByContractIdContractCollect_DistributeQueryHandler : IRequestHandler<GetByContractIdContractCollect_DistributeQuery, List<ContractCollect_DistributeDto>>
    {
        private readonly IReadRepository<ContractCollect_Distribute> _readRepository;

        public GetByContractIdContractCollect_DistributeQueryHandler(IReadRepository<ContractCollect_Distribute> readRepository)
        {
            this._readRepository = readRepository;
        }
        public async Task<List<ContractCollect_DistributeDto>> Handle(GetByContractIdContractCollect_DistributeQuery request, CancellationToken cancellationToken)
        {
            var collect_Distribute = await _readRepository.Table.Include(b => b.BoxType)
                .Select(c => new ContractCollect_DistributeDto
                {
                    Id = c.Id,
                    ContractInfoId = c.ContractInfoId,
                    BoxTypeId = c.BoxTypeId,
                    CityId = c.CityId,
                    ProvinceId = c.ProvinceId,
                    SalePrice = c.SalePrice,
                    BuyPrice = c.BuyPrice,
                    BoxName = c.BoxType.Name,
                    Height = c.BoxType.Height,
                    Width = c.BoxType.Width,
                    Length = c.BoxType.Length,
                    Description=c.Description,
                    IsActice=c.IsActice,
                })
                .Where(c=> c.ContractInfoId == request.ContractInfoId)
                .ToListAsync(cancellationToken);
            return collect_Distribute;
        }
    }
}
