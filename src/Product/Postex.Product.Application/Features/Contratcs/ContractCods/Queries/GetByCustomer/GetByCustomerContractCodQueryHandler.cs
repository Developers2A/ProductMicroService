﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractCods.Queries.GetByCustomer
{
    public class GetByCustomerContractCodQueryHandler : IRequestHandler<GetByCustomerContractCodQuery, List<ContractCodDto>>
    {
        private readonly IReadRepository<ContractCod> _readRepository;

        public GetByCustomerContractCodQueryHandler(IReadRepository<ContractCod> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<ContractCodDto>> Handle(GetByCustomerContractCodQuery request, CancellationToken cancellationToken)
        {
            var codCus = await _readRepository.Table.AsNoTracking()
               .Include(c => c.ContractInfo)
               .Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now)
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
                   LevelPrice = "Customer"
               })
               .ToListAsync(cancellationToken);
            if (codCus.Count != 0)
                return codCus;

            var codCity = await _readRepository.Table
                 .Include(c => c.ContractInfo)
                 .Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now)
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
                     LevelPrice = "City"
                 })
                 .ToListAsync(cancellationToken);
            if (codCity.Count != 0)
                return codCity;

            var codProvince = await _readRepository.Table
                .Include(c => c.ContractInfo)
                .Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StateId == request.StateId && c.ContractInfo.CityId == 0 && c.ContractInfo.CustomerId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now)
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
                    LevelPrice = "Province"
                })
                .ToListAsync(cancellationToken);
            if (codProvince.Count != 0)
                return codProvince;

            var codDefualt = await _readRepository.Table
           .Include(c => c.ContractInfo)
           .Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == 0 && c.ContractInfo.CityId == 0 && c.ContractInfo.StateId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now)
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
