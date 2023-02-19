using MediatR;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain;
using Postex.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractCods.Queries.GetByCustomer
{
    public class GetByCustomerContractCodQueryHandler : IRequestHandler<GetByCustomerContractCodQuery, List<ContractCodDto>>
    {
        private readonly IReadRepository<ContractCod> _readRepository;

        public GetByCustomerContractCodQueryHandler(IReadRepository<ContractCod> readRepository)
        {
            this._readRepository = readRepository;
        }
        public async Task<List<ContractCodDto>> Handle(GetByCustomerContractCodQuery request, CancellationToken cancellationToken)
        {
            var codCus = await _readRepository.Table.AsNoTracking()
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId)
               .Select(c => new ContractCodDto
               {
                   Id = c.Id,
                   ContractInfoId = c.ContractInfoId,
                   FromValue = c.FromValue,
                   ToValue = c.ToValue,
                   FixedPercent = c.FixedPercent,
                   FixedValue = c.FixedValue,
                   Description = c.Description,
                   IsActice=c.IsActice,
                   LevelPrice = "Customer"
               })
               .ToListAsync(cancellationToken);
            if (codCus.Count != 0)
                return codCus;

         

            var codCity = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == null )
              .Select(c => new ContractCodDto
              {
                  Id = c.Id,
                  ContractInfoId = c.ContractInfoId,
                  FromValue = c.FromValue,
                  ToValue = c.ToValue,
                  FixedPercent = c.FixedPercent,
                  FixedValue = c.FixedValue,
                  Description = c.Description,
                  IsActice = c.IsActice,
                  LevelPrice="City"
              })
              .ToListAsync(cancellationToken);
            if (codCity.Count != 0)
                return codCity;

            var codDefualt = await _readRepository.Table
           .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && (c.ContractInfo.CustomerId == null && c.ContractInfo.CityId == null && c.ContractInfo.ProvinceId == null))
           .Select(c => new ContractCodDto
           {
               Id = c.Id,
               ContractInfoId = c.ContractInfoId,
               FromValue = c.FromValue,
               ToValue = c.ToValue,
               FixedPercent = c.FixedPercent,
               FixedValue = c.FixedValue,
               Description = c.Description,
               IsActice = c.IsActice,
               LevelPrice = "Default"

           })
           .ToListAsync(cancellationToken);

            return codDefualt;

        }
    }
}
