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

namespace Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByCustomerAndBoxType
{
    public class GetByCustomerAndBoxTypeContractBoxPriceQueryHandler : IRequestHandler<GetByCustomerAndBoxTypeContractBoxPriceQuery, List<ContractBoxPriceDto>>
    {
        private readonly IReadRepository<ContractBoxPrice> _readRepository;

        public GetByCustomerAndBoxTypeContractBoxPriceQueryHandler(IReadRepository<ContractBoxPrice> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<ContractBoxPriceDto>> Handle(GetByCustomerAndBoxTypeContractBoxPriceQuery request, CancellationToken cancellationToken)
        {

            var boxPriceCus = await _readRepository.Table
                .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CustomerId == request.CustomerId && c.BoxTypeId == request.BoxTypeId)
                .Select(c => new ContractBoxPriceDto
                {
                    Id = c.Id,
                    ContractInfoId = c.ContractInfoId,
                    BoxTypeId = c.BoxTypeId,
                    CityId = c.CityId,
                    ProvinceId = c.ProvinceId,
                    SalePrice = c.SalePrice,
                    BuyPrice = c.BuyPrice,
                    Description = c.Description,
                    LevelPrice = "Customer"
                })
                .ToListAsync(cancellationToken);

            if (boxPriceCus.Count > 0)
                return boxPriceCus;

            var boxPriceCity = await _readRepository.Table
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == 0 && c.BoxTypeId == request.BoxTypeId)
             .Select(c => new ContractBoxPriceDto
             {
                 Id = c.Id,
                 ContractInfoId = c.ContractInfoId,
                 BoxTypeId = c.BoxTypeId,
                 CityId = c.CityId,
                 ProvinceId = c.ProvinceId,
                 SalePrice = c.SalePrice,
                 BuyPrice = c.BuyPrice,
                 Description = c.Description,
                 LevelPrice = "City"
             })
             .ToListAsync(cancellationToken);

            if (boxPriceCity.Count > 0)
                return boxPriceCity;

            var boxPriceProvince = await _readRepository.Table
            .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.CityId == 0 && c.ContractInfo.CustomerId == 0 && c.BoxTypeId == request.BoxTypeId)
            .Select(c => new ContractBoxPriceDto
            {
                Id = c.Id,
                ContractInfoId = c.ContractInfoId,
                BoxTypeId = c.BoxTypeId,
                CityId = c.CityId,
                ProvinceId = c.ProvinceId,
                SalePrice = c.SalePrice,
                BuyPrice = c.BuyPrice,
                Description = c.Description,
                LevelPrice = "Province"
            })
            .ToListAsync(cancellationToken);

            if (boxPriceProvince.Count > 0)
                return boxPriceProvince;

            var boxPriceDefualt = await _readRepository.Table             
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && (c.ContractInfo.CustomerId == 0 && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0) && c.BoxTypeId == request.BoxTypeId)
              .Select(c => new ContractBoxPriceDto
              {
                  Id = c.Id,
                  ContractInfoId = c.ContractInfoId,
                  BoxTypeId = c.BoxTypeId,
                  CityId = c.CityId,
                  ProvinceId = c.ProvinceId,
                  SalePrice = c.SalePrice,
                  BuyPrice = c.BuyPrice,
                  Description = c.Description,
                  IsActive = c.IsActive,
                  LevelPrice = "Default"

              })
              .ToListAsync(cancellationToken);

            return boxPriceDefualt;

        }
    }
}