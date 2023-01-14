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

namespace Postex.Contract.Application.Features.ContractBoxTypes.Queries
{
    public class GetByContractIdContractBoxTypeQueryHandler : IRequestHandler<GetByContractIdContractBoxTypeQuery, List<ContractBoxTypeDto>>
    {
        private readonly IReadRepository<ContractBoxType> _readRepository;

        public GetByContractIdContractBoxTypeQueryHandler(IReadRepository<ContractBoxType> readRepository)
        {
            this._readRepository = readRepository;
        }
        public async Task<List<ContractBoxTypeDto>> Handle(GetByContractIdContractBoxTypeQuery request, CancellationToken cancellationToken)
        {
            var cod = await _readRepository.Table.Include(b => b.BoxType)
                .Select(c => new ContractBoxTypeDto
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
                    Description=c.Description

                })
                .ToListAsync(cancellationToken);
            return cod;
        }
    }
}
