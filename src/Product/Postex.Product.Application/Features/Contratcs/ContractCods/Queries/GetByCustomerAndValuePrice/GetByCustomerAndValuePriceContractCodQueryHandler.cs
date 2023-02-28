﻿using MediatR;
using Postex.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postex.Product.Domain.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractCods.Queries.GetByCustomerAndValuePrice
{
    public class GetByCustomerAndValuePriceContractCodQueryHandler : IRequestHandler<GetByCustomerAndValuePriceContractCodQuery, CodPriceDto>
    {
        private readonly IReadRepository<ContractCod> _readRepository;

        public GetByCustomerAndValuePriceContractCodQueryHandler(IReadRepository<ContractCod> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<CodPriceDto> Handle(GetByCustomerAndValuePriceContractCodQuery request, CancellationToken cancellationToken)
        {
            var cod = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CustomerId == 0 && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0 && c.FromValue >= request.ValuePrice && c.ToValue <= request.ValuePrice)
              .Select(c => new CodPriceDto
              {
                  ContractId = c.ContractInfoId,
                  ContractCodId = c.Id,
                  ValuePrice = request.ValuePrice,
                  DefaultFixedValue = c.FixedValue,
                  DefaultFixedPercent = c.FixedPercent,
                  ContractLevel = "Default"

              })
              .FirstOrDefaultAsync(cancellationToken);

            var codCus = await _readRepository.Table
                .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CustomerId == request.CustomerId && c.FromValue >= request.ValuePrice && c.ToValue <= request.ValuePrice)
                .Select(c => new CodPriceDto
                {
                    ContractId = c.ContractInfoId,
                    ContractCodId = c.Id,                   
                    ContractFixedValue = c.FixedValue,
                    ContractFixedPercent = c.FixedPercent,                    
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (codCus != null)
            {
                cod.ContractId = codCus.ContractId;
                cod.ContractCodId = codCus.ContractCodId;
                cod.ContractFixedValue = codCus.ContractFixedValue;
                cod.ContractFixedPercent = codCus.ContractFixedPercent;
                cod.ContractLevel = "Customer";
                return cod;
            }


            var codCity = await _readRepository.Table
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == 0 && c.FromValue >= request.ValuePrice && c.ToValue <= request.ValuePrice)
            .Select(c => new CodPriceDto
            {
                ContractId = c.ContractInfoId,
                ContractCodId = c.Id,
                ContractFixedValue = c.FixedValue,
                ContractFixedPercent = c.FixedPercent,
            })
             .FirstOrDefaultAsync(cancellationToken);

            if (codCity != null)
            {
                cod.ContractId = codCity.ContractId;
                cod.ContractCodId = codCity.ContractCodId;
                cod.ContractFixedValue = codCity.ContractFixedValue;
                cod.ContractFixedPercent = codCity.ContractFixedPercent;
                cod.ContractLevel = "City";
                return cod;
            }

            var codProvince = await _readRepository.Table
            .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.CityId == 0 && c.ContractInfo.CustomerId == 0 && c.FromValue >= request.ValuePrice && c.ToValue <= request.ValuePrice)
            .Select(c => new CodPriceDto
            {
                ContractId = c.ContractInfoId,
                ContractCodId = c.Id,
                ContractFixedValue = c.FixedValue,
                ContractFixedPercent = c.FixedPercent,
            })
            .FirstOrDefaultAsync(cancellationToken);

            if (codProvince != null)
            {
                cod.ContractId = codProvince.ContractId;
                cod.ContractCodId = codProvince.ContractCodId;
                cod.ContractFixedValue = codProvince.ContractFixedValue;
                cod.ContractFixedPercent = codProvince.ContractFixedPercent;
                cod.ContractLevel = "Province";
                return cod;
            }


            return cod;
        }
    }
}